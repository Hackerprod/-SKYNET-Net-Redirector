using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyHook;
using SKYNET.Controls;
using SKYNET.Detour.Helpers;
using SKYNET.GUI;
using SKYNET.Helper;
using SKYNET.Helpers;
using SKYNET.INI;
using SKYNET.Types;

namespace SKYNET
{
    public partial class frmMain : frmBase
    {
        public List<NetMessage> NetMessages;
        public string INIPath;
        public bool WindowsMenuItem;
        public bool AssociateFileExtension;
        public bool RunOnStartup;
        public RegistrySettings RegistrySettings;

        public static frmMain frm;
        public static HookInterface HookInterface;
        public static HookCallback HookCallback;
        public static Settings Settings;

        private string FileArg;
        private int ProcessId;
        private string channel;
        public Process InjectedProcess;
        private DumpManager DumpManager;


        public frmMain(string fileArg)
        {
            InitializeComponent();
            frm = this;
            CheckForIllegalCrossThreadCalls = false;
            base.SetMouseMove(P_Top);

            INIPath = Path.Combine(modCommon.GetPath(), "Data", "SKYNET.Configuration.ini");
            modCommon.EnsureDirectoryExists(INIPath, true);

            RegistrySettings = new RegistrySettings(@"SOFTWARE\SKYNET\[SKYNET] Net Redirector\");
            RegistrySettings.OnKeyEmpty += RegistrySettings_OnKeyEmpty;
            RegistrySettings.OnError += RegistrySettings_OnError;

            WindowsMenuItem = (bool)RegistrySettings.Get<bool>("WindowsMenuItem", true);
            AssociateFileExtension = (bool)RegistrySettings.Get<bool>("AssociateFileExtension", true);
            RunOnStartup = (bool)RegistrySettings.Get<bool>("RunOnStartup", false);

            NetMessages = new List<NetMessage>();
            FileArg = fileArg;

            string DumpDirectory = Path.Combine(modCommon.GetPath(), "Data", "Dumps");
            DumpManager = new DumpManager(DumpDirectory);

        }

        private void RegistrySettings_OnKeyEmpty(object sender, EventArgs e)
        {


        }

        private void RegistrySettings_OnError(object sender, Exception e)
        {
            Write("REGISTRY", e, Color.Red);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Write("NET REDIRECTOR", "Initializing Net Redirector", Color.White);
            Initialize();
        }

        private void Initialize()
        {
            channel = null;
            HookInterface = new HookInterface();
            INISerializer.OnErrorMessage += INISerializer_OnErrorMessage;
            if (!File.Exists(INIPath))
            {
                string Config = CreateConfigurationFile();

                Write("NET REDIRECTOR", "Please configure Settings file", Color.White);
                return;
            }
            else
            {
                Settings = INISerializer.DeserializeFromFile<Settings>(INIPath);

                if (Settings == null)
                {
                    Write("Settings", "Error loading settings", Color.Red);
                    return;
                }

                HookInterface.InjectOnStart = Settings.InjectOnStart;
                HookInterface.LoadPlugins = Settings.LoadPlugins;

                HookInterface.DumpToConsole = Settings.DumpToConsole;
                HookInterface.DumpToFile = Settings.DumpToFile;
                HookInterface.SkipCertificateChainVerification = Settings.SkipCertificateChainVerification;

                HookInterface.DnsRedirection = Settings.DNSRedirection != null ? Settings.DNSRedirection : new ConcurrentDictionary<string, string>();
                HookInterface.IPRedirection = Settings.IPRedirection != null ? Settings.IPRedirection : new ConcurrentDictionary<string, string>();
                HookInterface.PortRedirection = Settings.PortRedirection != null ? Settings.PortRedirection : new ConcurrentDictionary<int, int>();
            }

            string dllPath = Path.Combine(modCommon.GetPath(), "SKYNET.Detour.dll");

            HookInterface.OnMessage += HookInterface_OnMessage;
            HookInterface.PingNotify += HookInterface_PingNotify;
            HookInterface.DllPath = dllPath;
            HookInterface.InjectionOptions = InjectionOptions.Default;
            HookInterface.OnPacketReceived += HookInterface_OnPacketReceived;

            BT_Retry.Visible = !HookInterface.InjectOnStart;

            if (HookInterface.DumpToFile)
            {
                DumpManager.Initialize();
            }

            if (Path.GetExtension(FileArg).ToLower() == ".exe")
            {
                Hook(FileArg);
                return;
            }

            if (HookInterface.InjectOnStart)
            {
                Hook();
            }
            else
            {
                Write("NET REDIRECTOR", $"Please... press Hook button to start {Path.GetFileName(Settings.Path)}", Color.White);
            }

        }

        private void INISerializer_OnErrorMessage(object sender, string error)
        {
            Write("NET REDIRECTOR", error, Color.White);
        }

        private void Hook(string executablePath = "")
        {
            channel = null;
            string Executable = "";
            if (!string.IsNullOrEmpty(executablePath))
            {
                Executable = executablePath;
            }
            else
                Executable = Settings.Path;

            if (!File.Exists(Executable))
            {
                Write("NET REDIRECTOR", $"Executable {Executable} not found, please configure it", Color.White);
                return;
            }

            try
            {
                var InObject = WellKnownObjectMode.Singleton;
                RemoteHooking.IpcCreateServer(ref channel, InObject, HookInterface);
                HookInterface.ChannelName = channel;
                RemoteHooking.CreateAndInject(Executable, Settings.Arguments, 0, HookInterface.InjectionOptions, HookInterface.DllPath, HookInterface.DllPath, out ProcessId, HookInterface.ChannelName);
                InjectedProcess = Process.GetProcessById(ProcessId);
                Write("NET REDIRECTOR", $"Redirecting network traffic for \"{Path.GetFileName(Executable)}\"", Color.White);
                WaitForExit();
                BT_Retry.Visible = false;
            }
            catch (Exception ex)
            {
                Write("NET REDIRECTOR", $"Error Injecting {Path.GetFileName(Executable)}", Color.Red);
                Write("NET REDIRECTOR", ex.Message, Color.Red);
                BT_Retry.Visible = true;
            }
        }

        private void HookInterface_PingNotify(object sender, string callBackChannel)
        {
            if (HookCallback == null)
            {
                HookCallback = RemoteHooking.IpcConnectClient<HookCallback>(callBackChannel);
            }
        }

        private void WaitForExit()
        {
            Task.Run(() =>
            {
                int closeId = 0;
                string processName = "";
                while (ProcessId != closeId)
                {
                    Process processById = Process.GetProcessById(ProcessId);
                    processName = processById.ProcessName;
                    closeId = ProcessId;
                    processById.WaitForExit();
                }
                Write("NET REDIRECTOR", $"The injected process {processName} are closed", Color.Red);
                modCommon.InvokeVisible(BT_Retry, true);
            });
        }
        private void HookInterface_OnMessage(object sender, ConsoleMessage e)
        {
            Write(e);
        }
        private void HookInterface_OnPacketReceived(object sender, NetMessage e)
        {
            NetMessages.Add(e);
            if (HookInterface.DumpToFile)
            {
                DumpManager.WriteDump(e);
            }
        }
        private void Write(string sender, object msg, Color color)
        {
            Write(new ConsoleMessage(sender, msg, MessageType.SENDER, color));
        }

        private void Write(ConsoleMessage e)
        {
            try
            {
                frm.Logger.Invoke(new Action(() =>
                {
                    frm.Logger.WriteLine(e);
                }));
            }
            catch 
            {
            }
        }

        private string CreateConfigurationFile()
        {
            Settings = new Settings()
            {
                Path = "",
                Arguments = "",
                DNSRedirection = { },
                IPRedirection = { },
                PortRedirection = { },
                InjectOnStart = false,
                LoadPlugins = true,
                DumpToConsole = false,
                DumpToFile = false,
                SkipCertificateChainVerification = false
            };

            INISerializer.SerializeToFile(Settings, INIPath);

            string Content = "";
            try
            {
                Content = File.ReadAllText(INIPath);
            }
            catch 
            {
            }
            return Content;
        }
        private void B_Close_Clicked(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void B_Minimize_Clicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                HookCallback?.InvokeReleaseHooks();
                DumpManager.Dispose();
            }
            catch { }  

            if (InjectedProcess != null)
            {
                try
                {
                    InjectedProcess.Kill();
                }
                catch 
                {
                }
            }
        }

        private void BT_Retry_Click(object sender, EventArgs e)
        {
            Hook();
        }

        private void BT_Menu_Click(object sender, EventArgs e)
        {
            if (CM_Menu.Focused)
            {
                CM_Menu.Hide();
                return;
            }
            CM_Menu.Show(this, new Point(562, BT_Menu.Location.Y - 100));
        }

        private void M_Settings_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private void M_ShowModules_Click(object sender, EventArgs e)
        {
            try
            {
                if (InjectedProcess != null)
                {
                    Opacity = 0.93;
                    new frmModules(InjectedProcess).ShowDialog();
                    Opacity = 100;
                }                
            }
            catch (Exception ex)
            {
                //Write("Modules", $"Cant' show modules [{ex}]", Color.Yellow);
            }
        }

        private void M_ShowInjectedFunctions_Click(object sender, EventArgs e)
        {
            INISerializer.SerializeToFile(Settings, INIPath);
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            modCommon.ShowShadow = false;
            ShadowBox.Dock = DockStyle.None;
        }
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            if (modCommon.ShowShadow)
            {
                ShadowBox.Dock = DockStyle.Fill;
            }
        }
        public static void SaveSettings()
        {
            INISerializer.SerializeToFile(Settings, frm.INIPath);
        }

        private void M_Dumps_Click(object sender, EventArgs e)
        {
            new frmDumps(NetMessages).Show();
        }

        private void ToTopMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToButtomMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ClearMenuItem_Click(object sender, EventArgs e)
        {
            Logger.ClearScreen();
        }

        private void CM_Menu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void AttachToProcessMenuItem_Click(object sender, EventArgs e)
        {
            new frmProcessInjector(HookInterface).ShowDialog();
        }
    }
}

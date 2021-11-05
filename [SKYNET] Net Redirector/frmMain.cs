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
using SKYNET.Types;

namespace SKYNET
{
    public partial class frmMain : frmBase
    {
        public INIParser IniParser;
        public List<NetMessage> NetMessages;
        public string _iniPath = "SKYNET.Configuration.ini";
        public bool WindowsMenuItem;
        public bool AssociateFileExtension;
        public bool RunOnStartup;
        public RegistrySettings RegistrySettings;

        public static frmMain frm;
        public static HookInterface HookInterface;
        public static HookCallback HookCallback;
        public static string ExecutablePath;

        private string FileArg;
        private string CommandLines;
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

            RegistrySettings = new RegistrySettings(@"SOFTWARE\SKYNET\[SKYNET] Net Redirector\");
            RegistrySettings.OnKeyEmpty += RegistrySettings_OnKeyEmpty;
            RegistrySettings.OnError += RegistrySettings_OnError;

            WindowsMenuItem = (bool)RegistrySettings.Get<bool>("WindowsMenuItem", true);
            AssociateFileExtension = (bool)RegistrySettings.Get<bool>("AssociateFileExtension", true);
            RunOnStartup = (bool)RegistrySettings.Get<bool>("RunOnStartup", false);

            NetMessages = new List<NetMessage>();
            FileArg = fileArg;

            string DumpDirectory = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Dumps");
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
            //string filePath = @"D:\Música\04. Todo Cambió.mp3";

            //DateTime time1 = DateTime.Now;
            //FileInfo info = new FileInfo(filePath);

            //TimeSpan span = DateTime.Now - time1;
            //Write("FILE", $"Size {info.Length}, {span.Milliseconds} milliseconds", Color.Green);

            //DateTime time2 = DateTime.Now;
            //GetFileSize(filePath, out uint size);

            //TimeSpan span2 = DateTime.Now - time2;
            //Write("FILE", $"Size {size}, {span2.Milliseconds} milliseconds", Color.Green);



        }
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern uint GetFileSize([MarshalAs(UnmanagedType.LPWStr)] string nodename, out uint lpFileSizeHigh);

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            Write("NET REDIRECTOR", "Initializing Net Redirector", Color.White);

            Initialize();
        }

        private void Initialize()
        {
            channel = null;
            HookInterface = new HookInterface();
            _iniPath = Path.Combine(modCommon.GetPath(), _iniPath);
            if (!File.Exists(_iniPath))
            {
                string Config = CreateConfigurationFile();

                Write("NET REDIRECTOR", "Please configure Settings file", Color.White);
                Write("NET REDIRECTOR", Config, Color.White);
                return;
            }
            else
            {
                IniParser = new INIParser();
                IniParser.Load(_iniPath);

                ExecutablePath = (string)IniParser["File Configuration"]["Path"];
                CommandLines = (string)IniParser["File Configuration"]["Arguments"];

                HookInterface.InjectOnStart = (bool)IniParser["Application"]["InjectOnStart"];
                HookInterface.LoadPlugins = (bool)IniParser["Application"]["LoadPlugins"];

                HookInterface.DumpToConsole = (bool)IniParser["Misc"]["DumpToConsole"];
                HookInterface.DumpToFile = (bool)IniParser["Misc"]["DumpToFile"];
                HookInterface.SkipCertificateChainVerification = (bool)IniParser["Misc"]["SkipCertificateChainVerification"];

                if (IniParser["DNS Redirection"] != null && IniParser["DNS Redirection"].Settings.Any())
                {
                    foreach (var DNS in IniParser["DNS Redirection"].Settings)
                    {
                        HookInterface.DnsRedirection.TryAdd(DNS.Key, DNS.Value.ToString().Replace(" ", ""));
                    }
                }

                if (IniParser["IP Redirection"] != null && IniParser["IP Redirection"].Settings.Any())
                {
                    foreach (var IP in IniParser["IP Redirection"].Settings)
                    {
                        HookInterface.IPRedirection.TryAdd(IP.Key, IP.Value.ToString().Replace(" ", ""));
                    }
                }

                if (IniParser["Port Redirection"] != null && IniParser["Port Redirection"].Settings.Any())
                {
                    foreach (var DNS in IniParser["Port Redirection"].Settings)
                    {
                        HookInterface.PortRedirection.TryAdd(DNS.Key, DNS.Value.ToString().Replace(" ", ""));
                    }
                }
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
                Write("NET REDIRECTOR", $"Please... press Hook button to start {Path.GetFileName(ExecutablePath)}", Color.White);
            }

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
                Executable = ExecutablePath;

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
                RemoteHooking.CreateAndInject(Executable, CommandLines, 0, HookInterface.InjectionOptions, HookInterface.DllPath, HookInterface.DllPath, out ProcessId, HookInterface.ChannelName);
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
            StringBuilder config = new StringBuilder();

            // File Configuration

            config.AppendLine("[File Configuration]");
            config.AppendLine("Path = ");
            config.AppendLine("Arguments = ");
            config.AppendLine();

            // DNS Redirection

            config.AppendLine("[DNS Redirection]");
            config.AppendLine("# Declare hostnames to be redirected, [* = 127.0.0.1] redirect all DNS hosts to local");
            config.AppendLine("# Source = Destination");
            config.AppendLine();

            // IP Redirection

            config.AppendLine("[IP Redirection]");
            config.AppendLine("# Declare IP to be redirected, [192.168.1.20 = 127.0.0.1]");
            config.AppendLine("# Source = Destination");
            config.AppendLine();

            // Port Redirection

            config.AppendLine("[Port Redirection]");
            config.AppendLine("# Declare port to be redirected, [80 = 8080]");
            config.AppendLine("# Source = Destination");
            config.AppendLine();

            // Application

            config.AppendLine("[Application]");
            config.AppendLine("# Inject automatically when Net Redirector start");
            config.AppendLine("InjectOnStart = false");

            config.AppendLine("# Load custom plugins stored in Plugins folder");
            config.AppendLine("LoadPlugins = true");
            config.AppendLine();


            // Misc

            config.AppendLine("[Misc]");
            config.AppendLine("# Show received and sent packets in console");
            config.AppendLine("DumpToConsole = false");

            config.AppendLine("# Save received and sent packets in dump file");
            config.AppendLine("DumpToFile = false");

            config.AppendLine("# Skip verification of certificate chain policy");
            config.AppendLine("SkipCertificateChainVerification = false");

            File.WriteAllText(_iniPath, config.ToString());
            return config.ToString();
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
            IniParser.Save();
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
            frm.IniParser["File Configuration"]["Path"] = ExecutablePath;
            frm.IniParser["Application"]["InjectOnStart"] = HookInterface.InjectOnStart.ToString();
            frm.IniParser["Application"]["LoadPlugins"] = HookInterface.LoadPlugins.ToString();
            frm.IniParser["Misc"]["DumpToConsole"] = HookInterface.DumpToConsole.ToString();
            frm.IniParser["Misc"]["DumpToFile"] = HookInterface.DumpToFile.ToString();
            frm.IniParser["Misc"]["SkipCertificateChainVerification"] = HookInterface.SkipCertificateChainVerification.ToString();
            //frm.IniParser.SetProperties("DNS Redirection", HookInterface.DnsRedirection);
            //frm.IniParser.SetProperties("IP Redirection", HookInterface.IPRedirection);
            //frm.IniParser.SetProperties("Port Redirection", HookInterface.PortRedirection);

            Section DNS = frm.IniParser["DNS Redirection"];
            frm.IniParser[DNS] = HookInterface.DnsRedirection;

            Section IP = frm.IniParser["IP Redirection"];
            frm.IniParser[IP] = HookInterface.IPRedirection;

            Section Port = frm.IniParser["Port Redirection"];
            frm.IniParser[Port] = HookInterface.PortRedirection;

            frm.IniParser.Save();
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

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using EasyHook;
using SKYNET.Hook;
using SKYNET.Plugin;

namespace SKYNET
{ 
    public class Main : IEntryPoint
    {
        public static Main Instance;
        public static HookManager HookManager;
        public static HookCallback HookCallback;
		public static HookInterface HookInterface;
        private string callbackChannel;
        private List<IPlugin> Plugins;

        public Main(RemoteHooking.IContext inContext, string inChannelName)
        {
            callbackChannel = null;
            Instance = this;
            HookInterface = (HookInterface)Activator.GetObject(typeof(HookInterface), "ipc://" + inChannelName + "/" + inChannelName);// RemoteHooking.IpcConnectClient<HookInterface>(inChannelName);

            HookCallback = new HookCallback();
            HookCallback.ReleaseHooks += HookCallback_ReleaseHooks;
            HookCallback.ReleaseHook += HookCallback_ReleaseHook;
            HookCallback.DumpToConsoleChanged += HookCallback_DumpToConsoleChanged;
            HookCallback.DumpToFileChanged += HookCallback_DumpToFileChanged;
            HookCallback.DnsRedirectionChanged += HookCallback_DnsRedirectionChanged;
            HookCallback.IpRedirectionChanged += HookCallback_IpRedirectionChanged;
            HookCallback.PortRedirectionChanged += HookCallback_PortRedirectionChanged;

            RemoteHooking.IpcCreateServer(ref callbackChannel, WellKnownObjectMode.SingleCall, HookCallback);

            //HookInterface = RemoteHooking.IpcConnectClient<HookInterface>(inChannelName);
            HookInterface.Ping(callbackChannel);
            Config.HelperLibraryLocation = Path.GetDirectoryName(HookInterface.DllPath);
            Config.DependencyPath = Path.GetDirectoryName(HookInterface.DllPath);

            //((TRemoteObject)Activator.GetObject(typeof(TRemoteObject), "ipc://" + InChannelName + "/" + InChannelName)) ?? throw new ArgumentException("Unable to create remote interface.");

            HookManager = new HookManager();
            Plugins = new List<IPlugin>();
        }

        internal static void ModuleLoaded(string v)
        {
            if (Instance.Plugins.Any())
            {
                foreach (var plugin in Instance.Plugins)
                {
                    plugin.ModuleLoaded(v);
                }
            }
        }

        public void Run(RemoteHooking.IContext inContext, string inChannelName)
        {
            try
            {

                if (HookInterface.LoadPlugins)
                {
                    InstallPlugins();
                }

                HookManager.Install();
            }
            catch (Exception ex)
            {
                Write("MAIN EX", ex);
            }
            RemoteHooking.WakeUpProcess();
            try
            {
                while (true)
                {
                    Thread.Sleep(7000);
                    HookInterface.Ping("");
                }
            }
            catch
            {
            }
            HookManager.UninstallHooks();
            LocalHook.Release();
        }

        private void InstallPlugins()
        {
            string PluginsDirectory = Path.Combine(modCommon.GetPath(), "Data", "Plugins");
            if (Directory.Exists(PluginsDirectory))
            {
                foreach (var file in Directory.GetFiles(PluginsDirectory, "*.dll"))
                {
                    try
                    {
                        var plugin = Assembly.LoadFile(file);
                        Type type = plugin.GetType("SKYNET.Plugin");
                        if (type != null)
                        {
                            IPlugin iPlugin = (IPlugin)Activator.CreateInstance(type);
                            if (iPlugin == null)
                            {
                                Write("PLUGINS", $"Failed to load plugin {Path.GetFileNameWithoutExtension(file)}", Color.Red);
                            }
                            else
                            {
                                iPlugin.Initialize(this, HookInterface);
                                HookManager.PluginHooks.AddRange(iPlugin.Hooks);
                                Write("PLUGINS", $"Loaded {Path.GetFileNameWithoutExtension(file)}", ColorTranslator.FromHtml("#27B8EF"));
                                Plugins.Add(iPlugin);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Write("PLUGINS", $"Failed to load plugin {Path.GetFileNameWithoutExtension(file)} {"\n"}", Color.Red);
                    }
                }
            }
        }
        
        public static string GetRedirectedHost(string nname)
        {
            string sourceDns = nname;

            if (HookInterface.DnsRedirection.Count == 0)
            {
                return nname;
            }
            if (HookInterface.DnsRedirection.TryGetValue("*", out string targetDns))
            {
                return targetDns;
            }
            if (HookInterface.DnsRedirection.TryGetValue(sourceDns, out targetDns))
            {
                return targetDns;
            }
            foreach (var redirected in HookInterface.DnsRedirection)
            {
                string dns = redirected.Key.StartsWith("*.") ? redirected.Key.Remove(0, 2) : redirected.Value;
                if (sourceDns.Length > dns.Length)
                {
                    sourceDns = sourceDns.Remove(0, sourceDns.Length - dns.Length);
                }
                if (dns == sourceDns)
                {
                    return redirected.Value;
                }
            }
            return nname;
        }

        public static string GetRedirectedIP(string originalIP)
        {
            foreach (var item in HookInterface.IPRedirection)
            {
                if (item.Key == originalIP)
                {
                    return item.Value;
                }
            }
            return originalIP;
        }
        public static int GetRedirectedPort(int originalPort)
        {
            foreach (var item in HookInterface.PortRedirection)
            {
                if (item.Key == originalPort)
                {
                    return item.Value;
                }
            }
            return originalPort;
        }
        public static void InjectToProcess(uint ProcessId, string name)
        {
            try
            {
                RemoteHooking.Inject((int)ProcessId, HookInterface.InjectionOptions, HookInterface.DllPath, HookInterface.DllPath, HookInterface.ChannelName);
            }
            catch (Exception ex)
            {
                Write("NET REDIRECTOR", $"Error injecting process in {name} " + Environment.NewLine + $" {new string(' ', 17)}" + ex.Message, Color.Red);
            }
        }
        public static void Write(object sender, object msg, Color color, string ObjectId = "")
        {
            HookInterface.InvokeMessage(sender.ToString(), msg, color, ObjectId);
        }
        public static void Write(object sender, object msg)
        {
            HookInterface.InvokeMessage(sender.ToString(), msg, Color.White);
        }

        private void HookCallback_ReleaseHooks(object sender, EventArgs e)
        {
            HookManager.UninstallHooks();
        }

        private void HookCallback_ReleaseHook(object sender, string hook)
        {
            HookManager.Uninstall(hook);
        }
        private void HookCallback_DnsRedirectionChanged(object sender, ConcurrentDictionary<string, string> DnsRedirection)
        {
            HookInterface.DnsRedirection = DnsRedirection;
        }
        private void HookCallback_IpRedirectionChanged(object sender, ConcurrentDictionary<string, string> IpRedirection)
        {
            HookInterface.IPRedirection = IpRedirection;
        }
        private void HookCallback_PortRedirectionChanged(object sender, ConcurrentDictionary<int, int> PortRedirection)
        {
            HookInterface.PortRedirection = PortRedirection;
        }
        private void HookCallback_DumpToFileChanged(object sender, bool DumpToFile)
        {
            HookInterface.DumpToFile = DumpToFile;
        }
        private void HookCallback_DumpToConsoleChanged(object sender, bool DumpToConsole)
        {
            HookInterface.DumpToConsole = DumpToConsole;

            if (DumpToConsole)
            {
                HookManager.InstallTrafficHooks();
            }
            else
            {
                HookManager.UninstallTrafficHooks();
            }
        }


        private IntPtr CreateInMemoryInterface()
        {
            // Privileges
            int ProcessCreateThread = 0x0002;
            int ProcessQueryInformation = 0x0400;
            int ProcessVMOperation = 0x0008;
            int ProcessVMWrite = 0x0020;
            int ProcessVMRead = 0x0010;

            // Memory Allocation
            uint MemoryCommit = 0x00001000;
            uint MemoryReserve = 0x00002000;
            uint PageReadWrite = 4;

            string DllPath = @"D:\Instaladores\Programación\Projects\[SKYNET] Dota2 GameCoordinator Server\steam_api.dll";

            Process targetProcess = Process.GetCurrentProcess();

            // Get handle of process
            IntPtr procHandle = Memory.OpenProcess(ProcessCreateThread | ProcessQueryInformation | ProcessVMOperation | ProcessVMWrite | ProcessVMRead, false, targetProcess.Id);

            // Get address of LoadLibraryA
            IntPtr loadLibraryAddress = Memory.GetProcAddress(Memory.GetModuleHandle("kernel32.dll"), "LoadLibraryA");

            // Allocate memory on target process
            IntPtr allocateMemoryAdress = Memory.VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((DllPath.Length + 1) * Marshal.SizeOf(typeof(char))), MemoryCommit | MemoryReserve, PageReadWrite);

            // Write name of dll in process
            UIntPtr bytesWritten;
            Memory.WriteProcessMemory(procHandle, allocateMemoryAdress, Encoding.Default.GetBytes(DllPath), (uint)((DllPath.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);

            // Create thread to call LoadLibraryA
            var RemoteThread = Memory.CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddress, allocateMemoryAdress, 0, IntPtr.Zero);
            return RemoteThread;
        }

    }
    public class Memory
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationgFlags, IntPtr lpThreadId);
    }

}

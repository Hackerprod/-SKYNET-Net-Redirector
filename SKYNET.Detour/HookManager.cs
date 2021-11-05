using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Helper;
using SKYNET.Hook.Processor;
using SKYNET.Types;

namespace SKYNET.Hook
{
    public class HookManager
    {
        public List<IHook> Hooks;
        public List<IHook> PluginHooks;
        private List<IHook> TrafficHooks;
        public List<SocketHandle> Sockets;
        
        public List<string> Modules
        {
            get
            {
                var Modules = new List<string>();
                foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
                {
                    Modules.Add(module.ModuleName.ToUpper());
                }
                return Modules;
            }
        }

        public HookManager()
        {
            Sockets = new List<SocketHandle>();

            Hooks = new List<IHook>();
            TrafficHooks = new List<IHook>();
            PluginHooks = new List<IHook>();

            Hooks.Add(new GetAddrInfo());
            Hooks.Add(new GetAddrInfoW());
            Hooks.Add(new GetAddrInfoExW());
            Hooks.Add(new GetAddrInfoExA());

            //Hooks.Add(new Listen());
            //Hooks.Add(new Socket());
            //Hooks.Add(new WSASocketW());

            Hooks.Add(new CertVerifyCertificateChainPolicy());

            Hooks.Add(new GetHostByName());

            Hooks.Add(new Connect());
            Hooks.Add(new WSAConnect());
            Hooks.Add(new WSAConnectByNameA());
            Hooks.Add(new WSAConnectByNameW());
            //Hooks.Add(new ConnectToProxy());

            //Task.Run(() =>
            //{
            //    var certHandler = new CertificateHandler();
            //    certHandler.Initialize();
            //});

            Hooks.Add(new HttpInitialize());



            //Hooks.Add(new Listen());
            //Hooks.Add(new WSASocketW());

            // Sockets
            Hooks.Add(new CloseSocket());
            Hooks.Add(new OpenSocket());
            Hooks.Add(new WSAOpenSocketW());
            

            //Task.Run(() =>
            //{
            //    var s = VRage.MyTryConnectHelper.TryConnect("10.31.0.1", 28000);
            //    Main.Write("Modules", s, Color.Chocolate);
            //});

            //SockHook hook = new SockHook();
            //hook.InitializeHooks()

            Hooks.Add(new CreateProcessA());
            Hooks.Add(new CreateProcessW());

            Hooks.Add(new LdrLoadDll());



            // Send packet
            TrafficHooks.Add(new Send());
            TrafficHooks.Add(new SendTo());
            TrafficHooks.Add(new WSASend());
            TrafficHooks.Add(new WSASendTo());

            //// Received packet
            TrafficHooks.Add(new Recv());
            TrafficHooks.Add(new RecvFrom());
            TrafficHooks.Add(new WSARecvFrom());
            //TrafficHooks.Add(new WSARecv());
        }



        public void Install()
        {
            foreach (var hook in Hooks)
            {
                if (!hook.Installed && Modules.Contains(hook.Library.ToUpper()))
                {
                    InstallHook(hook);
                }
            }
            foreach (var item in Modules)
            {
                if (item.ToUpper() == "HTTPAPI" || item.ToUpper() == "HTTPAPI.DLL")
                {
                    Main.Write("Modules", " HTTPAPI -------------------------------", Color.Red);
                }
                //Main.Write("Modules", item);
            }

            if (Main.HookInterface.DumpToConsole || Main.HookInterface.DumpToFile)
            {
                InstallTrafficHooks();
            }
            if (Main.HookInterface.LoadPlugins)
            {
                InstallPluginHooks();
            }
        }
        public void Install(string UpperDllName)
        {
            if (string.IsNullOrEmpty(UpperDllName))
            {
                return;
            }

            IHook hook = Hooks.Find(h => h.Installed == false && Path.GetFileNameWithoutExtension(h.Library).ToUpper() == UpperDllName);
            if (hook != null)
            {
                InstallHook(hook);
            }
        }
        internal void InstallTrafficHooks()
        {
            foreach (var hook in TrafficHooks)
            {
                if (!hook.Installed && Modules.Contains(hook.Library.ToUpper()))
                {
                    InstallHook(hook);
                }
            }
        }
        internal void InstallPluginHooks()
        {
            foreach (var hook in PluginHooks)
            {
                if (!hook.Installed && Modules.Contains(hook.Library.ToUpper()))
                {
                    InstallHook(hook);
                }
            }
        }
        private void InstallHook(IHook hook)
        {
            try
            {
                IntPtr ProcAddress = NativeMethods.GetProcAddress(hook.Library, hook.Method);
                hook.ProcAddress = ProcAddress;

                if (ProcAddress == IntPtr.Zero)
                {
                    hook.Installed = false;
                    return;
                }
                try
                {
                    hook.Hook = LocalHook.Create(ProcAddress, hook.Delegate, Main.Instance);
                    hook.Hook.ThreadACL.SetExclusiveACL(new int[0]);
                    hook.Installed = true;
                    //Main.Write("HookManager", $"Installed {hook.Method} in {hook.Library}", Color.Orange);
                }
                catch
                {
                    Main.Write("HookManager", $"Failed injecting {hook.Method} in {hook.Library}", Color.Orange);
                    hook.Installed = false;
                }
            }
            catch
            {
            }
        }
        public void Uninstall(string Method)
        {
            if (!string.IsNullOrEmpty(Method))
            {
                foreach (var hook in Hooks)
                {
                    if (hook.Method == Method)
                    {
                        try
                        {
                            hook.Hook.Dispose();
                            hook.Installed = false;
                        }
                        catch { }
                    }
                }
            }
            else
            {
                foreach (var hook in Hooks)
                {
                    try
                    {
                        hook.Hook.Dispose();
                        hook.Installed = false;
                    }
                    catch { }
                }
            }
        }
        internal void UninstallHooks()
        {
            foreach (var hook in Hooks)
            {
                try
                {
                    hook.Hook.Dispose();
                    hook.Installed = false;
                }
                catch { }
            }
            foreach (var hook in TrafficHooks)
            {
                try
                {
                    hook.Hook.Dispose();
                    hook.Installed = false;
                }
                catch { }
            }
        }
        internal void UninstallTrafficHooks()
        {
            foreach (var hook in TrafficHooks)
            {
                if (hook.Installed)
                {
                    try
                    {
                        hook.Hook.Dispose();
                        hook.Installed = false;
                    }
                    catch { }
                }
            }
        }
        public ProtocolType GetProtocol(IntPtr socket)
        {
            if (socket == IntPtr.Zero) return ProtocolType.Tcp;

            SocketHandle soc = Main.HookManager.Sockets.Find(s => s.Handle == socket);
            if (soc != null)
            {
                return soc.ProtocolType;
            }

            return ProtocolType.Tcp;
        }


    }
}

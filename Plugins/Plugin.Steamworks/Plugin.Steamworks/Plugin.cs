using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SKYNET.Hook;
using SKYNET.Hook.Processor;
using Valve.Steamworks;

namespace SKYNET
{
    public class Plugin : IPlugin
    {
        public HookInterface HookInterface { get; set; }
        public Main Main { get; set; }
        public List<IHook> Hooks { get; set; }

        private bool Initialized;
        public void Dispose()
        {
            
        }

        public void Initialize(Main main, HookInterface Interface)
        {
            Main = main;
            HookInterface = Interface;
            Hooks = new List<IHook>();

            Initialized = TryInitializeHooks();
        }

        private bool TryInitializeHooks()
        {
            Write("Creating steamworks hooks ");
            new SteamAPI();
            new SteamAPI_ISteamClient();
            new Steam_GameServer();
            new SteamAPI_ISteamHTTP();
            new SteamInternal();
            return true;
        }

        public static void Write(object Msg)
        {
            Main.Write("STEAMWORKS", $"{Msg}", Color.BurlyWood);

        }

        public void ModuleLoaded(string module)
        {
            if (module.StartsWith("STEAM_API") && !Initialized)
            {
                Initialized = TryInitializeHooks();
            }
        }
    }
}

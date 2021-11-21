using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SKYNET.Hook;
using SKYNET.Hook.Processor;

namespace SKYNET
{
    public class Plugin : IPlugin
    {
        public HookInterface HookInterface { get; set; }
        public Main Main { get; set; }
        public List<IHook> Hooks { get; set; }

        public static bool Initialized;

        private SteamAPI _SteamAPI;

        public void Dispose()
        {
            
        }

        public void Initialize(Main main, HookInterface Interface)
        {
            Main = main;
            HookInterface = Interface;
            Hooks = new List<IHook>();

            Write("Creating steamworks hooks ");
            Initialized = false;

            _SteamAPI = new SteamAPI();
        }

        public void ModuleLoaded(string module)
        {
            if (module.StartsWith("STEAM_API"))
            {
                Write("dddddddddddddddddddddd");
                _SteamAPI.Initialize();
            }
            //_SteamAPI.Initialize();
        }
        public static void Write(object Msg)
        {
            if (Msg.ToString() != _lastMsg)
            {
                Main.Write("STEAMWORKS", $"{Msg}", Color.BurlyWood);
                _lastMsg = Msg.ToString();
            }
        }
        private static string _lastMsg;
    }
}

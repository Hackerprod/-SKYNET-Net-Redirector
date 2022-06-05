using SKYNET.Hook;
using SKYNET.Hook.Handles;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SKYNET.Plugin
{
    public class Plugin : IPlugin
    {
        public HookInterface HookInterface { get; set; }
        public Main Main { get; set; }
        public List<IHook> Hooks { get; set; }
        private List<BaseCalls> HookCalls;

        public void Initialize(Main main, HookInterface @interface)
        {
            Main = main;
            HookInterface = @interface;
            Hooks = new List<IHook>();

            HookCalls = new List<BaseCalls>();
            HookCalls.Add(new SteamAPI());
            HookCalls.Add(new SteamAPI_ISteamAppList());
            HookCalls.Add(new SteamInternal());
        }

        public void ModuleLoaded(string module)
        {
            if (module.ToLower().StartsWith("steam_api"))
            {
                InitializeHooks();
            }
        }

        private void InitializeHooks()
        {
            foreach (var hook in HookCalls)
            {
                hook.Install();
            }
        }

        public void Dispose()
        {
            // TODO:
        }
    }
}

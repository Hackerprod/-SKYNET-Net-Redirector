using System.Collections.Generic;
using SKYNET.Hook;

namespace SKYNET.Plugin
{
    public class Plugin : IPlugin
    {
        public HookInterface HookInterface { get; set; }
        public Main Main { get; set; }
        public List<IHook> Hooks { get; set; }

        public void Initialize(Main main, HookInterface @interface)
        {
            Main = main;
            HookInterface = @interface;
            Hooks = new List<IHook>();

            // kernel32.dll
            Hooks.Add(new CreateFileW());
            Hooks.Add(new ReadFile());
            Hooks.Add(new WriteFile());

            // advapi32.dll
            Hooks.Add(new RegOpenKeyExW());
            Hooks.Add(new RegQueryValueExW());
            Hooks.Add(new RegSetValueExW());
        }

        public void ModuleLoaded(string module)
        {

        }

        public void Dispose()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKYNET.Hook.Handler;
using SKYNET.Hook.Processor;

namespace SKYNET
{
    public class Plugin : IPlugin
    {
        public HookInterface HookInterface { get; set; }
        public Main Main { get; set; }
        public List<IHook> Hooks { get; set; }

        public void Dispose()
        {
            
        }

        public void Initialize(Main main, HookInterface @interface)
        {
            Main = main;
            HookInterface = @interface;
            Hooks = new List<IHook>();

            //winhttp.dll
            Hooks.Add(new WinHttpConnect());
            Hooks.Add(new WinHttpOpenRequest());

            //httpapi.dll
            Hooks.Add(new HttpCreateRequestQueue());

            //wininet.dll
            Hooks.Add(new CreateUrlCacheEntryW());
            Hooks.Add(new InternetConnectA());
            Hooks.Add(new InternetOpenUrlA());

            //ws2_32.dll
            Hooks.Add(new GetPeerName());
            Hooks.Add(new GetServByName());
            Hooks.Add(new Bind());
            Hooks.Add(new SetSockOpt());
            




        }
    }
}

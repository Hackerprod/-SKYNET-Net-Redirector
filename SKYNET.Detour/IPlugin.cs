using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET
{
    public interface IPlugin : IDisposable
    {
        HookInterface HookInterface { get; set; }
        Main Main { get; set; }
        List<IHook> Hooks { get; set; }
        void Initialize(Main main, HookInterface @interface);
        void ModuleLoaded(string module);
    }
}

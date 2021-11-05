using System.Runtime.InteropServices;

namespace SKYNET.Hook.Types
{
    struct STRING
    {
        public ushort Length;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string Content;
    }
}

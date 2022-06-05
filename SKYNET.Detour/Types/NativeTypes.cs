using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Hook.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WSABuffer
    {
        public int Length;      // Length of Buffer
        public IntPtr Pointer;  // Pointer to Buffer
    }


}



using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Helper;
using SKYNET.Hook.Types;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The connect function establishes a connection to a specified socket.
    /// </summary>
    public class Listen : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        public delegate int Dlisten(IntPtr socket, int backlog);
        Dlisten _Listen;

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int listen(IntPtr socket, int backlog);
        public override string Library => "ws2_32.dll";
        public override string Method => "listen";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FAHH");
        public override Delegate Delegate
        {
            get
            {
                _Listen = Marshal.GetDelegateForFunctionPointer<Dlisten>(ProcAddress);
                return new Dlisten(Callback);
            }
        }

        private int Callback([In] IntPtr socket, int backlog)
        {
            Write($"Listen");

            return _Listen(socket, backlog);

        }

    }
}

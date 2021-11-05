using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Helper;
using SKYNET.Hook.Types;
using SKYNET.Types;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook
{
    public class OpenSocket : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        internal delegate IntPtr OpenSocketDelegate(AddressFamily addressFamily, SocketType type, ProtocolType protocol);
        OpenSocketDelegate _OpenSocket;

        public override string Library => "ws2_32.dll";
        public override string Method => "socket";
        public override LocalHook Hook { get; set; }
        public override Color Color => Color.Coral; // ColorTranslator.FromHtml("#f58207"); 
        public override Delegate Delegate
        {
            get
            {
                _OpenSocket = Marshal.GetDelegateForFunctionPointer<OpenSocketDelegate>(ProcAddress);
                return new OpenSocketDelegate(Callback);
            }
        }
        private IntPtr Callback(AddressFamily addressFamily, SocketType type, ProtocolType protocol)
        {
            IntPtr result = IntPtr.Zero;
            try
            {
                result = _OpenSocket(addressFamily, type, protocol);

                if (result != IntPtr.Zero)
                {
                    SocketHandle socket = new SocketHandle()
                    {
                        AddressFamily = addressFamily,
                        SocketType = type,
                        ProtocolType = protocol,
                        Handle = result
                    };
                    Main.HookManager.Sockets.Add(socket);
                }
                return result;
            }
            catch
            {
                return result;
            }
        }
        //Ver esto despues con la esctructura SOCKADDR_IN (implementado en connect)



    }
}

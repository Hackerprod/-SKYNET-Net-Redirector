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
    public class CloseSocket : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        internal unsafe delegate int CloseSocketDelegate(IntPtr socket);
        CloseSocketDelegate _CloseSocket;

        public override string Library => "ws2_32.dll";
        public override string Method => "closesocket";
        public override LocalHook Hook { get; set; }
        public override Color Color => Color.Coral; // ColorTranslator.FromHtml("#f58207"); 
        public override Delegate Delegate
        {
            get
            {
                _CloseSocket = Marshal.GetDelegateForFunctionPointer<CloseSocketDelegate>(ProcAddress);
                return new CloseSocketDelegate(Callback);
            }
        }
        private int Callback(IntPtr socket)
        {
            int result = 0;
            try
            {
                result = _CloseSocket(socket);
                if (socket != IntPtr.Zero && ((SocketError)result == SocketError.Success || (SocketError)result == SocketError.WouldBlock))
                {
                    SocketHandle soc = Main.HookManager.Sockets.Find(s => s.Handle == socket);
                    if (soc != null)
                    {
                        Main.HookManager.Sockets.Remove(soc);
                    }
                }

                return result;
            }
            catch
            {
                return result;
            }
        }
    }
}

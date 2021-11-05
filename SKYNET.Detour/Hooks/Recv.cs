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

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The recv function receives data from a connected socket or a bound connectionless socket.
    /// </summary>
    public class Recv : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        internal delegate int RecvDelegate(IntPtr socket, IntPtr pBuffer, int len, SocketFlags pFlags);
        RecvDelegate _Recv;

        public override string Library => "ws2_32.dll";
        public override string Method => "recv";
        public override LocalHook Hook { get; set; }
        public override Color Color => Color.Coral; // ColorTranslator.FromHtml("#f58207"); 
        public override Delegate Delegate
        {
            get
            {
                _Recv = Marshal.GetDelegateForFunctionPointer<RecvDelegate>(ProcAddress);
                return new RecvDelegate(Callback);
            }
        }
        private int Callback(IntPtr socket, IntPtr pBuffer, int len, SocketFlags socketFlags)
        {
            int num = 0;
            try
            {
                num = _Recv(socket, pBuffer, len, socketFlags);
                if (num <= 0)
                {
                    return num;
                }
                byte[] buffer = pBuffer.GetBytes(num);

                Packet packet = new Packet
                {
                    Sender = "Recv",
                    Buffer = buffer,
                    Source = socket.GetSourceIPEndPoint(),
                    Destination = socket.GetDestinationIPEndPoint(),
                    Socket = socket,
                    Direction = DIRECTION.IN,
                    Protocol = Main.HookManager.GetProtocol(socket)
                };

                NetProcessor.ProcessRecv(packet);

                return num;
            }
            catch
            {
                return num;
            }
        }
    }
}

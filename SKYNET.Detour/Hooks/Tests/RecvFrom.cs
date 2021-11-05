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
    public class RecvFrom : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        internal unsafe delegate int RecvDelegate(IntPtr socket, IntPtr buf, int len, SocketFlags flags, IntPtr from, IntPtr fromlen);
        RecvDelegate _Recv;

        public override string Library => "ws2_32.dll";
        public override string Method => "recvfrom";
        public override LocalHook Hook { get; set; }
        public override Color Color => Color.Coral; // ColorTranslator.FromHtml("#f58207"); 
        public unsafe override Delegate Delegate
        {
            get
            {
                _Recv = Marshal.GetDelegateForFunctionPointer<RecvDelegate>(ProcAddress);
                return new RecvDelegate(Callback);
            }
        }
        private int Callback(IntPtr socket, IntPtr pBuffer, int len, SocketFlags socketFlags, IntPtr from, IntPtr fromlen)
        {
            int num = 0;
            try
            {
                num = _Recv(socket, pBuffer, len, socketFlags, from, fromlen);
                if (num <= 0 || len == 0)
                {
                    return num;
                }
                byte[] buffer = pBuffer.GetBytes(num);

                Packet packet = new Packet
                {
                    Sender = "RecvFrom",
                    Buffer = buffer,
                    Source = socket.GetSourceIPEndPoint(),
                    Destination = socket.GetDestinationIPEndPoint(),
                    Socket = socket,
                    Direction = DIRECTION.IN
                };

                NetProcessor.ProcessRecv(packet);

                return num;
            }
            catch
            {
                return num;
            }
        }
        //Ver esto despues con la esctructura SOCKADDR_IN (implementado en connect)



    }
}

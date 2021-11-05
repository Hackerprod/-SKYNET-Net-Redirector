using System;
using System.Collections.Generic;
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
    /// Sends data to a specific destination.
    /// </summary>
    public class SendTo : IHook
    {
        public override string Library => "ws2_32.dll";
        public override string Method => "sendto";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        delegate int SendToDelegate(IntPtr s, IntPtr buf, int len, SocketFlags flags, IntPtr socketAddress, int socketAddressSize);
        SendToDelegate _SendTo;

        public override Delegate Delegate
        {
            get
            {
                _SendTo = Marshal.GetDelegateForFunctionPointer<SendToDelegate>(ProcAddress);
                return new SendToDelegate(Callback);
            }
        }
        private int Callback(IntPtr socket, IntPtr pBuffer, int len, SocketFlags flags, IntPtr sockAddr, int socketAddressSize)
        {
            var result = _SendTo(socket, pBuffer, len, flags, sockAddr, socketAddressSize);

            try
            {
                SOCKADDR_IN addr_in = Marshal.PtrToStructure<SOCKADDR_IN>(sockAddr);
                string originalIp = new IPAddress(addr_in.sin_addr).ToString();
                string originalPort = Ws2_32.ntohs(addr_in.sin_port).ToString();

                byte[] array = pBuffer.GetBytes(len);
                Packet packet = new Packet
                {
                    Sender = "SendTo",
                    Buffer = array,
                    Source = socket.GetSourceIPEndPoint(),
                    Destination = socket.GetDestinationIPEndPoint(),
                    Socket = socket,
                    Direction = DIRECTION.OUT,
                    Protocol = Main.HookManager.GetProtocol(socket)
                };

                NetProcessor.ProcessSend(packet);
            }
            catch 
            {
            }

            return result;
        }
    }
}

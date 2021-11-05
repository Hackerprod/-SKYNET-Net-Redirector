using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Helper;
using SKYNET.Hook.Processor;
using SKYNET.Hook.Types;
using SKYNET.Types;

namespace SKYNET.Hook
{
    /// <summary>
    /// The send function sends data on a connected socket.
    /// </summary>
    /// <param name="socket">A descriptor identifying a connected socket.</param>
    /// <param name="pBuffer">A pointer to a buffer containing the data to be transmitted.</param>
    /// <param name="len">The length, in bytes, of the data in buffer pointed to by the buf parameter.</param>
    /// <param name="flags">A set of flags that specify the way in which the call is made. This parameter is constructed by using the bitwise OR operator with any of the following values.</param>
    /// <returns></returns>
    public class Send : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        delegate int SendDelegate(IntPtr s, IntPtr buf, int len, SocketFlags flags);
        SendDelegate _SendDelegate;
        public override string Library => "ws2_32.dll";
        public override string Method => "send";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");
        public override Delegate Delegate
        {
            get
            {
                _SendDelegate = Marshal.GetDelegateForFunctionPointer<SendDelegate>(ProcAddress);
                return new SendDelegate(Callback);
            }
        }
        private int Callback(IntPtr socket, IntPtr pBuffer, int len, SocketFlags flags)
        {
            int num = 0;
            try
            {
                num = _SendDelegate(socket, pBuffer, len, flags);

                byte[] array = pBuffer.GetBytes(len);
                Packet packet = new Packet
                {
                    Sender = "Send",
                    Buffer = array,
                    Source = socket.GetSourceIPEndPoint(),
                    Destination = socket.GetDestinationIPEndPoint(),
                    Socket = socket,
                    Direction = DIRECTION.OUT,
                    Protocol = Main.HookManager.GetProtocol(socket)
                };

                NetProcessor.ProcessSend(packet);

                return num;
            }
            catch (Exception)
            {
                return num;
            }
        }

        private int BindPacket(Packet packet, IntPtr pBuffer, int len, SocketFlags flags)
        {
            try
            {
                var remoteEP = new IPEndPoint(packet.Destination.Address, 80);

                IntPtr Socket = WinSockHelper.OpenSocket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                if (Socket == IntPtr.Zero) return (int)SocketError.SocketError;

                var nAddr = WinSockHelper.CreateAddr(remoteEP);

                IntPtr connectionStatus = WinSockHelper.Connect(Socket, nAddr, 16);

                if (connectionStatus != IntPtr.Zero) return (int)SocketError.SocketError;

                return WinSockHelper.send(connectionStatus, pBuffer, len, flags);
            }
            catch (Exception ex)
            {
                return (int)SocketError.SocketError;
            }
        }
    }
}

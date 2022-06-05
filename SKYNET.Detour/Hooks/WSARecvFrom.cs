using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Helper;
using SKYNET.Hook.Processor;
using SKYNET.Hook.Types;
using SKYNET.Types;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook
{
    /// <summary>
    /// The WSAConnect function establishes a connection to another socket application, exchanges connect data, and specifies required quality of service based on the specified FLOWSPEC structure.
    /// </summary>
    public class WSARecvFrom : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int WSARecvFromDelegate(IntPtr socketHandle, ref WSABuffer Buffer, int BufferCount, IntPtr bytesTransferred, SocketFlags socketFlags, IntPtr socketAddress, int socketAddressSize, IntPtr overlapped, IntPtr completionRoutine);
        WSARecvFromDelegate _WSARecvFrom;

        public override string Library => "ws2_32.dll";
        public override string Method => "WSARecvFrom";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FA00");
        public override Delegate Delegate
        {
            get
            {
                _WSARecvFrom = Marshal.GetDelegateForFunctionPointer<WSARecvFromDelegate>(ProcAddress);
                return new WSARecvFromDelegate(Callback);
            }
        }
        private int Callback(IntPtr socket, ref WSABuffer Buffer, int BufferCount, IntPtr bytesTransferred, SocketFlags socketFlags, IntPtr socketAddress, int socketAddressSize, IntPtr overlapped, IntPtr completionRoutine)
        {
            int result = 0;

            try
            {
                SOCKADDR_IN addr_in = Marshal.PtrToStructure<SOCKADDR_IN>(socketAddress);
                string address = new IPAddress(addr_in.sin_addr).ToString();
                var port = Ws2_32.ntohs(addr_in.sin_port);

                IPEndPoint Destination = addr_in.GetEndPoint();

                string RedirectedIP = Main.GetRedirectedIP(address);
                var RedirectedPort = Main.GetRedirectedPort(port);


                if (address != RedirectedIP || port != RedirectedPort)
                {
                    var nAddr = CreateAddr(RedirectedIP, RedirectedPort);
                    Destination = nAddr.GetEndPoint();
                    result = _WSARecvFrom(socket, ref Buffer, BufferCount, bytesTransferred, socketFlags, nAddr, socketAddressSize, overlapped, completionRoutine);
                }
                else
                {
                    result = _WSARecvFrom(socket, ref Buffer, BufferCount, bytesTransferred, socketFlags, socketAddress, socketAddressSize, overlapped, completionRoutine);
                }


                if (result != 0)
                {
                    return result;
                }

                var array = new byte[Buffer.Length];
                Marshal.Copy(Buffer.Pointer, array, 0, Buffer.Length);

                Packet packet = new Packet
                {
                    Sender = "WSARecvFrom",
                    Buffer = array,
                    Source = socket.GetSourceIPEndPoint(),
                    Destination = Destination,
                    OriginalDestination = addr_in.GetEndPoint(),
                    Socket = socket,
                    Direction = DIRECTION.OUT,
                    Protocol = Main.HookManager.GetProtocol(socket)
                };

                NetProcessor.ProcessRecv(packet);
            }
            catch (Exception)
            {
                return _WSARecvFrom(socket, ref Buffer, BufferCount, bytesTransferred, socketFlags, socketAddress, socketAddressSize, overlapped, completionRoutine);
            }

            return result;
        }

    }
}

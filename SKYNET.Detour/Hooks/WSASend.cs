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
using SKYNET.Hook.Types;
using SKYNET.Types;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The WSAConnect function establishes a connection to another socket application, exchanges connect data, and specifies required quality of service based on the specified FLOWSPEC structure.
    /// </summary>
    public class WSASend : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int WSASendDelegate(IntPtr socketHandle, ref WSABuffer Buffer, int BufferCount, IntPtr bytesTransferred, SocketFlags socketFlags, IntPtr overlapped, IntPtr completionRoutine);
        WSASendDelegate _WSASend;

        public override string Library => "ws2_32.dll";
        public override string Method => "WSASend";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FA00");
        public override Delegate Delegate
        {
            get
            {
                _WSASend = Marshal.GetDelegateForFunctionPointer<WSASendDelegate>(ProcAddress);
                return new WSASendDelegate(Callback);
            }
        }
        int n = 0;
        private int Callback(IntPtr socket, ref WSABuffer Buffer, int BufferCount, IntPtr bytesTransferred, SocketFlags socketFlags, IntPtr overlapped, IntPtr completionRoutine)
        {
            int result = _WSASend(socket, ref Buffer, BufferCount, bytesTransferred, socketFlags, overlapped, completionRoutine);

            if (result != 0)
            {
                return result;
            }

            try
            {
                var array = new byte[Buffer.Length];
                Marshal.Copy(Buffer.Pointer, array, 0, Buffer.Length);

                Packet packet = new Packet
                {
                    Sender = "WSASend",
                    Buffer = array,
                    Source = socket.GetSourceIPEndPoint(),
                    Destination = socket.GetDestinationIPEndPoint(),
                    Socket = socket,
                    Direction = DIRECTION.OUT,
                    Protocol = Main.HookManager.GetProtocol(socket)
                };

                NetProcessor.ProcessSend(packet);
            }
            catch (Exception)
            {
                
            }

            return result;
        }

    }
}

using System;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using EasyHook;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The recv function receives data from a connected socket or a bound connectionless socket.
    /// </summary>
    public class WSARecv : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        internal unsafe delegate int WSARecvDelegate(IntPtr socket, IntPtr pBuffer, int bufferCount, int bytesTransferred, SocketFlags socketFlags, IntPtr overlapped, IntPtr completionRoutine);
        WSARecvDelegate _WSARecv;
        public override string Library => "ws2_32.dll";
        public override string Method => "WSARecv";
        public override LocalHook Hook { get; set; }
        public override Color Color => Color.Yellow;
        public unsafe override Delegate Delegate
        {
            get
            {
                _WSARecv = Marshal.GetDelegateForFunctionPointer<WSARecvDelegate>(ProcAddress);

                return new WSARecvDelegate(Callback);
            }
        }
        private unsafe int Callback(IntPtr socket, IntPtr pBuffer, int bufferCount, int bytesTransferred, SocketFlags socketFlags, IntPtr overlapped, IntPtr completionRoutine)
        {
            int num = _WSARecv(socket, pBuffer, bufferCount, bytesTransferred, socketFlags, overlapped, completionRoutine);


            if ((SocketError)num != SocketError.Success)
            {
                return num;
            }

            Write($"{(SocketError)num} {bytesTransferred}");

            //try
            //{
            //    if (bufferCount == 0)
            //    {
            //        return num;
            //    }

            //    var array = new byte[buffer.Length];
            //    Marshal.Copy(buffer.Pointer, array, 0, buffer.Length);

            //    Write($"{Encoding.Default.GetString(array)}");

            //byte[] buffer = pBuffer.GetBytes(num);

            //Packet packet = new Packet
            //{
            //    Sender = "RecvFrom",
            //    Buffer = buffer,
            //    Source = socket.GetSourceIPEndPoint(),
            //    Destination = socket.GetDestinationIPEndPoint(),
            //    Socket = socket,
            //    Direction = DIRECTION.IN
            //};

            //NetProcessor.ProcessRecv(packet);

            //}
            //catch (Exception)
            //{


            //}



            //try
            //{
            //    foreach (WSABuffer Buffer in lpBuffers)
            //    {
            //        byte[] array = Buffer.Pointer.GetBytes((int)Buffer.Length);
            //        Write(Encoding.Default.GetString(array));
            //    }
            //}
            //catch (Exception)
            //{

            //}
            //if (lpNumberOfBytesRecvd <= 0)
            //{
            //    return num;
            //}
            //byte[] array = lpBuffers.GetBytes((int)lpNumberOfBytesRecvd);

            //Packet packet = new Packet
            //{
            //    Buffer = array,
            //    Source = s.GetSourceIPEndPoint(),
            //    Destination = s.GetDestinationIPEndPoint(),
            //    Length = num,
            //    Socket = (int)s
            //};

            //RecvProcessor.Process(packet);

            return num;
        }

    }
}

#if !XB1
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using SKYNET.Hook.Types;

namespace VRage
{
    public class MyTryConnectHelper
    {



        
        static bool Initialized;
        static FieldInfo m_Buffer;
        public static bool TryConnect(string ipString, int port)
        {
            if (!Initialized)
            {
                var wsaData = new WSAData();
                if (WinSockHelper.WSAStartup(0x0202, out wsaData) != 0) return false;
                m_Buffer = typeof(SocketAddress).GetField("m_Buffer", (BindingFlags.Instance | BindingFlags.NonPublic));
                Initialized = true;
            }
            IPAddress address;
            if (!IPAddress.TryParse(ipString, out address)) return false;
            if (!((port >= IPEndPoint.MinPort) && (port <= IPEndPoint.MaxPort))) return false;
            var remoteEP = new IPEndPoint(address, port);
            SocketAddress socketAddress = remoteEP.Serialize();
            IntPtr m_Handle = WinSockHelper.WSASocket(AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, ProtocolType.Tcp, IntPtr.Zero, 0, 1 /*overlapped*/);
            if (m_Handle == new IntPtr(-1)) return false;
            new SocketPermission(NetworkAccess.Connect, TransportType.Tcp, remoteEP.Address.ToString(), remoteEP.Port).Demand();
            var buf = (byte[])m_Buffer.GetValue(socketAddress);

            GCHandle sockAddrHandle = GCHandle.Alloc(buf, GCHandleType.Pinned);
            for (int i = 0; i < socketAddress.Size; ++i)
            {
                buf[i] = socketAddress[i];
            }
            IntPtr addr = sockAddrHandle.AddrOfPinnedObject();

            bool result = (WinSockHelper.WSAConnect(m_Handle, addr, socketAddress.Size, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero) == 0);
            //WinSockHelper.closesocket(m_Handle);
            return result;
        }
    }
}
#endif // !XB1

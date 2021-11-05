using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The connect function establishes a connection to a specified socket.
    /// </summary>
    public class ConnectToProxy : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int ConnectDelegate(IntPtr s, IntPtr addr, int addrsize);
        //ConnectDelegate _Connect;

        private delegate int WinsockConnectDelegate(IntPtr s, IntPtr addr, int addrsize);
        WinsockConnectDelegate _Connect;

        private object wSockLock = new object();

        public override string Library => "ws2_32.dll";
        public override string Method => "connect";
        public override LocalHook Hook { get; set; }
        public override Color Color => Color.Coral;
        public override Delegate Delegate
        {
            get
            {
                _Connect = Marshal.GetDelegateForFunctionPointer<WinsockConnectDelegate>(ProcAddress);
                return new WinsockConnectDelegate(WinsockConnectDetour);
            }
        }

        private int WinsockConnectDetour(IntPtr s, IntPtr sockAddr, int addrsize)
        {
            //SockAddr addr_in = Marshal.PtrToStructure<SockAddr>(sockAddr);
            //string originalIp = addr_in.IPAddress.ToString();
            //string originalPort = Ws2_32.ntohs(addr_in.Port).ToString();

            //string RedirectedIP = Main.GetRedirectedIP(originalIp);
            //string RedirectedPort = Main.GetRedirectedPort(originalPort);

            //var nAddr = WinSockHelper.CreateAddr(RedirectedIP, "28000");

            ////Write($"Binding to {bindIn.Address?.IPAddress}:{bindIn.Port} ...");

            //Write($"Binding connection from: {originalIp}:{originalPort} to: {RedirectedIP}:{RedirectedPort}");

            //IntPtr o = WinSockHelper.CreateSockaddrStructure (new IPEndPoint(IPAddress.Parse(RedirectedIP), int.Parse(originalPort)), out _);

            //IntPtr newSock = OpenSocket( AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, ProtocolType.Tcp);

            //return _Connect(newSock, o, 16);

            return 0;

            //return _Connect(s, o, size);
            //var result = Bind(s, ref o, size);
            //var sd = Ws2_32.WSAGetLastError();
            //Write(sd);
            //return (int)result;
        }

        [DllImport("ws2_32", SetLastError = true, EntryPoint = "socket")]
        public static extern IntPtr OpenSocket(AddressFamily addressFamily, System.Net.Sockets.SocketType type, ProtocolType protocol);


        [DllImport("ws2_32", SetLastError = true, EntryPoint = "bind")]
        public static extern SocketError Bind(IntPtr socket, ref IntPtr address, int addressSize);

        public static IntPtr CreateSockaddrStructure(IPEndPoint ipEndPoint, out int size)
        {
            SocketAddress socketAddress = ipEndPoint.Serialize();
            size = socketAddress.Size;

            // use an array of bytes instead of the sockaddr structure 
            byte[] sockAddrStructureBytes = new byte[socketAddress.Size];
            GCHandle sockAddrHandle = GCHandle.Alloc(sockAddrStructureBytes, GCHandleType.Pinned);
            for (int i = 0; i < socketAddress.Size; ++i)
            {
                sockAddrStructureBytes[i] = socketAddress[i];
            }

            IntPtr pIpPort = sockAddrHandle.AddrOfPinnedObject();
            return pIpPort;
        }









































        /////////////////////////////////////////////////////////////////// NEW
        private ISocketAddress GetSocketAddress(IntPtr socketAddressPointer)
        {
            if (socketAddressPointer == IntPtr.Zero)
            {
                return null;
            }

            try
            {
                var socketAddress = Marshal.PtrToStructure<SocketAddress>(socketAddressPointer);

                Type type;

                switch (socketAddress.Family)
                {
                    case AddressFamily.InterNetwork:
                        {
                            type = typeof(SocketAddressIn);

                            break;
                        }
                    case AddressFamily.InterNetworkV6:
                        {
                            type = typeof(SocketAddressIn6);

                            break;
                        }
                    default:

                        return null;
                }

                return (ISocketAddress)Marshal.PtrToStructure(socketAddressPointer, type);
            }
            catch
            {
                return null;
            }
        }
        public interface ISocketAddress
        {
            IAddressIn Address { get; }
            AddressFamily AddressFamily { get; set; }
            int Port { get; set; }
        }
        public interface IAddressIn
        {
            IPAddress IPAddress { get; set; }
        }
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public struct SocketAddressBase
        {
            [FieldOffset(0)] private ushort family;

            public AddressFamily Family
            {
                get => (AddressFamily)family;

                set => family = (ushort)value;
            }
        }
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public struct SocketAddressIn : ISocketAddress
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            [FieldOffset(8)]
            private readonly byte[] Padding;

            [FieldOffset(4)] private AddressIn address;

            [FieldOffset(0)] private ushort family;

            [FieldOffset(2)] private short port;

            /// <inheritdoc />
            public int Port
            {
                get => System.Net.IPAddress.NetworkToHostOrder(port);
                set => port = System.Net.IPAddress.HostToNetworkOrder((short)value);
            }

            /// <inheritdoc />
            public IAddressIn Address
            {
                get => address;
                set => address = (AddressIn)value;
            }

            /// <inheritdoc />
            public AddressFamily AddressFamily
            {
                get => (AddressFamily)family;

                set => family = (ushort)value;
            }
        }
        [StructLayout(LayoutKind.Explicit, Size = 28)]
        public struct SocketAddressIn6 : ISocketAddress
        {
            [FieldOffset(8)] private AddressIn6 address;

            [FieldOffset(0)] private ushort family;

            [FieldOffset(2)] private short port;

            [FieldOffset(4)] private uint flowInfo;

            [FieldOffset(24)] private uint scopeId;

            /// <inheritdoc />
            public int Port
            {
                get => IPAddress.NetworkToHostOrder(port);
                set => port = IPAddress.HostToNetworkOrder((short)value);
            }

            public uint FlowInfo
            {
                get => flowInfo;
                set => flowInfo = value;
            }

            public uint ScopeId
            {
                get => scopeId;
                set => scopeId = value;
            }

            /// <inheritdoc />
            public AddressFamily AddressFamily
            {
                get => (AddressFamily)family;

                set => family = (ushort)value;
            }

            /// <inheritdoc />
            public IAddressIn Address
            {
                get => address;
                set => address = (AddressIn6)value;
            }
        }
        [StructLayout(LayoutKind.Explicit, Size = 4)]
        public struct AddressIn : IAddressIn
        {
            [FieldOffset(0)] private uint Value;

            /// <inheritdoc />
            public IPAddress IPAddress
            {
                get => new IPAddress(Value);
                set => Value = BitConverter.ToUInt32(value.GetAddressBytes(), 0);
            }
        }
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        public struct AddressIn6 : IAddressIn
        {
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            private byte[] Bytes;

            public IPAddress IPAddress
            {
                get => new IPAddress(Bytes);
                set => Bytes = value.GetAddressBytes();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Helper
{
    public class ManagedHelper
    {
        internal static IntPtr GetSocketPtr(IPEndPoint Endpoint, AddressFamily family = AddressFamily.InterNetwork)
        {
            SocketAddressIn addr = new SocketAddressIn();
            addr.Address = new AddressIn()
            {
                IPAddress = Endpoint.Address
            };
            addr.Port = Endpoint.Port;
            addr.AddressFamily = family;

            IntPtr response = IntPtr.Zero;
            Marshal.StructureToPtr(addr, response, true);
            return response;
        }
        public static ISocketAddress GetSocketAddress(IntPtr socketAddressPointer)
        {
            if (socketAddressPointer == IntPtr.Zero)
            {
                return null;
            }

            try
            {
                var socketAddress = Marshal.PtrToStructure<SocketAddressBase>(socketAddressPointer);

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
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct SocketAddressBase
        {
            [FieldOffset(0)] private ushort family;

            public AddressFamily Family
            {
                get => (AddressFamily)family;

                set => family = (ushort)value;
            }
        }
        public interface ISocketAddress
        {
            IAddressIn Address { get; }
            AddressFamily AddressFamily { get; set; }
            int Port { get; set; }
        }
        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct SocketAddressIn : ISocketAddress
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
        internal struct SocketAddressIn6 : ISocketAddress
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
        public interface IAddressIn
        {
            IPAddress IPAddress { get; set; }
        }
        [StructLayout(LayoutKind.Explicit, Size = 4)]
        internal struct AddressIn : IAddressIn
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
        internal struct AddressIn6 : IAddressIn
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

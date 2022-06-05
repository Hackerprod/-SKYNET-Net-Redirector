using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Win32.SafeHandles;
using SKYNET.Helper;

namespace SKYNET.Hook.Types
{
    public static class WinSockHelper
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SOCKADDR_IN
        {
            public short sin_family;
            public ushort sin_port;
            public uint sin_addr;
            public long sin_zero;
        }

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern int getsockname(IntPtr socketHandle, ref SOCKADDR_IN socketAddress, ref int socketAddressSize);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError getpeername(
                                            IntPtr socketHandle,
                                            ref SOCKADDR_IN socketAddress,
                                            ref int socketAddressSize
                                            );


        [DllImport("ws2_32.dll", SetLastError = true, EntryPoint = "socket")]
        public static extern IntPtr OpenSocket(AddressFamily addressFamily, System.Net.Sockets.SocketType type, ProtocolType protocol);

        [DllImport("ws2_32.dll", SetLastError = true, EntryPoint = "connect")]
        public static extern IntPtr Connect(IntPtr s, IntPtr addr, int addrsize);

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern int WSAConnect(
        [In] IntPtr socketHandle,
        [In] IntPtr socketAddress,
        [In] int socketAddressSize,
        [In] IntPtr inBuffer,
        [In] IntPtr outBuffer,
        [In] IntPtr sQOS,
        [In] IntPtr gQOS
        );
        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr WSASocket(
        [In] AddressFamily addressFamily,
        [In] System.Net.Sockets.SocketType socketType,
        [In] ProtocolType protocolType,
        [In] IntPtr protocolInfo,
        [In] uint group,
        [In] int flags
        );
        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern int WSAStartup(
        [In] short wVersionRequested,
        [Out] out WSAData lpWSAData
        );
        [DllImport("ws2_32.dll", ExactSpelling = true, SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        internal static extern int closesocket(
        [In] IntPtr socketHandle
        );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal unsafe static extern int send(
                                     [In] IntPtr socketHandle,
                                     [In] IntPtr pinnedBuffer,
                                     [In] int len,
                                     [In] SocketFlags socketFlags
                                     );

        public static IntPtr CreateAddr(IPEndPoint EndPoint)
        {
            return CreateAddr(EndPoint.Address.ToString(), EndPoint.Port); ;
        }
        public static IntPtr CreateAddr(string ip, int port)
        {
            var s = Marshal.AllocHGlobal(16);
            SOCKADDR_IN sockAddr = new SOCKADDR_IN();
            sockAddr.sin_family = (int)AddressFamily.InterNetwork;
            sockAddr.sin_addr = Ws2_32.inet_addr(ip);
            sockAddr.sin_port = Ws2_32.htons((ushort)port);

            Marshal.StructureToPtr(sockAddr, s, true);
            return s;
        }
        public static IPEndPoint GetEndPoint(this SOCKADDR_IN sockAddr)
        {
            IPAddress Address = new IPAddress(sockAddr.sin_addr);
            int Port = Ws2_32.ntohs(sockAddr.sin_port);
            return new IPEndPoint(Address, Port);
        }
        public static IPEndPoint GetEndPoint(this IntPtr sockAddr)
        {
            SOCKADDR_IN addr_in = Marshal.PtrToStructure<SOCKADDR_IN>(sockAddr);
            return addr_in.GetEndPoint();
        }
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
        public static unsafe AddressInfoW CreateAddressInfoW(string Host)
        {
            //Variant 2
            IntPtr addr_2 = CreateAddr(Host, 25000); int size_2 = 16;
            //Variant 3
            IntPtr addr_3 = CreateSockaddrStructure(new IPEndPoint(IPAddress.Parse(Host), 80), out int size_3);

            AddressInfoW AltNetOut = new AddressInfoW();

            //AltNetOut.ai_canonname = GetChar(RedirectedHost + '\0');
            AltNetOut.ai_family = 2;
            AltNetOut.ai_flags = ADDRINFO_FLAGS.AI_NUMERICHOST;
            AltNetOut.ai_protocol = 6;
            AltNetOut.ai_socktype = 1;
            AltNetOut.ai_addr = addr_2;
            AltNetOut.ai_addrlen = (uint)size_2;
            AltNetOut.ai_next = null;

            return AltNetOut;
        }

        public static IPEndPoint ReadSockaddrStructure(IntPtr pSockaddrStructure)
        {
            short sAddressFamily = Marshal.ReadInt16(pSockaddrStructure);
            AddressFamily addressFamily = (AddressFamily)sAddressFamily;

            int sockAddrSructureSize;
            IPEndPoint ipEndPointAny;
            switch (addressFamily)
            {
                case AddressFamily.InterNetwork:
                    // IP v4 address
                    sockAddrSructureSize = 16;
                    ipEndPointAny = new IPEndPoint(IPAddress.Any, 0);
                    break;
                case AddressFamily.InterNetworkV6:
                    // IP v6 address
                    sockAddrSructureSize = 28;
                    ipEndPointAny = new IPEndPoint(IPAddress.IPv6Any, 0);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pSockaddrStructure), "Unknown address family");
            }


            // get bytes of the sockadrr structure
            byte[] sockAddrSructureBytes = new byte[sockAddrSructureSize];
            Marshal.Copy(pSockaddrStructure, sockAddrSructureBytes, 0, sockAddrSructureSize);

            // create SocketAddress from bytes
            var socketAddress = new SocketAddress(AddressFamily.Unspecified, sockAddrSructureSize);
            for (int i = 0; i < sockAddrSructureSize; i++)
            {
                socketAddress[i] = sockAddrSructureBytes[i];
            }

            // create IPEndPoint from SocketAddress
            IPEndPoint result = (IPEndPoint)ipEndPointAny.Create(socketAddress);
            return result;
        }

    }
    public struct AddressInfoW
    {
        internal ADDRINFO_FLAGS ai_flags;

        internal int ai_family;

        internal int ai_socktype;

        internal int ai_protocol;

        internal uint ai_addrlen;

        internal IntPtr ai_canonname;

        internal IntPtr ai_addr;

        internal unsafe AddressInfoW* ai_next;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct WSAData
    {
        internal short wVersion;
        internal short wHighVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
        internal string szDescription;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
        internal string szSystemStatus;
        internal short iMaxSockets;
        internal short iMaxUdpDg;
        internal IntPtr lpVendorInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct Linger
    {
        internal ushort OnOff; // option on/off
        internal ushort Time; // linger time
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ChainPolicyStatus
    {
        public uint cbSize;
        public uint dwError;
        public uint lChainIndex;
        public uint lElementIndex;
        public void* pvExtraPolicyStatus;

        public static readonly uint StructSize = (uint)Marshal.SizeOf(typeof(ChainPolicyStatus));
    }
    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct ChainPolicyParameter
    {
        public uint cbSize;
        public uint dwFlags;
        public SSL_EXTRA_CERT_CHAIN_POLICY_PARA* pvExtraPolicyPara;

        public static readonly uint StructSize = (uint)Marshal.SizeOf(typeof(ChainPolicyParameter));
    }
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SSL_EXTRA_CERT_CHAIN_POLICY_PARA
    {

        [StructLayout(LayoutKind.Explicit)]
        public struct U
        {
            [FieldOffset(0)] internal uint cbStruct;  //DWORD
            [FieldOffset(0)] internal uint cbSize;    //DWORD
        };
        public U u;
        public int dwAuthType;  //DWORD
        public uint fdwChecks;   //DWORD
        public char* pwszServerName; //WCHAR* // used to check against CN=xxxx

        public SSL_EXTRA_CERT_CHAIN_POLICY_PARA(bool amIServer)
        {
            u.cbStruct = StructSize;
            u.cbSize = StructSize;
            //#      define      AUTHTYPE_CLIENT         1
            //#      define      AUTHTYPE_SERVER         2
            dwAuthType = amIServer ? 1 : 2;
            fdwChecks = 0;
            pwszServerName = null;
        }
        public static readonly uint StructSize = (uint)Marshal.SizeOf(typeof(SSL_EXTRA_CERT_CHAIN_POLICY_PARA));
    }
}
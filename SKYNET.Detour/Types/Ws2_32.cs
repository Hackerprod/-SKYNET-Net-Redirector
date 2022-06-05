using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using SKYNET.Hook.Types;

namespace SKYNET.Helper
{
    public unsafe class Ws2_32
    {
        [DllImport("ws2_32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int WSAGetLastError();

        [DllImport("Ws2_32.dll")]
        public static extern ushort ntohs(ushort netshort);

        [DllImport("Ws2_32.dll")]
        public static extern ushort htons(ushort hostshort);

        [DllImport("ws2_32.dll", ExactSpelling = true, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern int getaddrinfo(
            [In] string nodename,
            [In] string servicename,
            [In] ref AddressInfo hints,
            [Out] out SafeFreeAddrInfo handle
            );

        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern SocketError WSAStartup(
                                   [In] short wVersionRequested,
                                   [Out] out WSAData lpWSAData
                                   );

        [DllImport("ws2_32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal static extern SocketError ioctlsocket(
                                            [In] IntPtr socketHandle,
                                            [In] int cmd,
                                            [In, Out] ref int argp
                                            );
        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern IntPtr gethostbyname(
                                      [In] string host
                                      );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern IntPtr gethostbyaddr(
                                              [In] ref int addr,
                                              [In] int len,
                                              [In] ProtocolFamily type
                                              );

        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern SocketError gethostname([Out] StringBuilder hostName, [In] int bufferLength);
        
        // this should belong to SafeNativeMethods, but it will not for simplicity
        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        public static extern uint inet_addr([In] string cp);




        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError getpeername(
                                            [In] IntPtr socketHandle,
                                            [Out] byte[] socketAddress,
                                            [In, Out] ref int socketAddressSize
                                            );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError getsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [Out] out int optionValue,
                                           [In, Out] ref int optionLength
                                           );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError getsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [Out] byte[] optionValue,
                                           [In, Out] ref int optionLength
                                           );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError getsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [Out] out Linger optionValue,
                                           [In, Out] ref int optionLength
                                           );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError getsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [Out] out IPMulticastRequest optionValue,
                                           [In, Out] ref int optionLength
                                           );

        //
        // IPv6 Changes: need to receive and IPv6MulticastRequest from getsockopt 
        // 
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError getsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [Out] out IPv6MulticastRequest optionValue,
                                           [In, Out] ref int optionLength
                                           );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError setsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [In] ref int optionValue,
                                           [In] int optionLength
                                           );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError setsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [In] byte[] optionValue,
                                           [In] int optionLength
                                           );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError setsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [In] ref IntPtr pointer,
                                           [In] int optionLength
                                           );

        [DllImport("ws2_32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        internal static extern SocketError setsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [In] ref Linger linger,
                                           [In] int optionLength
                                           );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError setsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [In] ref IPMulticastRequest mreq,
                                           [In] int optionLength
                                           );

        // 
        // IPv6 Changes: need to pass an IPv6MulticastRequest to setsockopt
        //
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError setsockopt(
                                           [In] IntPtr socketHandle,
                                           [In] SocketOptionLevel optionLevel,
                                           [In] SocketOptionName optionName,
                                           [In] ref IPv6MulticastRequest mreq,
                                           [In] int optionLength
                                           );


        // This method is always blocking, so it uses an IntPtr.
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal unsafe static extern int send([In] IntPtr socketHandle,
                                     [In] IntPtr pinnedBuffer, [In] int len,
                                     [In] SocketFlags socketFlags);

        // This method is always blocking, so it uses an IntPtr.
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal unsafe static extern int recv(
                                     [In] IntPtr socketHandle,
                                     [In] IntPtr pinnedBuffer,
                                     [In] int len,
                                     [In] SocketFlags socketFlags
                                     );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError listen(
                                       [In] IntPtr socketHandle,
                                       [In] int backlog
                                       );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError bind(
                                     [In] IntPtr socketHandle,
                                     [In] byte[] socketAddress,
                                     [In] int socketAddressSize
                                     );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError shutdown(
                                         [In] IntPtr socketHandle,
                                         [In] int how
                                         );

        // This method is always blocking, so it uses an IntPtr.
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal unsafe static extern int sendto(
                                       [In] IntPtr socketHandle,
                                       [In] byte* pinnedBuffer,
                                       [In] int len,
                                       [In] SocketFlags socketFlags,
                                       [In] byte[] socketAddress,
                                       [In] int socketAddressSize
                                       );

        // This method is always blocking, so it uses an IntPtr.
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal unsafe static extern int recvfrom(
                                         [In] IntPtr socketHandle,
                                         [In] byte* pinnedBuffer,
                                         [In] int len,
                                         [In] SocketFlags socketFlags,
                                         [Out] byte[] socketAddress,
                                         [In, Out] ref int socketAddressSize
                                         );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError getsockname(
                                            [In] IntPtr socketHandle,
                                            [Out] byte[] socketAddress,
                                            [In, Out] ref int socketAddressSize
                                            );
        [DllImport("ws2_32.dll")]
        internal static extern int getpeername(IntPtr socketHandle, ref sockaddr socketAddress, ref int socketAddressSize);

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern int getsockname(IntPtr socketHandle, ref sockaddr socketAddress, ref int socketAddressSize);


        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern int select(
                                       [In] int ignoredParameter,
                                       [In, Out] IntPtr[] readfds,
                                       [In, Out] IntPtr[] writefds,
                                       [In, Out] IntPtr[] exceptfds,
                                       [In] ref TimeValue timeout
                                       );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern int select(
                                       [In] int ignoredParameter,
                                       [In, Out] IntPtr[] readfds,
                                       [In, Out] IntPtr[] writefds,
                                       [In, Out] IntPtr[] exceptfds,
                                       [In] IntPtr nullTimeout
                                       );

        // This function is always potentially blocking so it uses an IntPtr.
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSAConnect(
                                          [In] IntPtr socketHandle,
                                          [In] byte[] socketAddress,
                                          [In] int socketAddressSize,
                                          [In] IntPtr inBuffer,
                                          [In] IntPtr outBuffer,
                                          [In] IntPtr sQOS,
                                          [In] IntPtr gQOS
                                          );


        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSASend(
                                          [In] IntPtr socketHandle,
                                          [In] ref WSABuffer buffer,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred,
                                          [In] SocketFlags socketFlags,
                                          [In] IntPtr overlapped,
                                          [In] IntPtr completionRoutine
                                          );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSASend(
                                          [In] IntPtr socketHandle,
                                          [In] WSABuffer[] buffersArray,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred,
                                          [In] SocketFlags socketFlags,
                                          [In] IntPtr overlapped,
                                          [In] IntPtr completionRoutine
                                          );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSASend(
                                          [In] IntPtr socketHandle,
                                          [In] IntPtr buffers,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred,
                                          [In] SocketFlags socketFlags,
                                          [In] IntPtr overlapped,
                                          [In] IntPtr completionRoutine
                                          );

        [DllImport("ws2_32.dll", SetLastError = true, EntryPoint = "WSASend")]
        internal static extern SocketError WSASend_Blocking(
                                          [In] IntPtr socketHandle,
                                          [In] WSABuffer[] buffersArray,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred,
                                          [In] SocketFlags socketFlags,
                                          [In] IntPtr overlapped,
                                          [In] IntPtr completionRoutine
                                          );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSASendTo(
                                          [In] IntPtr socketHandle,
                                                [In] WSABuffer[] buffersArray,
                                                [In] int bufferCount,
                                                [Out] out int bytesTransferred,
                                                [In] SocketFlags socketFlags,
                                                [In] IntPtr socketAddress,
                                                [In] int socketAddressSize,
                                                [In] SafeNativeOverlapped overlapped,
                                                [In] IntPtr completionRoutine);

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSASendTo(
                                            [In] IntPtr socketHandle,
                                            [In] WSABuffer[] buffersArray,
                                            [In] int bufferCount,
                                            [Out] out int bytesTransferred,
                                            [In] SocketFlags socketFlags,
                                            [In] IntPtr socketAddress,
                                            [In] int socketAddressSize,
                                            [In] IntPtr overlapped,
                                            [In] IntPtr completionRoutine
                                            );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSARecv(
                                          [In] IntPtr socketHandle,
                                          [In, Out] ref WSABuffer buffer,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred,
                                          [In, Out] ref SocketFlags socketFlags,
                                          [In] IntPtr overlapped,
                                          [In] IntPtr completionRoutine
                                          );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSARecv(
                                          [In] IntPtr socketHandle,
                                          [In, Out] WSABuffer[] buffers,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred,
                                          [In, Out] ref SocketFlags socketFlags,
                                          [In] IntPtr overlapped,
                                          [In] IntPtr completionRoutine
                                          );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSARecv(
                                          [In] IntPtr socketHandle,
                                          [In] IntPtr buffers,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred,
                                          [In, Out] ref SocketFlags socketFlags,
                                          [In] IntPtr overlapped,
                                          [In] IntPtr completionRoutine
                                          );

        /* Consider removing 
        [DllImport("ws2_32.dll", SetLastError = true, EntryPoint = "WSARecv")]
        internal static extern SocketError WSARecv_Blocking( 
                                          [In] IntPtr socketHandle,
                                          [In, Out] ref WSABuffer buffer,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred, 
                                          [In, Out] ref SocketFlags socketFlags,
                                          [In] IntPtr overlapped, 
                                          [In] IntPtr completionRoutine 
                                          );
        */

        [DllImport("ws2_32.dll", SetLastError = true, EntryPoint = "WSARecv")]
        internal static extern SocketError WSARecv_Blocking(
                                          [In] IntPtr socketHandle,
                                          [In, Out] WSABuffer[] buffers,
                                          [In] int bufferCount,
                                          [Out] out int bytesTransferred,
                                          [In, Out] ref SocketFlags socketFlags,
                                          [In] IntPtr overlapped,
                                          [In] IntPtr completionRoutine
                                          );


        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSARecvFrom(
                                              [In] IntPtr socketHandle,
                                              [In, Out] WSABuffer[] buffers,
                                              [In] int bufferCount,
                                              [Out] out int bytesTransferred,
                                              [In, Out] ref SocketFlags socketFlags,
                                              [In] IntPtr socketAddressPointer,
                                              [In] IntPtr socketAddressSizePointer,
                                              [In] IntPtr overlapped,
                                              [In] IntPtr completionRoutine
                                              );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSAEventSelect(
                                                 [In] IntPtr socketHandle,
                                                 [In] SafeHandle Event,
                                                 [In] AsyncEventBits NetworkEvents
                                                 );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSAEventSelect(
                                     [In] IntPtr socketHandle,
                                     [In] IntPtr Event,
                                     [In] AsyncEventBits NetworkEvents
                                     );


        // Used with SIOGETEXTENSIONFUNCTIONPOINTER - we're assuming that will never block. 
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSAIoctl(
                                            [In] IntPtr socketHandle,
                                            [In] int ioControlCode,
                                            [In, Out] ref Guid guid,
                                            [In] int guidSize,
                                            [Out] out IntPtr funcPtr,
                                            [In]  int funcPtrSize,
                                            [Out] out int bytesTransferred,
                                            [In] IntPtr shouldBeNull,
                                            [In] IntPtr shouldBeNull2
                                            );

        [DllImport("ws2_32.dll", SetLastError = true, EntryPoint = "WSAIoctl")]
        internal static extern SocketError WSAIoctl_Blocking(
                                            [In] IntPtr socketHandle,
                                            [In] int ioControlCode,
                                            [In] byte[] inBuffer,
                                            [In] int inBufferSize,
                                            [Out] byte[] outBuffer,
                                            [In] int outBufferSize,
                                            [Out] out int bytesTransferred,
                                            [In] IntPtr overlapped,
                                            [In] IntPtr completionRoutine
                                            );

        [DllImport("ws2_32.dll", SetLastError = true, EntryPoint = "WSAIoctl")]
        internal static extern SocketError WSAIoctl_Blocking_Internal(
                                            [In]  IntPtr socketHandle,
                                            [In]  uint ioControlCode,
                                            [In]  IntPtr inBuffer,
                                            [In]  int inBufferSize,
                                            [Out] IntPtr outBuffer,
                                            [In]  int outBufferSize,
                                            [Out] out int bytesTransferred,
                                            [In]  IntPtr overlapped,
                                            [In]  IntPtr completionRoutine
                                            );

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern SocketError WSAEnumNetworkEvents(
                                                 [In] IntPtr socketHandle,
                                                 [In] SafeWaitHandle Event,
                                                 [In, Out] ref NetworkEvents networkEvents
                                                 );

#if !FEATURE_PAL
        [DllImport("ws2_32.dll", SetLastError = true)]
        internal unsafe static extern int WSADuplicateSocket(
            [In] IntPtr socketHandle,
            [In] uint targetProcessID,
            [In] byte* pinnedBuffer
        );
#endif // !FEATURE_PAL 

        [DllImport("ws2_32.dll", SetLastError = true)]
        internal static extern bool WSAGetOverlappedResult(
                                                 [In] IntPtr socketHandle,
                                                 [In] IntPtr overlapped,
                                                 [Out] out uint bytesTransferred,
                                                 [In] bool wait,
                                                 [Out] out SocketFlags socketFlags
                                                 );
#if !FEATURE_PAL
        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern SocketError WSAStringToAddress(
            [In] string addressString,
            [In] AddressFamily addressFamily,
            [In] IntPtr lpProtocolInfo, // always passing in a 0 
            [Out] byte[] socketAddress,
            [In, Out] ref int socketAddressSize);

        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern SocketError WSAAddressToString(
            [In] byte[] socketAddress,
            [In] int socketAddressSize,
            [In] IntPtr lpProtocolInfo,// always passing in a 0
            [Out]StringBuilder addressString,
            [In, Out] ref int addressStringLength);

        [DllImport("ws2_32.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
        internal static extern SocketError getnameinfo(
            [In]         byte[] sa,
            [In]         int salen,
            [In, Out]     StringBuilder host,
            [In]         int hostlen,
            [In, Out]     StringBuilder serv,
            [In]         int servlen,
            [In]         int flags);

        //if we change this back to auto, we also have to change
        //WSAPROTOCOL_INFO and WSAPROTOCOLCHAIN
        [DllImport("ws2_32.dll", SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false)]
        internal static extern int WSAEnumProtocols(
                                                    [MarshalAs(UnmanagedType.LPArray)]
                                                        [In] int[]     lpiProtocols,
                                                    [In] SafeLocalFree lpProtocolBuffer,
                                                    [In][Out] ref uint lpdwBufferLength
                       );
        internal class SafeLocalFree
        {
        }



        internal interface IPv6MulticastRequest
        {
        }

        internal class IPMulticastRequest
        {
        }


        internal class SafeNativeOverlapped
        {
        }



        internal class SafeFreeAddrInfo
        {
        }

        public class AddressInfo
        {
        }
        internal class AsyncEventBits
        {
        }
        internal class TimeValue
        {
        }
        internal class NetworkEvents
        {
        }

#endif // !FEATURE_PAL 


















        [DllImport("ws2_32.dll", ExactSpelling = true)]
        public static extern void FreeAddrInfoW(IntPtr pAddrInfo);



    }


    internal struct sockaddr
    {
        public short sin_family;

        public ushort sin_port;

        public in_addr sin_addr;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] sin_zero;
    }
    internal struct in_addr
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] sin_addr;
    }

}

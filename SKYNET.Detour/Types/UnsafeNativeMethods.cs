//------------------------------------------------------------------------------ 
// <copyright file="UnsafeNativeMethods.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//----------------------------------------------------------------------------- 

namespace System.Net
{
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;
    using System.Text;
    using System.Net.Sockets;
    using System.Net.Cache;
    using System.Threading;
    using System.ComponentModel;
    using System.Collections;
    using System.Globalization;
    using System.Runtime.ConstrainedExecution;
    using System.Security;
    using Microsoft.Win32.SafeHandles;
    using System.Runtime.Versioning;
    using System.Diagnostics.CodeAnalysis;
    using static SKYNET.Helper.Ws2_32;
    using SKYNET.Hook.Types;
    using SKYNET;

    [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
    internal static class UnsafeNclNativeMethods
    {
        private const string CRYPT32 = "crypt32.dll";
        private const string ADVAPI32 = "advapi32.dll";
        private const string WININET = "wininet.dll";
        private const string WS2_32 = "ws2_32.dll";
        private const string mswsock = "mswsock.dll";
        private const string KERNEL32 = "kernel32.dll";

        [DllImport(KERNEL32)]
        internal static extern IntPtr CreateSemaphore([In] IntPtr lpSemaphoreAttributes, [In] int lInitialCount, [In] int lMaximumCount, [In] IntPtr lpName);

        [DllImport(KERNEL32)]
        internal static extern bool ReleaseSemaphore([In] IntPtr hSemaphore, [In] int lReleaseCount, [Out] out int lpPreviousCount);

        //
        internal static class ErrorCodes
        {
            internal const uint ERROR_SUCCESS = 0;
            internal const uint ERROR_HANDLE_EOF = 38;
            internal const uint ERROR_NOT_SUPPORTED = 50;
            internal const uint ERROR_INVALID_PARAMETER = 87;
            internal const uint ERROR_ALREADY_EXISTS = 183;
            internal const uint ERROR_MORE_DATA = 234;
            internal const uint ERROR_OPERATION_ABORTED = 995;
            internal const uint ERROR_IO_PENDING = 997;
            internal const uint ERROR_NOT_FOUND = 1168;
        }

        internal static class NTStatus
        {
            internal const uint STATUS_SUCCESS = 0x00000000;
            internal const uint STATUS_OBJECT_NAME_NOT_FOUND = 0xC0000034;
        }

        [DllImport(KERNEL32, ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        internal static extern uint GetCurrentThreadId();

        [SuppressUnmanagedCodeSecurity]
        internal unsafe static class RegistryHelper
        {
            internal const uint REG_NOTIFY_CHANGE_LAST_SET = 4;
            internal const uint REG_BINARY = 3;
            internal const uint KEY_READ = 0x00020019;

            internal static readonly IntPtr HKEY_CURRENT_USER = (IntPtr)unchecked((int)0x80000001L);
            internal static readonly IntPtr HKEY_LOCAL_MACHINE = (IntPtr)unchecked((int)0x80000002L);

            // RELIABILITY: 
            // this out parameter in this API, resultSubKey, is an allocated handle to a registry sub-key.
            // it must be a SafeHandle so we can guarantee that it is released correctly and never leaked. 
            [DllImport(ADVAPI32, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern uint RegOpenKeyEx(IntPtr key, string subKey, uint ulOptions, uint samDesired, out SafeRegistryHandle resultSubKey);

            [DllImport(ADVAPI32, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern uint RegOpenKeyEx(SafeRegistryHandle key, string subKey, uint ulOptions, uint samDesired, out SafeRegistryHandle resultSubKey);

            [DllImport(ADVAPI32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern uint RegCloseKey(IntPtr key);

            [DllImport(ADVAPI32, ExactSpelling = true, SetLastError = true)]
            internal static extern uint RegNotifyChangeKeyValue(SafeRegistryHandle key, bool watchSubTree, uint notifyFilter, SafeWaitHandle regEvent, bool async);

            [DllImport(ADVAPI32, ExactSpelling = true, SetLastError = true)]
            internal static extern uint RegOpenCurrentUser(uint samDesired, out SafeRegistryHandle resultKey);

            [DllImport(ADVAPI32, BestFitMapping = false, ThrowOnUnmappableChar = true, ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern uint RegQueryValueEx(SafeRegistryHandle key, string valueName, IntPtr reserved, out uint type, [Out] byte[] data, [In][Out] ref uint size);
        }





        [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
        internal static class SafeNetHandles
        {


            [DllImport(KERNEL32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern bool CloseHandle(IntPtr handle);

            [DllImport(KERNEL32, ExactSpelling = true, SetLastError = true)]
            internal static extern SafeLocalFree LocalAlloc(int uFlags, UIntPtr sizetdwBytes);

            [DllImport(KERNEL32, EntryPoint = "LocalAlloc", SetLastError = true)]
            internal static extern IntPtr LocalAllocChannelBinding(int uFlags, UIntPtr sizetdwBytes);

            [DllImport(KERNEL32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern IntPtr LocalFree(IntPtr handle);

            [DllImport(KERNEL32, ExactSpelling = true, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern unsafe IntPtr LoadLibraryExA([In] string lpwLibFileName, [In] void* hFile, [In] uint dwFlags);

            [DllImport(KERNEL32, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern unsafe IntPtr LoadLibraryExW([In] string lpwLibFileName, [In] void* hFile, [In] uint dwFlags);


            [DllImport(KERNEL32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern unsafe bool FreeLibrary([In] IntPtr hModule);

#if !FEATURE_PAL

            /* 
            // Consider removing.
            [DllImport(CRYPT32, ExactSpelling=true, SetLastError=true)] 
            internal static extern  bool CertGetCertificateChain( 
                [In] IntPtr                 chainEngine,
                [In] SafeFreeCertContext    certContext, 
                [In] IntPtr                 time,
                [In] SafeCloseStore         additionalStore,
                [In] ref ChainParameters    certCP,
                [In] int                    flags, 
                [In] IntPtr                 reserved,
                [Out] out SafeFreeCertChain  chainContext); 
            */

            [DllImport(CRYPT32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern void CertFreeCertificateChain(
                [In] IntPtr pChainContext);

            [DllImport(CRYPT32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern bool CertFreeCertificateContext(      // Suppressing returned status check, it's always==TRUE, 
                [In] IntPtr certContext);

            /*
            // Consider removing.
            [DllImport(CRYPT32, ExactSpelling=true, SetLastError=true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] 
            internal static extern bool CertCloseStore(
                [In] IntPtr hCertStore, 
                [In] int dwFlags); 
            */

#endif // !FEATURE_PAL

            [DllImport(KERNEL32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern IntPtr GlobalFree(IntPtr handle);

            // Blocking call - requires IntPtr instead of IntPtr. 
            [DllImport(WS2_32, ExactSpelling = true, SetLastError = true)]
            internal static extern IntPtr accept(
                                                  [In] IntPtr socketHandle,
                                                  [Out] byte[] socketAddress,
                                                  [In, Out] ref int socketAddressSize
                                                  );

            [DllImport(WS2_32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern SocketError closesocket(
                                                  [In] IntPtr socketHandle
                                                  );

            [DllImport(WS2_32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern SocketError ioctlsocket(
                                                [In] IntPtr handle,
                                                [In] int cmd,
                                                [In, Out] ref int argp
                                                );

            [DllImport(WS2_32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern SocketError WSAEventSelect(
                                                     [In] IntPtr handle,
                                                     [In] IntPtr Event,
                                                     [In] AsyncEventBits NetworkEvents
                                                     );

            [DllImport(WS2_32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern SocketError setsockopt(
                                               [In] IntPtr handle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [In] ref Linger linger,
                                               [In] int optionLength
                                               );


            [DllImport(WININET, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            unsafe internal static extern bool RetrieveUrlCacheEntryFileW(
                                            [In]      char* urlName,
                                            [In]      byte* entryPtr,               //was [Out]
                                            [In, Out] ref int entryBufSize,
                                            [In]      int dwReserved              //must be 0
                                            );

            [DllImport(WININET, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            unsafe internal static extern bool UnlockUrlCacheEntryFileW(
                                            [In]    char* urlName,
                                            [In]    int dwReserved                  //must be 0
                                            );
        }

        // 
        // UnsafeNclNativeMethods.OSSOCK class contains all Unsafe() calls and should all be protected 
        // by the appropriate SocketPermission() to connect/accept to/from remote
        // peers over the network and to perform name resolution. 
        // te following calls deal mainly with:
        // 1) socket calls
        // 2) DNS calls
        // 

        // 
        // here's a brief explanation of all possible decorations we use for PInvoke. 
        // these are used in such a way that we hope to gain maximum performance from the
        // unmanaged/managed/unmanaged transition we need to undergo when calling into winsock: 
        //
        // [In] (Note: this is similar to what msdn will show)
        // the managed data will be marshalled so that the unmanaged function can read it but even
        // if it is changed in unmanaged world, the changes won't be propagated to the managed data 
        //
        // [Out] (Note: this is similar to what msdn will show) 
        // the managed data will not be marshalled so that the unmanaged function will not see the 
        // managed data, if the data changes in unmanaged world, these changes will be propagated by
        // the marshaller to the managed data 
        //
        // objects are marshalled differently if they're:
        //
        // 1) structs 
        // for structs, by default, the whole layout is pushed on the stack as it is.
        // in order to pass a pointer to the managed layout, we need to specify either the ref or out keyword. 
        // 
        //      a) for IN and OUT:
        //      [In, Out] ref Struct ([In, Out] is optional here) 
        //
        //      b) for IN only (the managed data will be marshalled so that the unmanaged
        //      function can read it but even if it changes it the change won't be propagated
        //      to the managed struct) 
        //      [In] ref Struct
        // 
        //      c) for OUT only (the managed data will not be marshalled so that the 
        //      unmanaged function cannot read, the changes done in unmanaged code will be
        //      propagated to the managed struct) 
        //      [Out] out Struct ([Out] is optional here)
        //
        // 2) array or classes
        // for array or classes, by default, a pointer to the managed layout is passed. 
        // we don't need to specify neither the ref nor the out keyword.
        // 
        //      a) for IN and OUT: 
        //      [In, Out] byte[]
        // 
        //      b) for IN only (the managed data will be marshalled so that the unmanaged
        //      function can read it but even if it changes it the change won't be propagated
        //      to the managed struct)
        //      [In] byte[] ([In] is optional here) 
        //
        //      c) for OUT only (the managed data will not be marshalled so that the 
        //      unmanaged function cannot read, the changes done in unmanaged code will be 
        //      propagated to the managed struct)
        //      [Out] byte[] 
        //
        [System.Security.SuppressUnmanagedCodeSecurityAttribute()]
        internal static class OSSOCK
        {

            // This function is always potentially blocking so it uses an IntPtr.
            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSAConnect(
                                              [In] IntPtr socketHandle,
                                              [In] byte[] socketAddress,
                                              [In] int socketAddressSize,
                                              [In] IntPtr inBuffer,
                                              [In] IntPtr outBuffer,
                                              [In] IntPtr sQOS,
                                              [In] IntPtr gQOS
                                              );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSAConnect(
                                              [In] IntPtr socketHandle,
                                              [In] IntPtr socketAddress,
                                              [In] int socketAddressSize,
                                              [In] IntPtr inBuffer,
                                              [In] IntPtr outBuffer,
                                              [In] IntPtr sQOS,
                                              [In] IntPtr gQOS
                                              );


            //
            // IPv6 Changes: These are initialized in InitializeSockets - don't set them here or 
            //               there will be an ordering problem with the call above that will
            //               result in both being set to false ! 
            // 

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            internal struct WSAPROTOCOLCHAIN
            {
                internal int ChainLen;                                 /* the length of the chain,     */
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
                internal uint[] ChainEntries;       /* a list of dwCatalogEntryIds */
            }

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
            internal struct WSAPROTOCOL_INFO
            {
                internal uint dwServiceFlags1;
                internal uint dwServiceFlags2;
                internal uint dwServiceFlags3;
                internal uint dwServiceFlags4;
                internal uint dwProviderFlags;
                Guid ProviderId;
                internal uint dwCatalogEntryId;
                WSAPROTOCOLCHAIN ProtocolChain;
                internal int iVersion;
                internal AddressFamily iAddressFamily;
                internal int iMaxSockAddr;
                internal int iMinSockAddr;
                internal int iSocketType;
                internal int iProtocol;
                internal int iProtocolMaxOffset;
                internal int iNetworkByteOrder;
                internal int iSecurityScheme;
                internal uint dwMessageSize;
                internal uint dwProviderReserved;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
                internal string szProtocol;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct ControlData
            {
                internal UIntPtr length;
                internal uint level;
                internal uint type;
                internal uint address;
                internal uint index;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct ControlDataIPv6
            {
                internal UIntPtr length;
                internal uint level;
                internal uint type;
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
                internal byte[] address;
                internal uint index;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct WSAMsg
            {
                internal IntPtr socketAddress;
                internal uint addressLength;
                internal IntPtr buffers;
                internal uint count;
                internal WSABuffer controlBuffer;
                internal SocketFlags flags;
            }

            // 
            // Flags equivalent to winsock TRANSMIT_PACKETS_ELEMENT flags
            //    #define TP_ELEMENT_MEMORY   1 
            //    #define TP_ELEMENT_FILE     2
            //    #define TP_ELEMENT_EOP      4
            //
            [Flags]
            internal enum TransmitPacketsElementFlags : uint
            {
                None = 0x00,
                Memory = 0x01,
                File = 0x02,
                EndOfPacket = 0x04
            }

            // Structure equivalent to TRANSMIT_PACKETS_ELEMENT
            // 
            // typedef struct _TRANSMIT_PACKETS_ELEMENT {
            //     ULONG dwElFlags; 
            //     ULONG cLength; 
            //     union {
            //         struct { 
            //             LARGE_INTEGER nFileOffset;
            //             HANDLE hFile;
            //         };
            //         PVOID pBuffer; 
            //     }
            //  }; 
            // } TRANSMIT_PACKETS_ELEMENT; 
            //
            [StructLayout(LayoutKind.Explicit)]
            internal struct TransmitPacketsElement
            {
                [System.Runtime.InteropServices.FieldOffset(0)]
                internal TransmitPacketsElementFlags flags;
                [System.Runtime.InteropServices.FieldOffset(4)]
                internal uint length;
                [System.Runtime.InteropServices.FieldOffset(8)]
                internal Int64 fileOffset;
                [System.Runtime.InteropServices.FieldOffset(8)]
                internal IntPtr buffer;
                [System.Runtime.InteropServices.FieldOffset(16)]
                internal IntPtr fileHandle;
            }

            /*
               typedef struct _SOCKET_ADDRESS { 
                   PSOCKADDR lpSockaddr; 
                   INT iSockaddrLength;
               } SOCKET_ADDRESS, *PSOCKET_ADDRESS;           
            */
            [StructLayout(LayoutKind.Sequential)]
            internal struct SOCKET_ADDRESS
            {
                internal IntPtr lpSockAddr;
                internal int iSockaddrLength;
            }

            /*
               typedef struct _SOCKET_ADDRESS_LIST { 
                   INT             iAddressCount;
                   SOCKET_ADDRESS  Address[1];
               } SOCKET_ADDRESS_LIST, *PSOCKET_ADDRESS_LIST, FAR *LPSOCKET_ADDRESS_LIST;
            */
            [StructLayout(LayoutKind.Sequential)]
            internal struct SOCKET_ADDRESS_LIST
            {
                internal int iAddressCount;
                internal SOCKET_ADDRESS Addresses;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct TransmitFileBuffersStruct
            {
                internal IntPtr preBuffer;// Pointer to Buffer 
                internal int preBufferLength; // Length of Buffer
                internal IntPtr postBuffer;// Pointer to Buffer 
                internal int postBufferLength; // Length of Buffer 
            }

            // CharSet=Auto here since WSASocket has A and W versions. We can use Auto cause the method is not used under constrained execution region
            [DllImport(WS2_32, CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern IntPtr WSASocket(
                                                    [In] AddressFamily addressFamily,
                                                    [In] SocketType socketType,
                                                    [In] ProtocolType protocolType,
                                                    [In] IntPtr protocolInfo, // will be WSAProtcolInfo protocolInfo once we include QOS APIs
                                                    [In] uint group,
                                                    [In] SocketConstructorFlags flags
                                                    );

            [DllImport(WS2_32, CharSet = CharSet.Auto, SetLastError = true)]
            internal unsafe static extern IntPtr WSASocket(
                                        [In] AddressFamily addressFamily,
                                        [In] SocketType socketType,
                                        [In] ProtocolType protocolType,
                                        [In] byte* pinnedBuffer, // will be WSAProtcolInfo protocolInfo once we include QOS APIs
                                        [In] uint group,
                                        [In] SocketConstructorFlags flags
                                        );



            [DllImport(WS2_32, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern SocketError WSAStartup(
                                               [In] short wVersionRequested,
                                               [Out] out SKYNET.Hook.Types.WSAData lpWSAData
                                               );

            [DllImport(WS2_32, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            internal static extern SocketError ioctlsocket(
                                                [In] IntPtr socketHandle,
                                                [In] int cmd,
                                                [In, Out] ref int argp
                                                );

            [DllImport(WS2_32, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern IntPtr gethostbyname(
                                                  [In] string host
                                                  );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern IntPtr gethostbyaddr(
                                                  [In] ref int addr,
                                                  [In] int len,
                                                  [In] ProtocolFamily type
                                                  );

            [DllImport(WS2_32, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern SocketError gethostname(
                                                [Out] StringBuilder hostName,
                                                [In] int bufferLength
                                                );

            // this should belong to SafeNativeMethods, but it will not for simplicity
            [DllImport(WS2_32, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern uint inet_addr(
                                              [In] string cp
                                              );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError getpeername(
                                                [In] IntPtr socketHandle,
                                                [Out] byte[] socketAddress,
                                                [In, Out] ref int socketAddressSize
                                                );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError getsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [Out] out int optionValue,
                                               [In, Out] ref int optionLength
                                               );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError getsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [Out] byte[] optionValue,
                                               [In, Out] ref int optionLength
                                               );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError getsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [Out] out Linger optionValue,
                                               [In, Out] ref int optionLength
                                               );

            [DllImport(WS2_32, SetLastError = true)]
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
            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError getsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [Out] out IPv6MulticastRequest optionValue,
                                               [In, Out] ref int optionLength
                                               );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError setsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [In] ref int optionValue,
                                               [In] int optionLength
                                               );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError setsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [In] byte[] optionValue,
                                               [In] int optionLength
                                               );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError setsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [In] ref IntPtr pointer,
                                               [In] int optionLength
                                               );

            [DllImport(WS2_32, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            internal static extern SocketError setsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [In] ref Linger linger,
                                               [In] int optionLength
                                               );

            [DllImport(WS2_32, SetLastError = true)]
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
            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError setsockopt(
                                               [In] IntPtr socketHandle,
                                               [In] SocketOptionLevel optionLevel,
                                               [In] SocketOptionName optionName,
                                               [In] ref IPv6MulticastRequest mreq,
                                               [In] int optionLength
                                               );

#if !FEATURE_PAL

            [DllImport(mswsock, SetLastError = true)]
            internal static extern bool TransmitFile(
                                      [In] IntPtr socket,
                                      [In] SafeHandle fileHandle,
                                      [In] int numberOfBytesToWrite,
                                      [In] int numberOfBytesPerSend,
                                      [In] IntPtr overlapped,
                                      [In] TransmitFileBuffers buffers,
                                      [In] TransmitFileOptions flags
                                      );

            [DllImport(mswsock, SetLastError = true)]
            internal static extern bool TransmitFile(
                                      [In] IntPtr socket,
                                      [In] SafeHandle fileHandle,
                                      [In] int numberOfBytesToWrite,
                                      [In] int numberOfBytesPerSend,
                                      [In] IntPtr overlapped,
                                      [In] IntPtr buffers,
                                      [In] TransmitFileOptions flags
                                      );

            [DllImport(mswsock, SetLastError = true)]
            internal static extern bool TransmitFile(
                                      [In] IntPtr socket,
                                      [In] IntPtr fileHandle,
                                      [In] int numberOfBytesToWrite,
                                      [In] int numberOfBytesPerSend,
                                      [In] IntPtr overlapped,
                                      [In] IntPtr buffers,
                                      [In] TransmitFileOptions flags
                                      );

            [DllImport(mswsock, SetLastError = true, EntryPoint = "TransmitFile")]
            internal static extern bool TransmitFile2(
                                      [In] IntPtr socket,
                                      [In] IntPtr fileHandle,
                                      [In] int numberOfBytesToWrite,
                                      [In] int numberOfBytesPerSend,
                                      [In] IntPtr overlapped,
                                      [In] TransmitFileBuffers buffers,
                                      [In] TransmitFileOptions flags
                                      );


            [DllImport(mswsock, SetLastError = true, EntryPoint = "TransmitFile")]
            internal static extern bool TransmitFile_Blocking(
                                      [In] IntPtr socket,
                                      [In] SafeHandle fileHandle,
                                      [In] int numberOfBytesToWrite,
                                      [In] int numberOfBytesPerSend,
                                      [In] IntPtr overlapped,
                                      [In] TransmitFileBuffers buffers,
                                      [In] TransmitFileOptions flags
                                      );

            [DllImport(mswsock, SetLastError = true, EntryPoint = "TransmitFile")]
            internal static extern bool TransmitFile_Blocking2(
                                      [In] IntPtr socket,
                                      [In] IntPtr fileHandle,
                                      [In] int numberOfBytesToWrite,
                                      [In] int numberOfBytesPerSend,
                                      [In] IntPtr overlapped,
                                      [In] TransmitFileBuffers buffers,
                                      [In] TransmitFileOptions flags
                                      );

#endif // !FEATURE_PAL 

            // This method is always blocking, so it uses an IntPtr.
            [DllImport(WS2_32, SetLastError = true)]
            internal unsafe static extern int send(
                                         [In] IntPtr socketHandle,
                                         [In] byte* pinnedBuffer,
                                         [In] int len,
                                         [In] SocketFlags socketFlags
                                         );

            // This method is always blocking, so it uses an IntPtr.
            [DllImport(WS2_32, SetLastError = true)]
            internal unsafe static extern int recv(
                                         [In] IntPtr socketHandle,
                                         [In] byte* pinnedBuffer,
                                         [In] int len,
                                         [In] SocketFlags socketFlags
                                         );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError listen(
                                           [In] IntPtr socketHandle,
                                           [In] int backlog
                                           );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError bind(
                                         [In] IntPtr socketHandle,
                                         [In] byte[] socketAddress,
                                         [In] int socketAddressSize
                                         );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError shutdown(
                                             [In] IntPtr socketHandle,
                                             [In] int how
                                             );

            // This method is always blocking, so it uses an IntPtr.
            [DllImport(WS2_32, SetLastError = true)]
            internal unsafe static extern int sendto(
                                           [In] IntPtr socketHandle,
                                           [In] byte* pinnedBuffer,
                                           [In] int len,
                                           [In] SocketFlags socketFlags,
                                           [In] byte[] socketAddress,
                                           [In] int socketAddressSize
                                           );

            // This method is always blocking, so it uses an IntPtr.
            [DllImport(WS2_32, SetLastError = true)]
            internal unsafe static extern int recvfrom(
                                             [In] IntPtr socketHandle,
                                             [In] byte* pinnedBuffer,
                                             [In] int len,
                                             [In] SocketFlags socketFlags,
                                             [Out] byte[] socketAddress,
                                             [In, Out] ref int socketAddressSize
                                             );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError getsockname(
                                                [In] IntPtr socketHandle,
                                                [Out] byte[] socketAddress,
                                                [In, Out] ref int socketAddressSize
                                                );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern int select(
                                           [In] int ignoredParameter,
                                           [In, Out] IntPtr[] readfds,
                                           [In, Out] IntPtr[] writefds,
                                           [In, Out] IntPtr[] exceptfds,
                                           [In] ref TimeValue timeout
                                           );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern int select(
                                           [In] int ignoredParameter,
                                           [In, Out] IntPtr[] readfds,
                                           [In, Out] IntPtr[] writefds,
                                           [In, Out] IntPtr[] exceptfds,
                                           [In] IntPtr nullTimeout
                                           );

            [DllImport(WS2_32, ExactSpelling = true, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern int getaddrinfo(
                                            [In] string nodename,
                                            [In] string servicename,
                                            [In] ref AddressInfo hints,
                                            [Out] out SafeFreeAddrInfo handle
                                            );

            [DllImport(WS2_32, ExactSpelling = true, SetLastError = true)]
            [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
            internal static extern void freeaddrinfo([In] IntPtr info);


            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSASend(
                                              [In] IntPtr socketHandle,
                                              [In] ref WSABuffer buffer,
                                              [In] int bufferCount,
                                              [Out] out int bytesTransferred,
                                              [In] SocketFlags socketFlags,
                                              [In] IntPtr overlapped,
                                              [In] IntPtr completionRoutine
                                              );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSASend(
                                              [In] IntPtr socketHandle,
                                              [In] WSABuffer[] buffersArray,
                                              [In] int bufferCount,
                                              [Out] out int bytesTransferred,
                                              [In] SocketFlags socketFlags,
                                              [In] IntPtr overlapped,
                                              [In] IntPtr completionRoutine
                                              );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSASend(
                                              [In] IntPtr socketHandle,
                                              [In] IntPtr buffers,
                                              [In] int bufferCount,
                                              [Out] out int bytesTransferred,
                                              [In] SocketFlags socketFlags,
                                              [In] IntPtr overlapped,
                                              [In] IntPtr completionRoutine
                                              );

            [DllImport(WS2_32, SetLastError = true, EntryPoint = "WSASend")]
            internal static extern SocketError WSASend_Blocking(
                                              [In] IntPtr socketHandle,
                                              [In] WSABuffer[] buffersArray,
                                              [In] int bufferCount,
                                              [Out] out int bytesTransferred,
                                              [In] SocketFlags socketFlags,
                                              [In] IntPtr overlapped,
                                              [In] IntPtr completionRoutine
                                              );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSASendTo(
                                                [In] IntPtr socketHandle,
                                                [In] ref WSABuffer buffer,
                                                [In] int bufferCount,
                                                [Out] out int bytesTransferred,
                                                [In] SocketFlags socketFlags,
                                                [In] IntPtr socketAddress,
                                                [In] int socketAddressSize,
                                                [In] IntPtr overlapped,
                                                [In] IntPtr completionRoutine
                                                );

            [DllImport(WS2_32, SetLastError = true)]
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

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSARecv(
                                              [In] IntPtr socketHandle,
                                              [In, Out] ref WSABuffer buffer,
                                              [In] int bufferCount,
                                              [Out] out int bytesTransferred,
                                              [In, Out] ref SocketFlags socketFlags,
                                              [In] IntPtr overlapped,
                                              [In] IntPtr completionRoutine
                                              );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSARecv(
                                              [In] IntPtr socketHandle,
                                              [In, Out] WSABuffer[] buffers,
                                              [In] int bufferCount,
                                              [Out] out int bytesTransferred,
                                              [In, Out] ref SocketFlags socketFlags,
                                              [In] IntPtr overlapped,
                                              [In] IntPtr completionRoutine
                                              );

            [DllImport(WS2_32, SetLastError = true)]
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
            [DllImport(WS2_32, SetLastError = true, EntryPoint = "WSARecv")]
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

            [DllImport(WS2_32, SetLastError = true, EntryPoint = "WSARecv")]
            internal static extern SocketError WSARecv_Blocking(
                                              [In] IntPtr socketHandle,
                                              [In, Out] WSABuffer[] buffers,
                                              [In] int bufferCount,
                                              [Out] out int bytesTransferred,
                                              [In, Out] ref SocketFlags socketFlags,
                                              [In] IntPtr overlapped,
                                              [In] IntPtr completionRoutine
                                              );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSARecvFrom(
                                                  [In] IntPtr socketHandle,
                                                  [In, Out] ref WSABuffer buffer,
                                                  [In] int bufferCount,
                                                  [Out] out int bytesTransferred,
                                                  [In, Out] ref SocketFlags socketFlags,
                                                  [In] IntPtr socketAddressPointer,
                                                  [In] IntPtr socketAddressSizePointer,
                                                  [In] IntPtr overlapped,
                                                  [In] IntPtr completionRoutine
                                                  );

            [DllImport(WS2_32, SetLastError = true)]
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

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSAEventSelect(
                                                     [In] IntPtr socketHandle,
                                                     [In] SafeHandle Event,
                                                     [In] AsyncEventBits NetworkEvents
                                                     );

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSAEventSelect(
                                         [In] IntPtr socketHandle,
                                         [In] IntPtr Event,
                                         [In] AsyncEventBits NetworkEvents
                                         );


            // Used with SIOGETEXTENSIONFUNCTIONPOINTER - we're assuming that will never block. 
            [DllImport(WS2_32, SetLastError = true)]
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

            [DllImport(WS2_32, SetLastError = true, EntryPoint = "WSAIoctl")]
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

            [DllImport(WS2_32, SetLastError = true, EntryPoint = "WSAIoctl")]
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

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern SocketError WSAEnumNetworkEvents(
                                                     [In] IntPtr socketHandle,
                                                     [In] SafeWaitHandle Event,
                                                     [In, Out] ref NetworkEvents networkEvents
                                                     );

#if !FEATURE_PAL
            [DllImport(WS2_32, SetLastError = true)]
            internal unsafe static extern int WSADuplicateSocket(
                [In] IntPtr socketHandle,
                [In] uint targetProcessID,
                [In] byte* pinnedBuffer
            );
#endif // !FEATURE_PAL 

            [DllImport(WS2_32, SetLastError = true)]
            internal static extern bool WSAGetOverlappedResult(
                                                     [In] IntPtr socketHandle,
                                                     [In] IntPtr overlapped,
                                                     [Out] out uint bytesTransferred,
                                                     [In] bool wait,
                                                     [Out] out SocketFlags socketFlags
                                                     );
#if !FEATURE_PAL
            [DllImport(WS2_32, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern SocketError WSAStringToAddress(
                [In] string addressString,
                [In] AddressFamily addressFamily,
                [In] IntPtr lpProtocolInfo, // always passing in a 0 
                [Out] byte[] socketAddress,
                [In, Out] ref int socketAddressSize);

            [DllImport(WS2_32, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
            internal static extern SocketError WSAAddressToString(
                [In] byte[] socketAddress,
                [In] int socketAddressSize,
                [In] IntPtr lpProtocolInfo,// always passing in a 0
                [Out]StringBuilder addressString,
                [In, Out] ref int addressStringLength);

            [DllImport(WS2_32, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, SetLastError = true)]
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
            [DllImport(WS2_32, SetLastError = true, CharSet = CharSet.Auto, ExactSpelling = false)]
            internal static extern int WSAEnumProtocols(
                                                        [MarshalAs(UnmanagedType.LPArray)]
                                                        [In] int[]     lpiProtocols,
                                                        [In] SafeLocalFree lpProtocolBuffer,
                                                        [In][Out] ref uint lpdwBufferLength
                                                       );
#if SOCKETTHREADPOOL
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool BindIoCompletionCallback(
                IntPtr socketHandle, 
                IOCompletionCallback function,
                Int32 flags 
            ); 
 
            [DllImport("kernel32.dll", SetLastError = true)] 
            public static extern IntPtr CreateIoCompletionPort(
                IntPtr socketHandle,
                IntPtr ExistingCompletionPort,
                Int32 CompletionKey, 
                Int32 NumberOfConcurrentThreads
            ); 
  
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr CreateIoCompletionPort( 
                SafeHandle Handle,
                IntPtr ExistingCompletionPort,
                Int32 CompletionKey,
                Int32 NumberOfConcurrentThreads 
            );
            [DllImport("kernel32.dll", SetLastError = true)] 
            public static extern IntPtr CreateIoCompletionPort( 
                IntPtr Handle,
                IntPtr ExistingCompletionPort, 
                Int32 CompletionKey,
                Int32 NumberOfConcurrentThreads
            );
  
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern unsafe bool GetQueuedCompletionStatus( 
              IntPtr CompletionPort, 
              out UInt32 lpNumberOfBytes,
              out Int32 lpCompletionKey, 
              out NativeOverlapped* lpOverlapped,
              Int32 dwMilliseconds
            );
  
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool PostQueuedCompletionStatus( 
                IntPtr CompletionPort, 
                Int32 dwNumberOfBytesTransferred,
                IntPtr dwCompletionKey, 
                IntPtr dwZero
            );
#endif // SOCKETTHREADPOOL
#endif // !FEATURE_PAL 

        }; // class UnsafeNclNativeMethods.OSSOCK 





        [SuppressUnmanagedCodeSecurity]
        internal unsafe static class SecureStringHelper
        {
            // this method is only called as part of an assert 
            internal static bool AreEqualValues(SecureString secureString1, SecureString secureString2)
            { 
                IntPtr bstr1 = IntPtr.Zero; 
                IntPtr bstr2 = IntPtr.Zero;
                bool result = false; 
 
                if (secureString1 == null)
                {
                    if (secureString2 == null) 
                        return true;
                    else
                        return false; 
                }
                else if (secureString2 == null) 
                {
                    return false;
                }
  
                // strings are non-null at this point
  
                if ((object)secureString1 == (object)secureString2) 
                    return true;  // same objects
  
                if (secureString1.Length != secureString2.Length)
                    return false;
 
                // strings are same length.  decrypt to unmanaged memory and compare them. 
 
                try
                { 
                    bstr1 = Marshal.SecureStringToBSTR(secureString1);
                    bstr2 = Marshal.SecureStringToBSTR(secureString2); 
                    result = true;
                    for (int i = 0; i < secureString1.Length; i++)
                    {
                        if (*((char*)bstr1 + i) != *((char*)bstr2 + i)) 
                        {
                            result = false; 
                            break; 
                        }
                    } 
                }
                finally
                {
                    if (bstr1 != IntPtr.Zero) 
                        Marshal.ZeroFreeBSTR(bstr1);
                    if (bstr2 != IntPtr.Zero) 
                        Marshal.ZeroFreeBSTR(bstr2); 
                }
                return result; 
            }

            internal static string CreateString(SecureString secureString)
            {
                string plainString;
                IntPtr bstr = IntPtr.Zero;

                if (secureString == null || secureString.Length == 0)
                    return String.Empty;

                try
                {
                    bstr = Marshal.SecureStringToBSTR(secureString);
                    plainString = Marshal.PtrToStringBSTR(bstr);
                }
                finally
                {
                    if (bstr != IntPtr.Zero)
                        Marshal.ZeroFreeBSTR(bstr);
                }
                return plainString;
            }

            internal static SecureString CreateSecureString(string plainString)
            {
                SecureString secureString;

                if (plainString == null || plainString.Length == 0)
                    return new SecureString();

                fixed (char* pch = plainString)
                {
                    secureString = new SecureString(pch, plainString.Length);
                }

                return secureString;
            }
        }

        [Flags]
        public enum SocketConstructorFlags
        {
            WSA_FLAG_OVERLAPPED = 1,
            WSA_FLAG_MULTIPOINT_C_ROOT = 2,
            WSA_FLAG_MULTIPOINT_C_LEAF = 4,
            WSA_FLAG_MULTIPOINT_D_ROOT = 8,
            WSA_FLAG_MULTIPOINT_D_LEAF = 16
        }
        internal class TransmitFileBuffers
        {
        }
        [Flags]
        internal enum AsyncEventBits
        {
            FdNone = 0,
            FdRead = 1 << 0,
            FdWrite = 1 << 1,
            FdOob = 1 << 2,
            FdAccept = 1 << 3,
            FdConnect = 1 << 4,
            FdClose = 1 << 5,
            FdQos = 1 << 6,
            FdGroupQos = 1 << 7,
            FdRoutingInterfaceChange = 1 << 8,
            FdAddressListChange = 1 << 9,
            FdAllEvents = (1 << 10) - 1,
        }
        internal static class IoctlSocketConstants
        {
            public const int FIONREAD = 0x4004667F;
            public const int FIONBIO = unchecked((int)0x8004667E);
            public const int FIOASYNC = unchecked((int)0x8004667D);
            public const int SIOGETEXTENSIONFUNCTIONPOINTER = unchecked((int)0xC8000006);
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct WSABuffer
        {
            internal int Length; // Length of Buffer
            internal IntPtr Pointer;// Pointer to Buffer
        }
    }
}


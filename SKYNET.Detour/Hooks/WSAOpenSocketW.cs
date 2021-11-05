using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EasyHook;
using SKYNET.Helper;
using SKYNET.Hook.Types;
using SKYNET.Types;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Hook
{
    public class WSAOpenSocketW : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        internal delegate IntPtr WSAOpenSocketWDelegate(AddressFamily addressFamily, SocketType type, ProtocolType protocol, IntPtr protocolInfo, int groupId, short flags);
        WSAOpenSocketWDelegate _WSAOpenSocketW;
        public override string Library => "ws2_32.dll";
        public override string Method => "WSASocketW";
        public override LocalHook Hook { get; set; }
        public override Color Color => Color.Coral; 
        public override Delegate Delegate
        {
            get
            {
                _WSAOpenSocketW = Marshal.GetDelegateForFunctionPointer<WSAOpenSocketWDelegate>(ProcAddress);
                return new WSAOpenSocketWDelegate(Callback);
            }
        }
        private IntPtr Callback(AddressFamily addressFamily, SocketType type, ProtocolType protocol, IntPtr protocolInfo, int groupId, short flags)
        {
            IntPtr result = IntPtr.Zero;
            try
            {
                result = _WSAOpenSocketW(addressFamily, type, protocol, protocolInfo, groupId, flags);

                if (result != IntPtr.Zero)
                {
                    SocketHandle socket = new SocketHandle()
                    {
                        AddressFamily = addressFamily,
                        SocketType = type,
                        ProtocolType = protocol,
                        Handle = result
                    };
                    Main.HookManager.Sockets.Add(socket);
                }
                return result;
            }
            catch
            {
                return result;
            }
        }
    }
}

using System;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EasyHook;
using SKYNET.Hook.Types;

namespace SKYNET.Hook.Processor
{
    /// <summary>
    /// The GetAddrInfoW function provides protocol-independent translation from a Unicode host name to an address.
    /// </summary>
	public unsafe class GetAddrInfoExW : IHook
	{
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate int GetAddrInfoExWDelegate([MarshalAs(UnmanagedType.LPWStr)] string nname, [MarshalAs(UnmanagedType.LPWStr)] string servicename, IntPtr dwNameSpace, IntPtr lpNspId, IntPtr hints, out IntPtr ppResult, IntPtr timeout, IntPtr lpOverlapped, IntPtr lpCompletionRoutine, IntPtr lpNameHandle);
        private GetAddrInfoExWDelegate _GetAddrInfoExW;
        public override string Library => "WS2_32.dll";
        public override string Method => "GetAddrInfoExW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");
        public override Delegate Delegate
        {
            get
            {
                _GetAddrInfoExW = Marshal.GetDelegateForFunctionPointer<GetAddrInfoExWDelegate>(ProcAddress);

                return new GetAddrInfoExWDelegate(Callback);
            }
        }
        private int Callback([MarshalAs(UnmanagedType.LPWStr)] string nname, [MarshalAs(UnmanagedType.LPWStr)] string servicename, IntPtr dwNameSpace, IntPtr lpNspId, IntPtr hints, out IntPtr ppResult, IntPtr timeout, IntPtr lpOverlapped, IntPtr lpCompletionRoutine, IntPtr lpNameHandle)
        {
            string RedirectedHost = nname;

            if (modCommon.IsValidDomain(nname))
            {
                RedirectedHost = Main.GetRedirectedHost(nname);

                var result = _GetAddrInfoExW(RedirectedHost, servicename, dwNameSpace, lpNspId, hints, out ppResult, timeout, lpOverlapped, lpCompletionRoutine, lpNameHandle);
                System.Net.Sockets.SocketError err = (System.Net.Sockets.SocketError)result;

                if (nname != RedirectedHost)
                {
                    Write($"Redirected DNS {nname} to {RedirectedHost} [{err}]");
                }
                else
                {
                    Write($"Processed DNS {nname} [{err}]");
                }
                return result;
            }
            else
            {
                return _GetAddrInfoExW(nname, servicename, dwNameSpace, lpNspId, hints, out ppResult, timeout, lpOverlapped, lpCompletionRoutine, lpNameHandle);
            }
        }
    }

}

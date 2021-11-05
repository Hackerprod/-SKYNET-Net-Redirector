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
	public class GetAddrInfoW : IHook
	{
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate int GetAddrInfoWDelegate([In] [MarshalAs(UnmanagedType.LPWStr)] string nodename, [In] [MarshalAs(UnmanagedType.LPWStr)] string servicename, [In] ref IntPtr hints, out IntPtr ptrResults);

        private GetAddrInfoWDelegate _GetAddrInfoW;
        public override string Library => "WS2_32.dll";
        public override string Method => "GetAddrInfoW";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");
        public override Delegate Delegate
        {
            get
            {
                _GetAddrInfoW = Marshal.GetDelegateForFunctionPointer<GetAddrInfoWDelegate>(ProcAddress);

                return new GetAddrInfoWDelegate(Callback);
            }
        }
        private unsafe int Callback([In] string nname, [In] string servicename, [In] ref IntPtr hints, [Out] out IntPtr ptrResults)
        {
            string RedirectedHost = nname;

            if (modCommon.IsValidDomain(nname))
            {
                RedirectedHost = Main.GetRedirectedHost(nname);

                var result = _GetAddrInfoW(RedirectedHost, servicename, ref hints, out ptrResults);
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
                return _GetAddrInfoW(nname, servicename, ref hints, out ptrResults);
            }
        }
    }

}

using System;
using System.Drawing;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using EasyHook;
using SKYNET.Helper;

namespace SKYNET.Hook.Handler
{
    /// <summary>
    /// The GetAddrInfoW function provides protocol-independent translation from a Unicode host name to an address.
    /// </summary>
	public class WinHttpConnect : IHook
	{
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate IntPtr WinHttpConnectDelegate(IntPtr hSession, [MarshalAs(UnmanagedType.LPWStr)] string pswsServerName, int nServerPort, int dwReserved);
        private WinHttpConnectDelegate _WinHttpConnectDelegate;
        public override string Library => "winhttp.dll";
        public override string Method => "WinHttpConnect";
        public override LocalHook Hook { get; set; }
        public override Color Color => Color.Green;
        public override Delegate Delegate
        {
            get
            {
                _WinHttpConnectDelegate = (WinHttpConnectDelegate)Marshal.GetDelegateForFunctionPointer(ProcAddress, typeof(WinHttpConnectDelegate));

                return new WinHttpConnectDelegate(Callback);
            }
        }


        private IntPtr Callback(IntPtr hSession, string pswsServerName, int nServerPort, int dwReserved)
        {
            string nname = pswsServerName;

            string originalHost = nname + (string.IsNullOrEmpty(nname) ? "" : ":" + nServerPort);
            string RedirectedHost = nname;
            var RedirectedPort = nServerPort;

            string addr = pswsServerName;

            if (IsValidDomain(nname))
            {
                RedirectedHost = Main.GetRedirectedHost(nname);
                RedirectedPort = Main.GetRedirectedPort(nServerPort);
                string TargetHost = RedirectedHost + RedirectedPort;
                addr = RedirectedHost;
                Write($"Redirecting DNS {originalHost} to {TargetHost}");
            }
            else
            {
                Write($"Ignoring DNS {originalHost}");
            }

            return _WinHttpConnectDelegate(hSession, addr, RedirectedPort, dwReserved);
        }
        public bool IsValidDomain(string dns)
        {
            return Regex.IsMatch(dns);
        }
        private static readonly Regex Regex = new Regex("^([a-z0-9]+(-[a-z0-9]+)*\\.)+[a-z]{2,}$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    }

}

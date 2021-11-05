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
	public class GetAddrInfoExA : IHook
	{
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi, SetLastError = true)]
        private delegate int GetAddrInfoExADelegate([MarshalAs(UnmanagedType.LPWStr)] string nodename, [MarshalAs(UnmanagedType.LPWStr)] string servicename, ref IntPtr hints, out IntPtr ptrResults);
        private GetAddrInfoExADelegate _GetAddrInfoExA;

        public override string Library => "WS2_32.dll";
        public override string Method => "GetAddrInfoExA";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");
        public override Delegate Delegate
        {
            get
            {
                _GetAddrInfoExA = Marshal.GetDelegateForFunctionPointer<GetAddrInfoExADelegate>(ProcAddress);

                return new GetAddrInfoExADelegate(Callback);
            }
        }
        private int Callback([MarshalAs(UnmanagedType.LPWStr)] string nname, [MarshalAs(UnmanagedType.LPWStr)] string servicename, ref IntPtr hints, out IntPtr ptrResults)
        {
            string RedirectedHost = nname;

            if (modCommon.IsValidDomain(nname))
            {
                RedirectedHost = Main.GetRedirectedHost(nname);

                var result = _GetAddrInfoExA(RedirectedHost, servicename, ref hints, out ptrResults);
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
                return _GetAddrInfoExA(nname, servicename, ref hints, out ptrResults);
            }
        }
        public bool IsValidDomain(string dns)
        {
            return Regex.IsMatch(dns);
        }
        private static readonly Regex Regex = new Regex("^([a-z0-9]+(-[a-z0-9]+)*\\.)+[a-z]{2,}$", RegexOptions.IgnoreCase | RegexOptions.Compiled);



        //private unsafe static IntPtr CreateSockaddrInStructure(string ip_address, out int size)
        //{
        //    try
        //    {
        //        // LogMessage("CreateSockaddrInStructure: Creating structure for: " + ip_address + ".");

        //        // The SOCKADDR_IN structure is built as if it were on a little-endian machine
        //        // and is treated as a byte array. For more information, see [SOCKADDR].
        //        // little-endian: Multiple-byte values that are byte-ordered with the
        //        // least significant byte stored in the memory location with the lowest address. 

        //        SockAddr_In s; // new SockAddr_In();
        //        SockAddr_In* ps = &s;
        //        SockAddr_In* psa = (SockAddr_In*)ps;

        //        var inAddr = new In_Addr();

        //        string[] ip_bits = ip_address.Split(new Char[] { '.' });
        //        System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

        //        inAddr.s_b1 = System.Convert.ToByte(ip_bits[0]);
        //        inAddr.s_b2 = System.Convert.ToByte(ip_bits[1]);
        //        inAddr.s_b3 = System.Convert.ToByte(ip_bits[2]);
        //        inAddr.s_b4 = System.Convert.ToByte(ip_bits[3]);
        //        psa->sin_addr = inAddr;
        //        psa->sin_family = 2;
        //        psa->sin_port = 0;
        //        for (var i = 0; i < 8; i++)
        //        {
        //            psa->sin_zero[i] = 0;
        //        }

        //        size = Marshal.SizeOf(s);

        //        IntPtr address_in_pointer = Marshal.AllocHGlobal(size);
        //        Marshal.StructureToPtr(s, address_in_pointer, false);

        //        // Let's see if this is the operation that crashes Firefox ....
        //        // No, returning IntPtr.Zero makes no difference;

        //        return address_in_pointer;
        //    }
        //    catch (Exception ex)
        //    {
        //        LogMessage("Error in CreateSockaddrInStructure: " + ex.Message);
        //        size = 0;
        //        return IntPtr.Zero;
        //    }
        //}
    }

}

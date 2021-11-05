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
    public class HttpInitialize : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        public unsafe delegate uint HttpInitializeDelegate(HTTPAPI_VERSION version, uint flags, IntPtr pReserved);
        HttpInitializeDelegate _Listen;
        public override string Library => "httpapi.dll";
        public override string Method => "HttpInitialize";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FAHH");
        public unsafe override Delegate Delegate
        {
            get
            {
                _Listen = Marshal.GetDelegateForFunctionPointer<HttpInitializeDelegate>(ProcAddress);
                return new HttpInitializeDelegate(Callback);
            }
        }

        private unsafe uint Callback(HTTPAPI_VERSION version, uint flags, IntPtr pReserved)
        {
            Write(version);

            return _Listen(version, flags, pReserved);

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HTTPAPI_VERSION
        {
            internal ushort HttpApiMajorVersion;
            internal ushort HttpApiMinorVersion;
        }
    }
}

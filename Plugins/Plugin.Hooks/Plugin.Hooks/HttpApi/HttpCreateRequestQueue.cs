using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using EasyHook;

namespace SKYNET.Hook.Processor
{
    public class HttpCreateRequestQueue : IHook
    {
        private const string HTTPAPI = "httpapi.dll";
        [SuppressMessage("Microsoft.Security", "CA2118:ReviewSuppressUnmanagedCodeSecurityUsage", Justification = "Implementation requires unmanaged code usage")]
        private delegate int HttpCreateRequestQueueDelegate(HTTPAPI_VERSION version, string pName, int pSecurityAttributes, uint flags, out IntPtr pReqQueueHandle);
        private HttpCreateRequestQueueDelegate _HttpCreateRequestQueueA;

        public override string Library => "httpapi.dll";
        public override string Method => "HttpCreateRequestQueue";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#f58207");
        public override Delegate Delegate
        {
            get
            {
                _HttpCreateRequestQueueA = Marshal.GetDelegateForFunctionPointer<HttpCreateRequestQueueDelegate>(ProcAddress);

                return new HttpCreateRequestQueueDelegate(Callback);
            }
        }

        private int Callback(HTTPAPI_VERSION version, string pName, int pSecurityAttributes, uint flags, out IntPtr pReqQueueHandle)
        {
            Write($"HttpCreateRequestQueue");

            return _HttpCreateRequestQueueA(version, pName, pSecurityAttributes, flags, out pReqQueueHandle);
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct HTTPAPI_VERSION
        {
            internal ushort HttpApiMajorVersion;
            internal ushort HttpApiMinorVersion;
        }
    }
}

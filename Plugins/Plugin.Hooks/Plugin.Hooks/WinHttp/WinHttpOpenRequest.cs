using System;
using System.Drawing;
using System.Runtime.InteropServices;
using EasyHook;

namespace SKYNET.Hook.Handler
{
    /// <summary>
    /// The connect function establishes a connection to a specified socket.
    /// </summary>
    public class WinHttpOpenRequest : IHook
    {
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        private delegate int WinHttpOpenRequestDelegate(IntPtr connectHandle, string verb, string objectName, string version, string referrer, string acceptTypes, uint flags);
        WinHttpOpenRequestDelegate _WinHttpOpenRequest;

        public override string Library => "winhttp.dll";
        public override string Method => "WinHttpOpenRequest";
        public override LocalHook Hook { get; set; }
        public override Color Color => ColorTranslator.FromHtml("#00FA00");


        public override Delegate Delegate
        {
            get
            {
                _WinHttpOpenRequest = (WinHttpOpenRequestDelegate)Marshal.GetDelegateForFunctionPointer(ProcAddress, typeof(WinHttpOpenRequestDelegate));
                return new WinHttpOpenRequestDelegate(Callback);
            }
        }

        private int Callback(IntPtr connectHandle, string verb, string objectName, string version, string referrer, string acceptTypes, uint flags)
        {
            Write($"Endpoint: {objectName}");

            return _WinHttpOpenRequest(connectHandle, verb, objectName, version, referrer, acceptTypes, flags);

        }
    }
}

using System;
using System.Drawing;
using EasyHook;

namespace SKYNET.Hook
{
    public abstract class IHook
    {
        public abstract string Library { get; }
        public abstract string Method { get; }
        public bool Installed { get; set; }
        public abstract LocalHook Hook { get; set; }
        public abstract Delegate Delegate { get; }
        public IntPtr ProcAddress { get; internal set; }
        public abstract Color Color { get; }
        public void Write(object msg)
        {

            string method = Method.ToUpper();
            switch (Method)
            {
                case "CertVerifyCertificateChainPolicy":
                    method = "VERIFYCERTCPOLICY";
                    break;
                case "WinHttpOpenRequest":
                    method = "HTTPOPENREQUEST";
                    break;
            }
            Main.Write(method, msg, Color);
        }
    }
}
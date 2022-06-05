using System;
using System.Collections.Generic;
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
        private List<string> LastMsgs = new List<string>();
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
            LastMsgs.Add(msg.ToString());
            var msgs = LastMsgs.FindAll(m => m == msg.ToString());
            if (msgs.Count < 7)
            {
                Main.Write(method, msg, Color);
            }
            if (LastMsgs.Count > 9)
            {
                LastMsgs.RemoveAt(10);
            }
        }
    }
}
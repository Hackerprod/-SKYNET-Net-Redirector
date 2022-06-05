using System;
using System.Collections.Concurrent;
using System.Drawing;
using EasyHook;
using SKYNET.Detour.Helpers;
using SKYNET.Types;

namespace SKYNET
{
    public class HookInterface : MarshalByRefObject
    {
        public ConcurrentDictionary<string, string> DnsRedirection;
        public ConcurrentDictionary<string, string> IPRedirection;
        public ConcurrentDictionary<int, int> PortRedirection;

        #region Events

        public event EventHandler<string> PingNotify;
        public event EventHandler<ConsoleMessage> OnMessage;
        public event EventHandler<string> OnUninstall;
        public event EventHandler<NetMessage> OnPacketReceived;
        public event EventHandler<NetMessage> OnPacketSent;

        #endregion

        //Settings
        public bool DumpToConsole { get; set; }
        public bool SkipCertificateChainVerification { get; set; }
        public bool DumpToFile { get; set; }
        public bool InjectOnStart { get; set; }
        public bool LoadPlugins { get; set; }
        public string ChannelName { get; set; }
        public string DllPath { get; set; }
        public string PluginsPath { get; set; }
        public InjectionOptions InjectionOptions { get; set; }


        public HookInterface()
        {
            DnsRedirection = new ConcurrentDictionary<string, string>();
            IPRedirection = new ConcurrentDictionary<string, string>();
            PortRedirection = new ConcurrentDictionary<int, int>();
        }

        public void Ping(string callbackChannel)
        {
            this.PingNotify?.Invoke(this, callbackChannel);
        }

        public void InvokeMessage(string sender, object msg, Color color, string ObjectId = "")
        {
            OnMessage?.Invoke(this, new ConsoleMessage(sender, msg, MessageType.SENDER, color, ObjectId));
        }
        public void InvokePacketReceived(NetMessage netMsg)
        {
            OnPacketReceived?.Invoke(this, netMsg);
        }
        public void InvokePacketSent(NetMessage netMsg)
        {
            OnPacketSent?.Invoke(this, netMsg);
        }
    }
}



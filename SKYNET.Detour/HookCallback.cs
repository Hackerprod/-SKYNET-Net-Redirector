using System;
using System.Collections.Concurrent;

namespace SKYNET
{
    public class HookCallback : MarshalByRefObject
    {

        public event EventHandler ReleaseHooks;
        public event EventHandler<string> ReleaseHook;
        public event EventHandler<bool> DumpToConsoleChanged;
        public event EventHandler<bool> DumpToFileChanged;
        public event EventHandler<bool> SkipChainVerificationChanged;
        public event EventHandler<ConcurrentDictionary<string, string>> PortRedirectionChanged;
        public event EventHandler<ConcurrentDictionary<string, string>> IpRedirectionChanged;
        public event EventHandler<ConcurrentDictionary<string, string>> DnsRedirectionChanged;


        public void Ping()
        {
        }

        public void InvokeReleaseHooks()
        {
            ReleaseHooks?.Invoke(this, new EventArgs());
        }
        public void InvokeReleaseHook(string hook)
        {
            ReleaseHook?.Invoke(this, hook);
        }
        public void InvokeDumpToConsoleChanged(bool capture)
        {
            DumpToConsoleChanged?.Invoke(this, capture);
        }

        public void InvokeDumpToFileChanged(bool capture)
        {
            DumpToFileChanged?.Invoke(this, capture);
        }

        public void InvokeSkipChainVerificationChanged(bool @checked)
        {
            SkipChainVerificationChanged?.Invoke(this, @checked);
        }

        public void InvokePortRedirectionChanged(ConcurrentDictionary<string, string> portRedirection)
        {
            PortRedirectionChanged?.Invoke(this, portRedirection);
        }

        public void InvokeIpRedirectionChanged(ConcurrentDictionary<string, string> ipRedirection)
        {
            IpRedirectionChanged?.Invoke(this, ipRedirection);
        }

        public void InvokeDnsRedirectionChanged(ConcurrentDictionary<string, string> dnsRedirection)
        {
            DnsRedirectionChanged?.Invoke(this, dnsRedirection);
        }
    }
}
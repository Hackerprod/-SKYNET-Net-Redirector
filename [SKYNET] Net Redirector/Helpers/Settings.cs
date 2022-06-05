using SKYNET.INI.Attributes;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Helpers
{
    public class Settings
    {
        [INISection("File Settings")]
        public string Path { get; set; }

        [INISection("File Settings")]
        public string Arguments { get; set; }

        [INISection("DNS Redirection", IsArray = true)]
        [INIComment("Declare hostnames to be redirected, [* = 127.0.0.1] redirect all DNS hosts to local")]
        [INIComment("Source = Destination")]
        public ConcurrentDictionary<string, string> DNSRedirection { get; set; }

        [INISection("IP Redirection", IsArray = true)]
        [INIComment("Declare IP to be redirected, [192.168.1.20 = 127.0.0.1]")]
        [INIComment("Source = Destination")]
        public ConcurrentDictionary<string, string> IPRedirection { get; set; }

        [INISection("Port Redirection", IsArray = true)]
        [INIComment("Declare port to be redirected, [80 = 8080]")]
        [INIComment("Source = Destination")]
        public ConcurrentDictionary<int, int> PortRedirection { get; set; }

        [INISection("Application")]
        [INIComment("Inject automatically when Net Redirector start")]
        public bool InjectOnStart { get; set; }

        [INISection("Application")]
        [INIComment("Load custom plugins stored in Plugins folder")]
        public bool LoadPlugins { get; set; }

        [INISection("Misc")]
        [INIComment("Show received and sent packets in console")]
        public bool DumpToConsole { get; set; }

        [INISection("Misc")]
        [INIComment("Save received and sent packets in dump file")]
        public bool DumpToFile { get; set; }

        [INISection("Misc")]
        [INIComment("Skip verification of certificate chain policy")]
        public bool SkipCertificateChainVerification { get; set; }
    }
}

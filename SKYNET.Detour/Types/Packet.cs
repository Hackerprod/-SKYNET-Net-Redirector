using System;
using System.Net;
using System.Net.Sockets;
using SKYNET.Types;

namespace SKYNET.Hook.Types
{
    [Serializable]
    public class Packet 
    {
        public string Sender { get; set; }
        public IPEndPoint Source { get; internal set; }
        public IPEndPoint Destination { get; internal set; }
        public IPEndPoint OriginalDestination { get; internal set; }
        public byte[] Buffer { get; internal set; }
        public IntPtr Socket { get; internal set; }
        public DIRECTION Direction { get; set; }
        public ProtocolType Protocol { get; set; }
    }
}
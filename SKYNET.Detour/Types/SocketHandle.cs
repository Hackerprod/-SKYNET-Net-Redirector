using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Types
{
    public class SocketHandle
    {
        public IntPtr Handle;
        public AddressFamily AddressFamily;
        public SocketType SocketType;
        public ProtocolType ProtocolType;
    }
}

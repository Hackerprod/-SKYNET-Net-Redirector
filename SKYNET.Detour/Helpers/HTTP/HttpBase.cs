using System;
using SKYNET.Types;

namespace SKYNET
{
    [Serializable]
    public class HttpBase 
    {
        public byte[] Header { get; set; }
        public byte[] Body { get; set; }
        public HttpType Type { get; set; }
        public enum HttpType
        {
            HttpRequest,
            HttpResponse
        }
    }
}
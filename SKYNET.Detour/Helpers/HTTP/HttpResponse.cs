using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SKYNET
{
    [Serializable]
    public class HttpResponse : HttpBase
    {
        public string ContentType { get; set; }
        public bool KeepAlive { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Cookies { get; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public long ContentLength { get; set; }
        public string Version { get; set; }
        public DateTime Date { get; set; }
        public string BodyString { get; set; }
        public Stream GetResponseStream() => new MemoryStream(Body);
        public string HeaderString { get; set; }

        // Private properties
        private string BodySeparator = "0D0A0D0A";
        private string RequestString { get; set; }
        

        public HttpResponse(byte[] bytes)
        {
            base.Type = HttpType.HttpResponse;
            RequestString = Encoding.Default.GetString(bytes);
            Header = bytes;

            string Hex = ToHexString(bytes);
            if (Hex.Contains(BodySeparator))
            {
                string[] Parts = Hex.Split(new string[] { BodySeparator }, StringSplitOptions.None);
                if (Parts.Length > 1)
                {
                    string HeaderHex = Parts[0];
                    string BodyHex = Parts[1];
                    RequestString = Encoding.Default.GetString(FromHexString(HeaderHex));
                    HeaderString = RequestString;
                    Body = FromHexString(BodyHex);
                    BodyString = Encoding.Default.GetString(FromHexString(BodyHex));
                    Header = FromHexString(HeaderHex);
                }
            }

            Headers = new Dictionary<string, string>();
            Cookies = new Dictionary<string, string>();

            var RequestLines = SplitLines(RequestString, out List<string> _Headers);

            LoadHeaders(_Headers);

            string indexLine = RequestLines.Find(l => l.Contains("HTTP/"));
            SetMany((indexLine));
        }

        private void SetMany(string indexLine)
        {
            string[] args = indexLine.Split(' ');
            if (args.Any() && args.Count() == 3)
            {
                Version = args[0];
                StatusCode = Convert.ToInt32(args[1]);
                StatusDescription = args[2];
            }
        }

        private void LoadHeaders(List<string> _Headers)
        {
            foreach (var header in _Headers)
            {
                string Header = header;
                string[] KeyPair = Header.Split(':');
                string Key = KeyPair[0];
                string Value = KeyPair[1];
                Headers.Add(Key, Value);
                switch (Key.ToLower())
                {
                    case "date":
                        //DateTime t = DateTime.Parse(Value);
                        break;
                    case "content-type":
                        ContentType = Value;
                        break;
                    case "content-length":
                        if (long.TryParse(Value, out long length))
                            ContentLength = length;
                        break;
                    default:
                        break;
                }
            }
        }

        internal void SetBody(byte[] body)
        {
            Body = body;
        }

        private static List<string> SplitLines(string raw, out List<string> _Headers)
        {
            List<string> result = new List<string>();
            string[] lines = raw.TrimEnd('\r', '\n').Split(new[] { "\\n", "\n", "\r\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                string _Line = line.Replace(": ", ":");
                while (_Line.StartsWith(" "))
                {
                    _Line = _Line.Remove(0, 1);
                }
                result.Add(_Line);
            }
            _Headers = result.FindAll(h => h.Contains(":"));
            return result;
        }

        private string ToHexString(byte[] data)
        {
            if (data == null)
                return null;
            char[] c = new char[data.Length * 2];
            int b;
            for (int i = 0; i < data.Length; i++)
            {
                b = data[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = data[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }
            return new string(c);
        }
        private byte[] FromHexString(string hexString)
        {
            if (hexString == null)
                return null;
            if (hexString.Length % 2 != 0)
                throw new FormatException("The hex string is invalid because it has an odd length");
            var result = new byte[hexString.Length / 2];
            for (int i = 0; i < result.Length; i++)
                result[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return result;
        }
    }
}
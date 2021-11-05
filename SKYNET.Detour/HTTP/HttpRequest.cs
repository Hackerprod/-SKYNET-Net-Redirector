using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace SKYNET
{
    [Serializable]
    public class HttpRequest : HttpBase
    {
        public string Host { get; set; }
        public long ContentLength { get; set; }
        public string Endpoint { get; set; }
        public string RawUrl { get; set; }
        public string Method { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Cookies { get; }
        public Dictionary<string, string> QueryString { get; set; }
        public string ProtocolVersion { get; set; }
        public string Connection { get; set; }
        public string Accept { get; set; }
        public string Referer { get; set; }
        public string UserAgent { get; set; }
        public DateTime Date { get; set; }
        public string BodyString { get; set; }
        public Stream GetRequestStream() => new MemoryStream(Body);
        public string HeaderString { get; set; }


        // Private properties
        private readonly string[] validHttpVerbs = { "GET", "POST", "POST", "OPTION", "TRACE", "CONNECT", "DELETE", "PUT", "HEAD", "POST", };
        private byte[] _bytes;
        private string BodySeparator = "0D0A0D0A"; // -> /n/n

        private string RequestString { get; set; }


        public HttpRequest(byte[] bytes)
        {
            base.Type = HttpType.HttpRequest;
            this._bytes = bytes;
            RequestString = Encoding.Default.GetString(bytes);

            string Hex = ToHexString(bytes);
            if (Hex.Contains(BodySeparator))
            {
                string[] Parts = Hex.Split(new string[] { BodySeparator }, StringSplitOptions.None);
                string HeaderHex = Parts[0];
                string BodyHex = Parts[1];
                RequestString = Encoding.Default.GetString(FromHexString(HeaderHex));
                HeaderString = RequestString;
                Header = FromHexString(HeaderHex);
                Body = FromHexString(BodyHex);
                BodyString = Encoding.Default.GetString(FromHexString(BodyHex));
            }


            Headers = new Dictionary<string, string>();
            Cookies = new Dictionary<string, string>();
            QueryString = new Dictionary<string, string>();

            if (!ValidateRequest(RequestString))
            {
                return;
            }

            var RequestLines = SplitLines(RequestString, out List<string> _Headers);

            LoadHeaders(_Headers);

            var cookieLine = ExtractCookiesLine(RequestLines);
            PopulateParsedCookies(cookieLine);

            string indexLine = RequestLines.Find(l => l.Contains("HTTP/"));
            SetMany((indexLine));
        }

        private void SetMany(string indexLine)
        {
            string[] args = indexLine.Split(' ');
            if (args.Any() && args.Count() == 3)
            {
                Method = args[0];
                Endpoint = args[1];
                RawUrl = args[1];
                ProtocolVersion = args[2];
            }

            //Set Querys
            if (RawUrl.Contains("?"))
            {
                string query = RawUrl.Split('?')[1];
                var Collection = HttpUtility.ParseQueryString(query);
                foreach (var Key in Collection.Keys)
                {
                    QueryString.Add(Key.ToString(), Collection[Key.ToString()]);
                }
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
                //HttpWebRequest
                Headers.Add(Key, Value);
                switch (Key.ToLower())
                {
                    case "host":
                        Host = Value;
                        break;
                    case "user-agent":
                        UserAgent = Value;
                        break;
                    case "accept":
                        Accept = Value;
                        break;
                    case "connection":
                        Connection = Value;
                        break;
                    case "":
                        break;
                    default:
                        break;
                }
            }
        }

        private bool ValidateRequest(string requestString)
        {
            foreach (var item in validHttpVerbs)
            {
                if (requestString.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        private static List<string> SplitLines(string raw, out List<string> _Headers)
        {
            List<string> result = new List<string>();
            string[] lines =  raw .TrimEnd('\r', '\n') .Split(new[] { "\\n", "\n", "\r\n" }, StringSplitOptions.None);
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
        private string ExtractCookiesLine(List<string> lines)
        {
            var cookieIndex = Array.FindLastIndex(lines.ToArray(), l => l.StartsWith("Cookie"));

            return cookieIndex > 0 ? lines[cookieIndex] : null;
        }

        private void PopulateParsedCookies(string cookiesLine)
        {
            if (string.IsNullOrEmpty(cookiesLine)) return;

            var matches = new Regex(@"Cookie:(?<Cookie>(.+))", RegexOptions.Singleline).Match(cookiesLine);
            var cookies = matches.Groups["Cookie"].ToString().Trim().Split(';');

            if (cookies?.Length < 1 || cookies.Contains(""))
            {
                return;
            }

            foreach (var cookie in cookies)
            {
                var key = cookie.Split('=')[0].Trim();
                var value = cookie.Split('=')[1].Trim();
                Cookies[key] = value;
            }
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

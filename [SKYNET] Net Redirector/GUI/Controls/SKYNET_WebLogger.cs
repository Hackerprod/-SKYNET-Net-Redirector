﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using Microsoft.VisualBasic.CompilerServices;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using SKYNET.Types;
using SKYNET.Hook.Types;
using System.IO.Pipes;
using SKYNET.Detour.Helpers;

namespace SKYNET.Controls
{
    [ComVisible(true)]
    public partial class SKYNET_WebLogger : UserControl
    {
        [Category("SKYNET")]
        public event EventHandler<WebBrowserDocumentCompletedEventArgs> DocumentCompleted;
        [Category("SKYNET")]
        public event EventHandler<WebBrowserNavigatingEventArgs> Navigating;
        public override ContextMenuStrip ContextMenuStrip
        {
            get { return webChat.ContextMenuStrip; }
            set { webChat.ContextMenuStrip = value; }
        }


        private List<ConsoleMessage> CallBack;
        Font _font;
        public override Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }
        public SKYNET_WebLogger()
        {
            InitializeComponent();
            InitializeWebBrowser();
            _font = new Font("Segoe UI", 10);
            CallBack = new List<ConsoleMessage>();

        }
        private void InitializeWebBrowser()
        {
            InternetExplorerBrowserEmulation.SetBrowserEmulationVersion();

            webChat.ScriptErrorsSuppressed = true;
            webChat.Navigate("about:blank");

            while (webChat.Document == null || webChat.Document.Body == null)
            Application.DoEvents();

            webChat.Document.OpenNew(true).Write($"<html><head>{GetHtmlIEVersion()}{ScrollBar(_scroll) + JavaScript()} <style>{GetStyles()}</style>  <title name = 'head'>SKYNET</title>" + $"</head><body class='body' bgcolor=#1D2733><table style=\"padding: 0px\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" id='table'>");
            AssignStyleSheet();

            webChat.Navigating += new WebBrowserNavigatingEventHandler(webChat_Navigating);
            //webChat.ContextMenuStrip = base.ContextMenuStrip;    //! Set our ContextMenuStrip
            webChat.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(OnDocumentCompleted);
            webChat.ObjectForScripting = this;

        }
        public static string GetHtmlIEVersion()
        {
            string str = "";
            try
            {
                if (Conversions.ToInteger(Conversions.ToString(InternetExplorerBrowserEmulation.GetInternetExplorerMajorVersion())) == 11)
                {
                    str = string.Format("<meta http-equiv='X-UA-Compatible' content='IE=edge'>");
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                ProjectData.ClearProjectError();
            }
            return str;
        }

        [Category("SKYNET")]
        public Color LoggerBackColor
        {
            get
            {
                return _LoggerBackColor;
            }
            set
            {
                _LoggerBackColor = value;
            }
        }
        Color _LoggerBackColor;

        [Category("SKYNET")]
        public Color ScrollColors
        {
            get
            {
                return _scroll;
            }
            set
            {
                _scroll = value;
            }
        }
        Color _scroll;

        [Category("SKYNET")]
        public bool AutoScrollLines
        {
            get
            {
                return _autoscroll;
            }
            set
            {
                _autoscroll = value;
            }
        }
        public bool CancelNext { get; private set; }

        bool _autoscroll = true;


        public void WriteLine(ConsoleMessage msg)
        {
            CallBack.Add(msg);
            VerifyCallback();
        }
        private void VerifyCallback()
        {
            for (int i = 0; i < CallBack.Count; i++)
            {
                var e = CallBack[i];

                if (e == null || e.Message == null)
                    return;
                string htmlMessage = GetMessage(e);

                Write(htmlMessage);

                CallBack.Remove(e);
            }
        }

        public void Write(string html)
        {

            try
            {
                int bodyHeight = Convert.ToInt32(webChat.Document.InvokeScript("GetPageHeight"));
                bool scroll = bodyHeight - Height == webChat.Document?.Body?.ScrollTop;

                webChat.Invoke(new Action(() =>
                {
                    webChat.Document.Write(html);
                    try
                    {
                        if (scroll)
                        {
                            webChat.Document.Window.ScrollTo(0, webChat.Document.Body.ScrollRectangle.Height);
                        }
                    }
                    catch { }
                }));

            }
            catch { }
        }






        public void AssignStyleSheet()
        {
            string name = webChat.Name;
            IHTMLStyleSheet2 instance = (IHTMLStyleSheet2)((IHTMLDocument2)webChat.Document.DomDocument).createStyleSheet("", 0);

            NewLateBinding.LateSet(instance, null, "cssText", new object[1]
            {
                GetStyles()
            }, null, null);

            HtmlElement htmlElement = webChat.Document.GetElementsByTagName("head")[0];
            HtmlElement htmlElement2 = webChat.Document.CreateElement("script");
            IHTMLScriptElement iHTMLScriptElement = (IHTMLScriptElement)htmlElement2.DomElement;

            iHTMLScriptElement.text = JavaScript(); //GetJavascript();
            htmlElement.AppendChild(htmlElement2);
        }
        public static string ScrollBar(Color scroll)
        {
            return @"<style type='text/css'> body { " +
            $"scrollbar-face-color:#52a1f2; " + //barra
            $"scrollbar-highligh-color:#1d2733; " +
            $"scrollbar-3dligh-color:#1d2733; " +
            $"scrollbar-darkshadow-color:#1d2733; " +
            $"scrollbar-shadow-color:#73b5f8; " + //Borde afuera
            $"scrollbar-track-color:#1d2733; " + //Fondo de la barra
             "scrollbar-arrow-color:#52a1f2;" + //Arrow
            "} </style>" +
            "";
        }

        internal static string JavaScript()
        {
            string  intHeigth = @"
                <script>
                    function GetPageHeight()
                    {
	                    var body = document.body;
 	                    var html = document.documentElement;
 	                    var height = Math.max(body.scrollHeight ,body.offsetHeight, html.clientHeight, html.scrollHeight, html.offsetHeight);
 	                    return height;
                     }
                    function getSelectionText() 
                    { 
                        var text = '';                        
                        if (window.getSelection) 
                        {                               
                            text = window.getSelection().toString();
                        } 
                        else if (document.selection && document.selection.type != 'Control') 
                        {
                            text = document.selection.createRange().text;                        
                        }                        
                        return text;                    
                    }    
                </script>
                    ";

            return intHeigth;
        }


        private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection body = webChat.Document.GetElementsByTagName("BODY");
            for (int i = 0; i < body.Count; i++)
            {
                HtmlElement el = body[i];
                el.AttachEventHandler("onclick", (Sender, args) => OnElementSelect(el, EventArgs.Empty));
            }
            DocumentCompleted?.Invoke(sender, e);
        }
        protected void OnElementSelect(object sender, EventArgs args)
        {
            //Hecho por mi
            string selection = webChat.Document.InvokeScript("getSelectionText").ToString();
            if (!string.IsNullOrEmpty(selection))
            {
                Clipboard.Clear();
                Clipboard.SetText(selection, TextDataFormat.UnicodeText);
            }
        }

        private void webChat_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Navigating?.Invoke(sender, e);
        }

        public void ClearScreen()
        {
            webChat.Document.OpenNew(true);
            InitializeWebBrowser();
        }
        public static string GetStyles()
        {
            string clase = @"
            .message-Body 
            {
                color: #BFBFBF;
                font-size: 10pt;
                FONT-FAMILY: Segoe UI;
            }
            .message-type {
            color: #FFFFFF;
            font-size: 9pt;
            FONT-FAMILY: Segoe UI;
            }

            ";
            return clase;
        }
        public void ShowDump(int Id)
        {
            NetMessage msg = frmMain.frm.NetMessages.Find(m => m.Id == Id);
            if (msg != null)
            {
                //new PacketEditor.ReplayEditor(msg.Body, 15, new NamedPipeClientStream("as")).Show();
                new frmDumpViewer(msg).Show();
            }
        }
    }

    public partial class SKYNET_WebLogger
    {
        private string C_1 = "#1D2834";
        private string C_2 = "#222E39";
        private string C_Last = "#1D2834";
        public string GetMessage(ConsoleMessage m)
        {
            string msg = "";
            string ObjectId = "";

            if (m.Type == MessageType.SENDER)
            {
                if (m.Message is string)
                {
                    msg = (string)m.Message;
                }
            }
            else
            {

            }

            if (!string.IsNullOrEmpty(m.ObjectId))
            {
                ObjectId = m.ObjectId;
            }

            C_Last = C_Last == C_1 ? C_2 : C_1;
            StringBuilder code = new StringBuilder();

            //Sender
            code.AppendLine($"<tr bgcolor=\"{C_Last}\">");
            code.AppendLine("<td style=\"padding-left:5; width:115\">");
            code.AppendLine($"<h5 style='color:{ColorTranslator.ToHtml(m.Color)}; text-align:top' Class='message-type'>{m.Sender}</h5>");
            code.AppendLine("</td>");

            //Body
            code.AppendLine("<td Class=\"message-Body\" style=\"padding-left:5; max-width:650px; width:650px\">");

            var lines = SplitLines(msg);
            if (lines.Count > 1)
            {
                code.AppendLine(lines[0]);
                code.AppendLine("</td>");
                code.AppendLine("</tr>");
                code.AppendLine($"<tr bgcolor=\"{C_Last}\">");
                code.AppendLine("<td style=\"padding-left:5; width:115\">");
                code.AppendLine("</td>");
                code.AppendLine("<td Class=\"message-Body\" style=\"padding-left:5; max-width:650px; width:650px\">");
                for (int i = 0; i < lines.Count; i++)
                {
                    if (i != 0)
                    {
                        string line = (i == lines.Count - 1) ? SplitBody(lines[i]) : SplitBody(lines[i]) + "</br>";
                        code.AppendLine(line);
                    }
                }
                code.AppendLine("</td>");
            }
            else
            {
                if (ObjectId != "")
                {
                    msg += $"&nbsp; &nbsp; <a onclick=\"window.external.ShowDump('{ObjectId}')\" style=\"cursor:hand; color:#78C3FC; text-size:70px;\"> Show details </a>";
                    code.Append(msg);
                }
                else
                {
                    msg = ReplaceNewSpace(msg);
                    code.AppendLine(SplitBody(msg));
                }

                code.AppendLine("</td>");
            }
            code.AppendLine("</tr>");
            string Code = code.ToString();
            return Code;
        }

        private string ReplaceNewSpace(string msg)
        {
            string result = "";
            string[] lines = msg.TrimEnd('\r', '\n').Split(new[] { "\\n", "\n", "\r\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                result += line + "</br>";
            }
            return result;
        }

        private List<string> SplitLines(string raw)
        {
            List<string> result = new List<string>();
            string[] lines = raw.TrimEnd('\r', '\n').Split(new[] { "\\n", "\n", "\r\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                result.Add(line);
            }
            return result;
        }
        private string SplitBody(string msg)
        {
            string result = "";

            if (msg.Contains(" "))
            {
                foreach (var item in msg.Split(' '))
                {
                    if (GetTextSize(item) > 640)
                    {
                        string part = "";
                        for (int i = 0; i < item.Length; i++)
                        {
                            part += item[i];
                            if (GetTextSize(part) >= 640)
                            {
                                result += part + "</br>";
                                part = "";
                            }
                            if (i == (item.Length - 1))
                            {
                                result += part;
                                part = "";
                            }
                        }
                    }
                    else
                    {
                        if (result.Length > 0 && result[result.Length - 1] == ' ')
                        {
                            result += item + " ";
                        }
                        else
                            result += " " + item + " ";
                    }
                }
            }
            else if (GetTextSize(msg) > 640)
            {
                string part = "";
                for (int i = 0; i < msg.Length; i++)
                {
                    part += msg[i];

                    if (GetTextSize(part) >= 640)
                    {
                        result += part + "</br>";
                        part = "";
                    }
                    if (i == (msg.Length - 1))
                    {
                        result += part;
                        part = "";
                    }
                }
            }
            else
            {
                result = msg;
            }
            return result;
        }
        public int GetTextSize(string msg)
        {
            return Convert.ToInt32(modCommon.GetTextSize(msg, Font).Width);
        }
    }
    //public class ConsoleMessage
    //{
    //    public string Sender { get; set; }
    //    public object Message { get; set; }
    //    public MessageType Type { get; set; }
    //    public Color Color { get; set; }
    //    public string ObjectId { get; set; }

    //    public ConsoleMessage(string sender, object message, MessageType type, Color color, string objectId = "")
    //    {
    //        this.Sender = sender;
    //        this.Message = message;
    //        this.Type = type;
    //        this.Color = color;
    //        this.ObjectId = objectId;
    //    }
    //    public ConsoleMessage()
    //    {
    //    }
    //}
    //public enum MessageType : int
    //{
    //    INFO,
    //    WARN,
    //    ERROR,
    //    DEBUG,
    //    SENDER
    //}
}

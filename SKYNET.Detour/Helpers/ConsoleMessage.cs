using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Detour.Helpers
{
    public class ConsoleMessage
    {
        public string Sender { get; set; }
        public object Message { get; set; }
        public MessageType Type { get; set; }
        public Color Color { get; set; }
        public string ObjectId { get; set; }

        public ConsoleMessage(string sender, object message, MessageType type, Color color, string objectId = "")
        {
            this.Sender = sender;
            this.Message = message;
            this.Type = type;
            this.Color = color;
            this.ObjectId = objectId;
        }
        public ConsoleMessage()
        {
        }
    }
    public enum MessageType : int
    {
        INFO,
        WARN,
        ERROR,
        DEBUG,
        SENDER
    }
}

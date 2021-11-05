using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using SKYNET;

namespace SKYNET.Types
{
    [Serializable]
    public class NetMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public IPEndPoint Source { get; set; }
        public IPEndPoint Destination { get; set; }
        public byte[] Body { get; set; }
        public object NetObject { get; set; }
        public DateTime Time { get; set; }
        public DIRECTION Direction { get; set; }
        public ProtocolType Protocol { get; set; }

        public byte[] Serialize()
        {
            MemoryStream stream = new MemoryStream();
            new BinaryFormatter().Serialize(stream, this);
            return stream.ToArray();
        }

        public void Deserialize(byte[] msgBytes)
        {
            try
            {
                NetMessage msg = (NetMessage)new BinaryFormatter().Deserialize(new MemoryStream(msgBytes));
                if (msg != null)
                {
                    Id = msg.Id;
                    Sender = msg.Sender;
                    Source = msg.Source;
                    Destination = msg.Destination;
                    Body = msg.Body;
                    NetObject = msg.NetObject;
                    Time = msg.Time;
                    Direction = msg.Direction;
                    Protocol = msg.Protocol;
                }
            }
            catch (Exception)
            {
            }
        }
    }
    public enum DIRECTION
    {
        IN,
        OUT
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using SKYNET.Helper;
using SKYNET.Hook.Types;
using SKYNET.Types;

namespace SKYNET.Hook.Processor
{
    public class NetProcessor 
    {
        static List<AwaitingResponse> AwaitingRequests = new List<AwaitingResponse>();

        internal static void ProcessSend(Packet packet)
        {
            byte[] array = packet.Buffer;
            string BodyString = Encoding.Default.GetString(array);
            if (BodyString.Contains(" HTTP/"))
            {
                HttpRequest request = new HttpRequest(array);
                InvokeHttpCompleted(request, packet.Sender, packet.Source, packet.Destination);
            }
            else
            {
                InvokePacketCompleted(packet);
            }
        }
        public static void ProcessRecv(Packet packet)
        {
            //Main.Write("RecvProcessor", $"Socket {packet.Socket}", Color.Gray);
            byte[] array = packet.Buffer;
            IntPtr socket = packet.Socket;
            string BodyString = Encoding.Default.GetString(array);

            if (BodyString.Contains("HTTP/"))
            {
                HttpResponse response = new HttpResponse(array);
                if (response != null && response.ContentLength != 0)
                {
                    if (response.ContentLength != response.Body.Length)
                    {
                        AwaitingResponse newAwaiter = new AwaitingResponse();
                        newAwaiter.Sender = packet.Sender;
                        newAwaiter.Awaiting = true;
                        newAwaiter.BodySize = response.ContentLength;
                        newAwaiter.Socket = packet.Socket;
                        newAwaiter.Response = response;

                        //Main.Write("NetProcessor", $"Awaiting {response.ContentLength - response.Body.Length} bytes from {socket}", Color.Gray);

                        if (response.Body.Length != 0)
                        {
                            newAwaiter.Body.AddRange(response.Body);
                        }
                        AwaitingRequests.Add(newAwaiter);
                    }
                    else
                    {
                        InvokeHttpCompleted(response, packet.Sender, packet.Source, packet.Destination);
                    }
                }
            }
            else
            {
                AwaitingResponse Awaiter = AwaitingRequests.Find(a => a.Socket == socket);
                if (Awaiter != null)
                {
                    if (Awaiter.Awaiting)
                    {
                        if (array.Length + Awaiter.Body.Count < Awaiter.BodySize)
                        {
                            //Main.Write("NetProcessor", $"Adding {array.Length} bytes, waiting {Awaiter.BodySize}, received {array.Length + Awaiter.Body.Count }", Color.Gray);
                            Awaiter.Body.AddRange(array);
                        }
                        else if (array.Length + Awaiter.Body.Count == Awaiter.BodySize)
                        {
                            //Main.Write("NetProcessor", $"Completed Message with {Awaiter.BodySize} bytes", Color.Gray);

                            Awaiter.Body.AddRange(array);
                            Awaiter.Response.SetBody(Awaiter.Body.ToArray());
                            Awaiter.Response.BodyString = Encoding.Default.GetString(Awaiter.Body.ToArray());
                            InvokeHttpCompleted(Awaiter.Response, Awaiter.Sender, packet.Source, packet.Destination);
                            AwaitingRequests.Remove(Awaiter);
                        }
                        else
                        {
                            Main.Write("NetProcessor", $"Ups the Length Message not match in Socket {Awaiter.Socket}, {Awaiter.BodySize} bytes, Awaiting", Color.Red);
                        }
                    }
                    else
                    {
                        AwaitingRequests.Remove(Awaiter);
                    }
                }
                else
                {
                    InvokePacketCompleted(packet);
                }
            }

        }
        private static void InvokePacketCompleted(Packet packet)
        {
            if (packet.Buffer.Length > 10)
            {
                if (Main.HookInterface.DumpToConsole)
                {
                    int Id = GeneratePacketId();
                    NetMessage netMessage = new NetMessage();
                    netMessage.Id = Id;
                    netMessage.Sender = packet.Sender;
                    netMessage.Source = packet.Source;
                    netMessage.Destination = packet.Destination;
                    netMessage.Body = packet.Buffer;
                    netMessage.NetObject = packet;
                    netMessage.Time = DateTime.Now;
                    netMessage.Direction = packet.Direction;
                    netMessage.Protocol = packet.Protocol;

                    Main.HookInterface.InvokePacketReceived(netMessage);
                    switch (packet.Direction)
                    {
                        case DIRECTION.IN:
                            Main.Write(packet.Sender, $"Received Message from {packet.Destination}, {packet.Buffer.Length} bytes", Color.White, Id.ToString());
                            break;
                        case DIRECTION.OUT:
                        {
                            if (packet.OriginalDestination == null)
                            {
                                Main.Write(packet.Sender, $"Sent Message to {packet.Destination}, {packet.Buffer.Length} bytes", ColorTranslator.FromHtml("#CDCDCD"), Id.ToString());
                                break;
                            }
                            if (packet.OriginalDestination.Address.ToString() == packet.Destination.Address.ToString() && packet.OriginalDestination.Port == packet.Destination.Port)
                            {
                                Main.Write(packet.Sender, $"Sent Message to {packet.Destination}, {packet.Buffer.Length} bytes", ColorTranslator.FromHtml("#CDCDCD"), Id.ToString());
                                break;
                            }
                            Main.Write(packet.Sender, $"Redirecting Message from {packet.OriginalDestination} to {packet.Destination}, {packet.Buffer.Length} bytes", ColorTranslator.FromHtml("#CDCDCD"), Id.ToString());
                        }
                        break;
                    }
                }
            }
        }
        public static void InvokeHttpCompleted(HttpBase HttpMessage, string Sender, IPEndPoint Source, IPEndPoint Destination)
        {
            try
            {
                if (Main.HookInterface.DumpToConsole)
                {
                    int Id = GeneratePacketId();
                    NetMessage netMessage = new NetMessage();
                    netMessage.Id = Id;
                    netMessage.Sender = Sender;
                    netMessage.Source = Source;
                    netMessage.Destination = Destination;
                    netMessage.NetObject = HttpMessage;
                    netMessage.Time = DateTime.Now;
                    netMessage.Direction = HttpMessage.Type == HttpBase.HttpType.HttpRequest ? DIRECTION.OUT : DIRECTION.IN;
                    netMessage.Protocol = ProtocolType.Tcp;

                    List<byte> CompleteBody = new List<byte>();
                    CompleteBody.AddRange(HttpMessage.Header);
                    CompleteBody.AddRange(HttpMessage.Body);
                    netMessage.Body = CompleteBody.ToArray();

                    Main.HookInterface.InvokePacketReceived(netMessage);

                    if (HttpMessage is HttpResponse)
                    {
                        Main.Write(Sender, $"Received HttpResponse from {Destination}, {CompleteBody.Count} bytes", Color.White, Id.ToString());
                    }
                    else if (HttpMessage is HttpRequest)
                    {
                        Main.Write(Sender, $"Sent HttpRequest to {Destination}, {CompleteBody.Count} bytes", ColorTranslator.FromHtml("#CDCDCD"), Id.ToString());
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }

        private static int GeneratePacketId()
        {
            return new Random().Next(1000, 9999999);
        }
    }

    public class AwaitingResponse
    {
        public string Sender { get; set; }
        public HttpResponse Response { get; set; }
        public bool Awaiting { get; set; }
        public long BodySize { get; set; }
        public IntPtr Socket { get; set; }
        public List<byte> Body { get; set; }

        public AwaitingResponse()
        {
            Body = new List<byte>();
        }

    }
}
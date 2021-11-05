using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using SKYNET.Helper;
using SKYNET.Types;

namespace SKYNET
{
    public class DumpManager : IDisposable
    {
        private static string DumpDirectory;
        private string Filename;

        private Stream outputStream;
        private FileStream fileStream;

        public DumpManager(string Directory)
        {
            DumpDirectory = Directory;
            Filename = GenerateName();
            ClearEmptyDumps();
        }
        public DumpManager()
        {
        }
        public void Initialize()
        {
            modCommon.EnsureDirectoryExists(DumpDirectory);
            outputStream = new FileStream(DumpDirectory + "/" + Filename + ".dump", FileMode.OpenOrCreate);
        }
        public List<NetMessage> ReadDump(string filePath)
        {
            List<NetMessage> result = new List<NetMessage>();
            if (!File.Exists(filePath)) return result;

            fileStream = new FileStream(filePath, FileMode.Open);
            bool isSize = true;
            int Size = 0;
            int Position = 0;
            byte[] FileData = fileStream.ReadBytes((int)fileStream.Length);
            while (true)
            {
                if (isSize)
                {
                    if (Position + 5 > fileStream.Length) break;

                    byte[] size = new byte[5];
                    Array.Copy(FileData, Position, size, 0, 5);
                    Size = GetSize(size);
                    Position += 5;
                    isSize = false;
                }
                else
                {
                    if (Position + Size > fileStream.Length) break;
                    byte[] MsgBytes = new byte[Size];
                    Array.Copy(FileData, Position, MsgBytes, 0, Size);
                    NetMessage msg = new NetMessage();
                    msg.Deserialize(MsgBytes);
                    result.Add(msg);
                    Position += Size;
                    isSize = true;
                }
                if (fileStream.Length == Position)
                {
                    break;
                }
            }
            return result;
        }
        public void WriteDump(NetMessage msg)
        {
            try
            {
                byte[] Body = msg.Serialize();
                byte[] Size = GetSize(Body.Length);
                outputStream.Write(Size, 0, Size.Length);
                outputStream.Write(Body, 0, Body.Length);
            }
            finally
            {
                ///
            }
        }
        private static byte[] GetSize(int Length)
        {
            string stringLength = Length.ToString();
            string formattedLength = "";
            switch (stringLength.Length)
            {
                case 1:  formattedLength = "0000" + stringLength; break;
                case 2:  formattedLength = "000" + stringLength; break;
                case 3:  formattedLength = "00" + stringLength; break;
                case 4:  formattedLength = "0" + stringLength; break;
                case 5:  formattedLength = stringLength; break;
                default: formattedLength = stringLength; break;
            }
            return Encoding.Default.GetBytes(formattedLength);
        }
        private static int GetSize(byte[] byteSize)
        {
            string stringLength = Encoding.Default.GetString(byteSize);
            if (int.TryParse(stringLength, out int lenght))
            {
                return lenght;
            }
            return 0;
        }
        internal static string GenerateName()
        {
            DateTime d = DateTime.Now;
            return $"{d.Year}.{d.Month}.{d.Day} {d.Hour}.{d.Minute}.{d.Second}";  
        }
        public void Dispose()
        {
            outputStream?.Close();
            outputStream?.Dispose();
            ClearEmptyDumps();
        }
        private void ClearEmptyDumps()
        {
            foreach (var item in Directory.GetFiles(DumpDirectory, "*.dump"))
            {
                if (item != Filename && new FileInfo(item).Length == 0)
                {
                    try
                    {
                        File.Delete(item);
                    }
                    catch { }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using SKYNET.Hook.Types;
using SKYNET.Helper;
using static SKYNET.Hook.Types.WinSockHelper;

namespace SKYNET.Helper
{
    public static class IntPtrExtentions
    {
        public static string GetUnicodeString(this IntPtr ptr)
        {
            STRING uni = Marshal.PtrToStructure<STRING>(ptr);
            return uni.Content;
        }
        public unsafe static byte[] ReadBytes(this IntPtr address, int count)
        {
            byte[] array = new byte[count];
            byte* ptr = (byte*)(void*)address;
            for (int i = 0; i < count; i++)
            {
                array[i] = ptr[i];
            }
            return array;
        }

        public static IntPtr GetPtr(this byte[] buffer)
        {
            GCHandle gCHandle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            return gCHandle.AddrOfPinnedObject();
        }
        public static byte[] GetBytes(this IntPtr buffer, int length)
        {
            byte[] array = new byte[length];
            Marshal.Copy(buffer, array, 0, length);
            return array;
        }
        public static IPEndPoint GetSourceIPEndPoint(this IntPtr socket)
        {
            SOCKADDR_IN socketAddress = default(SOCKADDR_IN);
            int socketAddressSize = Marshal.SizeOf((object)socketAddress);
            getsockname(socket, ref socketAddress, ref socketAddressSize);
            IPAddress Address = new IPAddress(socketAddress.sin_addr);
            int Port = Ws2_32.ntohs(socketAddress.sin_port);

            return new IPEndPoint(Address, Port);
        }

        public static IPEndPoint GetDestinationIPEndPoint(this IntPtr socket)
        {
            SOCKADDR_IN socketAddress = default(SOCKADDR_IN);
            int socketAddressSize = 16;
            getpeername(socket, ref socketAddress, ref socketAddressSize);
            IPAddress Address = new IPAddress(socketAddress.sin_addr);
            int Port = Ws2_32.ntohs(socketAddress.sin_port);

            return new IPEndPoint(Address, Port);
        }

        public static T[] ToTypedArray<T>(this Array input)
        {
            return input?.Cast<T>().ToArray();
        }
        public static IEnumerable<TAttr> GetCustomAttributes<TAttr>(this Type type, bool inherit = false, Func<TAttr, bool> predicate = null) where TAttr : Attribute
        {
            return type.GetCustomAttributes(typeof(TAttr), inherit).Cast<TAttr>().Where(predicate ?? ((Func<TAttr, bool>)((TAttr a) => true)));
        }

        public static bool IsBlittable(this Type T)
        {
            if ((object)T == null)
            {
                return false;
            }
            while (T.IsArray)
            {
                T = T.GetElementType();
            }
            if (T.IsEnum)
            {
                return true;
            }
            try
            {
                Marshal.SizeOf(T);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

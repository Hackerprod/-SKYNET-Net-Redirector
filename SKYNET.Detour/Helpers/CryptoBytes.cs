using System;

namespace SKYNET.Helper
{
    public static class BytesHelper
    {
        public static string ToHexStringUpper(byte[] data)
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

        // Explanation is similar to ToHexStringUpper
        // constant 55 -> 87 and -7 -> -39 to compensate for the offset 32 between lowercase and uppercase letters
        public static string ToHexStringLower(byte[] data)
        {
            if (data == null)
                return null;
            char[] c = new char[data.Length * 2];
            int b;
            for (int i = 0; i < data.Length; i++)
            {
                b = data[i] >> 4;
                c[i * 2] = (char)(87 + b + (((b - 10) >> 31) & -39));
                b = data[i] & 0xF;
                c[i * 2 + 1] = (char)(87 + b + (((b - 10) >> 31) & -39));
            }
            return new string(c);
        }

        public static byte[] FromHexString(string hexString)
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

        public static string ToBase64String(byte[] data)
        {
            if (data == null)
                return null;
            return Convert.ToBase64String(data);
        }

        public static byte[] FromBase64String(string s)
        {
            if (s == null)
                return null;
            return Convert.FromBase64String(s);
        }
    }

}
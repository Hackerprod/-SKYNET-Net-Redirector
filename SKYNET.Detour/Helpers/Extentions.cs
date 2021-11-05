using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.Helper
{
    public static class Extentions
    {
        public static string GetString(this byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }
    }
}

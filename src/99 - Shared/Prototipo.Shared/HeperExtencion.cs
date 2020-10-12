using System;
using System.Security.Cryptography;
using System.Text;

namespace Prototipo.Shared
{
    public static class HeperExtension
    {
        public static string ToMd5(this string value)
        {
            var hash = "";
            using (var md5 = MD5.Create())
            {
                var hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
                hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
            return hash;
        }
    }
}

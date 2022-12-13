using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace srrdb
{
    public static class Functions
    {
        public static string SrrFileFullPath(string releaseName)
        {
            return SrrFilePathOnly(releaseName) + releaseName + ".srr";
        }

        public static string SrrFilePathOnly(string releaseName)
        {
            string hashStr = GetSrrHash(releaseName);
            string path = hashStr.Substring(0, 1) + Path.DirectorySeparatorChar + hashStr.Substring(1, 2) + Path.DirectorySeparatorChar;

            return path;
        }

        public static string GetSrrHash(string srrName)
        {
            string releaseNameLower = srrName.ToLower();

            SHA1 sha1 = SHA1.Create();
            byte[] hashStr = sha1.ComputeHash(Encoding.UTF8.GetBytes(releaseNameLower));
            string hash = string.Concat(hashStr.Select(b => b.ToString("x2")));

            return hash;
        }
    }
}

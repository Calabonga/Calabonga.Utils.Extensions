using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Calabonga.Utils.Extensions
{
    /// <summary>
    /// System utilities
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Compute Hash
        /// </summary>
        /// <param name="filePath"></param>
        public static byte[] ComputeFileHash(string filePath)
        {
            var runCount = 1;
            while (runCount < 4)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        throw new FileNotFoundException();
                    }

                    using var fs = File.OpenRead(filePath);
                    return SHA1.Create().ComputeHash(fs);
                }
                catch (IOException ex)
                {
                    if (runCount == 3 || ex.HResult != -2147024864)
                    {
                        throw;
                    }
                    else
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(Math.Pow(2, runCount)));
                        runCount++;
                    }
                }
            }

            return new byte[20];
        }

        /// <summary>
        /// Generate ETag for content bytes
        /// </summary>
        /// <param name="key"></param>
        /// <param name="contentBytes"></param>
        public static string GetETag(string key, byte[] contentBytes)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            var combinedBytes = Combine(keyBytes, contentBytes);
            return GenerateETag(combinedBytes);
        }

        private static string GenerateETag(byte[] data)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(data);
                var hex = BitConverter.ToString(hash);
                return hex.Replace("-", "");
            }
        }

        private static byte[] Combine(byte[] a, byte[] b)
        {
            var c = new byte[a.Length + b.Length];
            Buffer.BlockCopy(a, 0, c, 0, a.Length);
            Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
    }
}

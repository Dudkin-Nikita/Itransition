using System;
using System.Security.Cryptography;
using System.Text;

namespace Task_3
{
    public static class Generator
    {
        public static string KeyGenerator()
        {
            byte[] buffer = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return Convert.ToHexString(buffer);
        }
        public static string MoveGenerator(string[] moves)
        {
            int rand = RandomNumberGenerator.GetInt32(moves.Length);
            return moves[rand];
        }
        public static string HMACGenerator(string move, string key)
        {
            var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(move));
            return Convert.ToHexString(hash);
        }
    }
}

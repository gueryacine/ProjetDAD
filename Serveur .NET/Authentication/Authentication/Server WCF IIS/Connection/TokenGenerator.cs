using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Server_WCF_IIS.Connection
{
    public class TokenGenerator
    {
        private static TokenGenerator instance;

        private TokenGenerator() { }

        public static TokenGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TokenGenerator();
                }
                return instance;
            }
        }
        public string BuildSecureToken(int length)
        {
            var buffer = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetNonZeroBytes(buffer);
            }
            return Convert.ToBase64String(buffer);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Server_WCF_IIS.Decrypt
{
    class DicoTest : Strategy
    {
        public override bool DecryptInterface(byte[] sbOut, byte[] strKey)
        {
            for (int i = 0; i < sbOut.Length; i += strKey.Length)
            {
                sbOut += (sbOut[i] ^ strKey[]);
            }

            return true;
        }
    }
}
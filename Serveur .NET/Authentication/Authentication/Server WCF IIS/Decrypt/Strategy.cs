using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_WCF_IIS.Decrypt
{
    abstract class Strategy
    {
        public abstract string DecryptInterface(byte[] byFile, byte[] strKey);
        public abstract void ReadFile(byte[] byFile);
    }
}

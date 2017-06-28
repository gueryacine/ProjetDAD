using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_WCF_IIS.Decrypt
{
    abstract class Strategy
    {
        public abstract bool DecryptInterface(byte[] byFile, byte[] strKey);
        public abstract void ReadFile();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server_WCF_IIS.Decrypt
{
    class Context
    {
        private Strategy _strategy;
        private byte[] strFile;
        private byte[] strKey;

        // Constructor
        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.ReadFile(strFile);
        }
    }
}
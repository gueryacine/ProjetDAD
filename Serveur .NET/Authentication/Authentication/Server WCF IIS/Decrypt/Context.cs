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
        private WebReferenceJEE.responseclass res;

        // Constructor
        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        public WebReferenceJEE.responseclass ContextInterface()
        {
            res =  _strategy.ReadFile(strFile);
            return res;
        }
    }
}
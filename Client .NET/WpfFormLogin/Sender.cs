using ClientWPF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfFormLogin
{
    public class Sender
    {
        static Sender _instance;

        public static Sender GetInstance()
        {
            if (_instance == null)
                _instance = new Sender();
            return _instance;
        }
        public string SendFiles(byte[][] files)
        {
            AuthenticationProxy proxy = new AuthenticationProxy();
            Server_WCF_IIS.MSG msg = new Server_WCF_IIS.MSG()
            {
                Op_name = "LoadFiles",
                data = files,
                TokenApp = "",
                TokenUser = "",
                Password = "",
                Email = ""
            };
            msg = proxy.Dispatching(msg);
            return msg.Op_statut.ToString();
        }
        
    }
}


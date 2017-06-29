using ClientWPF;
using Server_WCF_IIS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public string SendFiles(byte[][] files, string[] filename)
        {
            AuthenticationProxy proxy2 = new AuthenticationProxy();
            MSG msgi = new MSG()
            {
                Op_name = "LoadFiles",
                FileName = filename,
                data = files,
                TokenUser = "",
            };
            msgi = proxy2.Dispatching(msgi);
            return msgi.Op_statut.ToString();
        }
        
    }
}


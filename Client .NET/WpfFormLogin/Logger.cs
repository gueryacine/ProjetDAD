using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ClientWPF.Model;

namespace ClientWPF
{
    public class Logger
    {
        static Logger _instance;

        public static Logger GetInstance()
        {
            if (_instance == null)
                _instance = new Logger();
            return _instance;
        }

        public string Login(string email, string password, string AppToken)
        {
            if (email.Length == 0 || password.Length == 0 || !Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                return "False";
            }
            else
            {
                //Logique metier
                AuthenticationProxy proxy = new AuthenticationProxy();
                string[] files = new string[] { "" };
                Server_WCF_IIS.MSG msg = new Server_WCF_IIS.MSG()
                {
                    Op_name = "LoginByToken",
                    TokenApp = AppToken,
                    TokenUser = "",
                    Password = password,
                    Email = email
                };
                // TODO add msg.Files
                msg = proxy.Dispatching(msg);
                return msg.Op_statut.ToString();
            }
        }
    }
}

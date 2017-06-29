using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using WpfFormLogin.Model;

namespace WpfFormLogin
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
            if (email.Length == 0 || password.Length == 0)
            {
                return  "Fill all form";
            }
            else if (!Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                return "Enter a valid email";
            }
            else
            {
                Authentication Logged = new Authentication();
                return "Logged";
            }
        }
    }
}

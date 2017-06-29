using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfFormLogin.Model
{
    public class Authentication
    {
        public static bool Authenticate(string email, string Password)
        {
            return true; // Do authentication against database, web service, whatever
        }
    }
}

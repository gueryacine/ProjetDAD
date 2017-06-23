using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.AuthenticationReference;

namespace Client
{
    public class Program
    {

        static void Main(string[] args)
        {
            AuthenticationProxy proxy = new AuthenticationProxy();
            string[] files = new string[] { "" } ;
            Server_WCF_IIS.MSG msg = new Server_WCF_IIS.MSG();
            msg.Op_name = "LoginByToken";
            msg.TokenApp = "456e7472657a20766f7472652070687261736520696369";
            msg.TokenUser = "";
            // TODO add msg.Files

            msg = proxy.Dispatching(msg);

            Console.WriteLine("Value op statut : {0}, info: {1}", msg.Op_statut.ToString(), msg.Op_infos);
            Console.Read();

        }
       
    }
}

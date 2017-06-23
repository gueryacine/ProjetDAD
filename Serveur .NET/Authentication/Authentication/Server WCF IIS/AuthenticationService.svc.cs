using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server_WCF_IIS
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AuthenticationService : IAuthenticationService
    {
        private MSG msg;
        public AuthenticationService() { msg = new MSG(); }

        public MSG Dispatching(MSG msg)
        {
            if (msg.Op_name == "LoginByToken")
            {
                //LoginByToken(msg.TokenApp, msg.TokenUser, msg.)
                if (msg.TokenApp == "456e7472657a20766f7472652070687261736520696369")
                {
                    this.msg.Op_infos = "Opération ok";
                    this.msg.Op_statut = true;
                }
                else
                {
                    this.msg.Op_infos = "Votre application n'est pas autorisée à communiquer avec nos serveurs.";
                    this.msg.Op_statut = false;
                }
            }

            return this.msg;
        }

        public string LoginByPassword(string username, string password, string tokenApp)
        {

            throw new NotImplementedException();//find user by username tchekc password
        }

        public string LoginByToken(string tokenApp, string tokenUser, List<string> files)
        {
            msg.TokenApp = tokenApp;
       
            //find token
            return msg.TokenApp;
        }

        public bool CheckAppToken(string appToken)
        {
            return true;
        }

    }
    class Program
    {
        //private static string uri;
        private static ServiceHost host;
        private static bool open;
        static void Main(string[] args)
        {
            open = false;
            Affichage();
            if (ini_serv()) Console.WriteLine("Serveur en écoute"); ;
            Console.Read();
        }
        static bool ini_serv()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Tentative d'initialisation du serveur WCF");
            try
            {
                host.Open();
                open = true;
                Console.WriteLine("Paramétrage ok");
            }
            catch (Exception x)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Echec");
                Console.WriteLine(x.ToString());
                open = false;
            }
            return open;
        }
        static void Affichage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("*************** WCF Server ***************\n");
        }
    }
}

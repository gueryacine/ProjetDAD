using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Windows;

namespace Server_WCF_IIS
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AuthenticationService : IAuthenticationService
    {
        private MSG msg;
        private string tokenApp;
        private string email;
        private string password;

        public AuthenticationService() { msg = new MSG();}

        public MSG Dispatching(MSG msg)
        {
            if (msg.Op_name == "LoginByToken")
            {
                tokenApp = msg.TokenApp;
                email = msg.Email;
                password = msg.Password;
                LoginByToken(tokenApp);
                //MessageBox.Show(email, "email");
            }
            return this.msg;
        }
        public string LoginByToken(string tokenApp)
        {
            if (tokenApp == "456e7472657a20766f7472652070687261736520696369")
            {
                msg.Op_infos = "Opération ok";
                MessageBox.Show(msg.Op_statut.ToString(), "Token_Application");
                LoginByPassword(email, password);
               // msg.Op_statut = res;
            }
            else
            {
                msg.Op_infos = "Votre application n'est pas autorisée à communiquer avec nos serveurs.";
                msg.Op_statut = false;
            }
            return msg.Op_statut.ToString();
        }
        public string LoginByPassword(string username, string password)
        {
            Connector connector = new Connector();
            connector.Connect(username,password);
            msg.Op_statut = true;
            return msg.Op_statut.ToString();
        }

        public string LoadFiles(List<string> files)
        {
            throw new NotImplementedException();//find user by username tchekc password
        }

    }

}

using iTextSharp.text;
using iTextSharp.text.pdf;
using Server_WCF_IIS.Decrypt;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        private string tokenUser;
        private string email;
        private string password;
        private string[] filename;
        private byte[][] files;
        private bool stopDecrypt { get; set; }

        public AuthenticationService() { msg = new MSG(); }

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
            else if (msg.Op_name == "LoadFiles")
            {
                files = msg.data;
                email = msg.Email;
                filename = msg.FileName;
                LaunchDecrypt(files, filename, email);
            }
            return this.msg;
        }
            public string LoginByToken(string tokenApp)
        {
            if (tokenApp == "456e7472657a20766f7472652070687261736520696369")
            {
                msg.Op_infos = "Opération ok";
                msg.Op_statut = true;
                MessageBox.Show(msg.Op_statut.ToString(), "Token_Application");
                LoginByPassword(email, password);
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
            tokenUser = connector.Connect(username, password);
            //MessageBox.Show(tokenUser, "TokenUser_return");
            msg.Op_statut = true;
            return this.msg.Op_statut.ToString();
        }

        public string LaunchDecrypt(byte[][] files, string[] namefile, string username)
        {

            Context context;
            //context = new Context(new DicoTest(files, namefile, username));
            //context.ContextInterface();

            context = new Context(new KeygenTest(files, namefile, username));
            context.ContextInterface();

            if (stopDecrypt == true)
            {
               
                msg.Op_infos = "Decryptage OK";
                msg.Op_statut = true;
                
                //GeneratePDF()
                //MessageBox.Show(msg.Op_statut.ToString(), "STOPDECRYPT");

            }
            return this.msg.Op_statut.ToString();
        }

        public void GeneratePDF(string email, string key, string namefile)
        {
            var doc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();
            doc.Add(new iTextSharp.text.Paragraph(email));
            doc.Add(new iTextSharp.text.Paragraph(key));
            doc.Add(new iTextSharp.text.Paragraph(namefile));

            writer.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;

            MailMessage mm = new MailMessage("exiaprojet2017@gmail.com", "martin.juguera@viacesi.fr")
            {
                Subject = "Decrypt",
                IsBodyHtml = true,
                Body = "See attachment"
            };

            mm.Attachments.Add(new Attachment(memoryStream, "decrypt.pdf"));
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("exiaprojet2017@gmail.com", "02mai1989")
            };

            smtp.Send(mm);
        }
    }

}

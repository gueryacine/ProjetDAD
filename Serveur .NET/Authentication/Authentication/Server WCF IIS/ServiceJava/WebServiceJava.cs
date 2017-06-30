using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Server_WCF_IIS.ServiceJava
{
    public class WebServiceJava
    {
        private WebReferenceJEE.SoapService service;
        private static WebServiceJava instance;
        string key { get; set; }
        string email { get; set; }
        bool result { get; set; }

        private WebServiceJava()
        {
            service = new WebReferenceJEE.SoapService();
        }

        public static WebServiceJava Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebServiceJava();
                }
                return instance;
            }
        }
        public void SendString(string Namefile, string key, string DecryptString)
        {
            service.SendFileForControlAsync(Namefile, key, DecryptString);
        }
        public WebReferenceJEE.responseclass GetResponse()
        {
            try
            {
                WebReferenceJEE.responseclass resultat = service.SendResponseTraitement();

                return resultat;
            }
            catch(Exception e)
            {
                return null;
            }
            
        }
    }


}

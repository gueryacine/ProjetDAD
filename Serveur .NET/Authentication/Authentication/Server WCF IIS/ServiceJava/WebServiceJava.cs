using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Server_WCF_IIS.ServiceJava
{
    public class WebServiceJava
    {
        private WebReferenceJEE.SoapService service;
        private static WebServiceJava instance;

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
        public string SendString(string Namefile, string key, string DecryptString)
        {
            string Decoded = EncodeBinary(DecryptString);
            service.SendFileForControlAsync(Namefile, key, Decoded);
            return null;
        }
        public string SendId(int id)
        {
            service.SendResponseTraitement(id);
            return null;
        }
        private string EncodeBinary(string str)
        {
            byte[] binaires = Encoding.ASCII.GetBytes(str);
            string strres = "";

            foreach (byte bin in binaires)
            {
                strres += Convert.ToString(bin, 2);
            }
            return strres;
        }
    }


}

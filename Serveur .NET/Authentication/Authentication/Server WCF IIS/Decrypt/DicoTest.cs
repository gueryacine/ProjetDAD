using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows;
using Server_WCF_IIS.ServiceJava;
using System.Threading;

namespace Server_WCF_IIS.Decrypt
{
    class DicoTest : Strategy
    {
        public char[] CharArray { get; set; }
        public byte[][] FileArray { get; set; }
        string[] fileName;
        string nameUser;
        string key { get; set; }
        string decryptedFile { get; set; }
        public WebReferenceJEE.responseclass res { get; set; }

        public DicoTest(byte[][] byFile, string[] namefile, string username)
        {
            FileArray = new byte[byFile.Length][];
            FileArray = byFile;
            fileName = namefile;
            nameUser = username;
            CharArray = new char[10000];
        }

        public override WebReferenceJEE.responseclass ReadFile(byte[] byFile)
        {
            WebReferenceJEE.responseclass finalres;
            char[] delimiterChars = { ' ', ',' };
            var list = new List<string>();
            var fileStream = new FileStream(@"C:\Users\Caraï\Desktop\ProjetDAD-master\ProjetDAD-master\ProjetDAD\Serveur .NET\Generateur\dico.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                
                while ((line = streamReader.ReadLine()) != null)
                {
                    foreach (string s in line.Split(','))
                    {
                        list.Add(line);
                    }
                    CharArray = line.ToCharArray();
                }

                byte[] dico = new byte[CharArray.Length];
                int i = 0;
                for (i = 0; i < CharArray.Length; i++)
                {
                    dico[i] = Convert.ToByte(CharArray[i]);
                }
                //MessageBox.Show(dico.ToString());
               finalres=  DecryptProcess(dico);
            }
            MessageBox.Show("files", "All Files XOR OK");
            return finalres;
        }

        public WebReferenceJEE.responseclass DecryptProcess(byte[] dico)
        {
            WebReferenceJEE.responseclass decrypt = null;
            while (res.FindEmail == false && Thread.CurrentThread.IsAlive)
            {
                int j = 0;
                foreach (byte[] file in FileArray)
                {
                    string decryptedFile = DecryptInterface(file, dico); //décryptage
                    MessageBox.Show(decryptedFile, "resultat");
                    //appel du webservice envoie du string a la plateforme Java
                    WebServiceJava.Instance.SendString(fileName[j], key, decryptedFile);

                    Thread tasks = new Thread(() => { res = GetResponse(); });
                    Thread.Sleep(1);

                    if (res.FindEmail == true)
                    {
                        decrypt.FindEmail = true;
                        MessageBox.Show(res.ToString(), "fichier décripté");
                    }
                    else if (res.FindEmail == false)
                    {
                        decrypt.FindEmail = false;
                        MessageBox.Show(res.ToString(), "fichier Non décripté");
                    }
                    j++;
                }
            }
            return decrypt;
        }

        public WebReferenceJEE.responseclass GetResponse()
        {
            res = WebServiceJava.Instance.GetResponse();
            return res;
        }

        public override string DecryptInterface(byte[] sbOut, byte[] strKey)
        {
            for (int i = 0; i < sbOut.Length; i += strKey.Length)
            {
                for (int j = 0; j < strKey.Length && (i * 6 + j) < sbOut.Length; j++) // Prevent file index overflow
                {
                    sbOut[i * 6 + j] ^= strKey[j];
                    key = CharArray[j].ToString();
                }
            }
            string s = BytesToBinaire(sbOut).ToString();
            return s;
        }

        static StringBuilder BytesToBinaire(byte[] bytes)
        {
            StringBuilder binary = new StringBuilder();
            foreach (byte b in bytes)
            {
                int val = b;
                for (int i = 0; i < 8; i++)
                {
                    binary.Append((val & 128) == 0 ? 0 : 1);
                    val <<= 1;
                }
            }
            return binary;
        }
    }
}

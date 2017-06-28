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
        //public byte[] dico = new byte[1000];
        public char[] CharArray { get; set; }
        public byte[][] FileArray { get; set; }
        string[] fileName;
        string nameUser;
        string key { get; set; }
        string decryptedFile { get; set; }

        public DicoTest(byte[][] byFile, string[] namefile, string username)
        {
            FileArray = new byte[byFile.Length][];
            FileArray = byFile;
            fileName = namefile;
            nameUser = username;
            CharArray = new char[10000];
        }

        public override void ReadFile(byte[] byFile)
        {
            //JMSReference.DecryptWebService obj = new JMSReference.DecryptWebService(); //webservice ref
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
                DecryptProcess(dico);
            }
            MessageBox.Show("All Files XOR OK");
        }

        public void DecryptProcess(byte[] dico)
        {
            while ( Thread.CurrentThread.IsAlive)//keygen.nextKeyExist() &&
            {
                int j = 0;
                foreach (byte[] file in FileArray)
                {
                    string res = DecryptInterface(file, dico); //décryptage
                    //appel du webservice envoie du string a la plateforme Java
                    WebServiceJava.Instance.SendString(fileName[j], key, decryptedFile);
                    j++;
                }
            }
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
                MessageBox.Show(key,"key");
                //decryptedFile =
            }
            string s = Encoding.UTF8.GetString(sbOut, 0, sbOut.Length);
            MessageBox.Show(s, "XOR OK");
            return s;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows;
using Server_WCF_IIS.ServiceJava;

namespace Server_WCF_IIS.Decrypt
{
    class KeygenTest : Strategy
    {
        public byte[][] FileArray { get; set; }
        public byte[] keyArray = new byte[1];
        string[] fileName;
        string nameUser;

        public KeygenTest(byte[][] byFile, string[] namefile, string username)
        {
            FileArray = new byte[byFile.Length][];
            FileArray = byFile;
            fileName = namefile;
            nameUser = username;
        }
        public override void ReadFile(byte[] byFile)
        {
            DecryptProcess(fileName);
        }

        private void DecryptProcess(string[] namefile)
        {
            KeyGenerator keygen = new KeyGenerator(48);
            string[] nameFile = namefile;

            while (keygen.nextKeyExist() && Thread.CurrentThread.IsAlive)
            {
                string key = keygen.GetKey();
                keyArray = ToByteArray(key);
                int i=0;
                foreach (byte[] file in FileArray)
                {
                    string decryptedFile = DecryptInterface(file, keyArray); //décryptage
                    //MessageBox.Show(decryptedFile, "XOR OK");
                    //appel du webservice envoie du string a la plateforme Java
                    WebServiceJava.Instance.SendString(fileName[i], key, decryptedFile);
                    i++;
                }
            }
        }

        public static byte[] ToByteArray(string StringToConvert)
        {
            char[] CharArray = StringToConvert.ToCharArray();
            byte[] ByteArray = new byte[CharArray.Length];

            for (int i = 0; i < CharArray.Length; i++)
            {
                ByteArray[i] = Convert.ToByte(CharArray[i]);
            }
            return ByteArray;
        }

        public override string DecryptInterface(byte[] sbOut, byte[] strKey)
        {
            for (int i = 0; i < sbOut.Length; i += strKey.Length)
            {
                for (int j = 0; j < strKey.Length && (i * 6 + j) < sbOut.Length; j++) // Prevent file index overflow
                {
                    sbOut[i * 6 + j] ^= strKey[j];
                }
            }
            string s = Encoding.UTF8.GetString(sbOut, 0, sbOut.Length);
            return s;
        }

    }
}
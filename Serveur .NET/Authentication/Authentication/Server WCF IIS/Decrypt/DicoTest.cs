using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows;

namespace Server_WCF_IIS.Decrypt
{
    class DicoTest : Strategy
    {
        //public byte[] dico = new byte[1000];
        public char[] CharArray = new char[1000];

        public byte[][] FileArray;
        public DicoTest(byte[][] byFile)
        {
            FileArray = new byte[byFile.Length][];
            FileArray = byFile;
        }

        public override void ReadFile(byte[] byFile)
        {
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
                foreach (byte[] file in FileArray)
                {
                    DecryptInterface(file, dico);
                    MessageBox.Show(file.ToString());
                }
            }
        }

        public override bool DecryptInterface(byte[] sbOut, byte[] strKey)
        {
            for (int i = 0; i < sbOut.Length; i += strKey.Length)
            {
                for (int j = 0; j < strKey.Length && (i * 6 + j) < sbOut.Length; j++) // Prevent file index overflow
                {
                    sbOut[i * 6 + j] ^= strKey[j];
                }
            }
            return true;
        }
    }
}

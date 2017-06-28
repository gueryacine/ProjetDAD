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
        public byte[][] dico = new byte[100][];
        public override void ReadFile()
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
                    int i = 0;
                //    foreach (var item in list.ToArray())
                //    {
                //        byte[] Bytes = new byte[100];
                //        dd.Read(Bytes, 0, Bytes.Length);
                //        dico[i] = Bytes;
                //        MessageBox.Show(dico.ToString());
                //        i++;
                //    }
                //}

                //MessageBox.Show(dico.ToString());
                //DecryptInterface(dico, dico);
            }
        }
        public override bool DecryptInterface(byte[] sbOut, byte[] strKey)
        {
            for (int i = 0; i < sbOut.Length; i += strKey.Length)
            {
                for (int j = 0; j < strKey.Length; j++)
                {
                    sbOut[i * 6 + j] ^= strKey[j];
                }
            }
            return true;
        }

    }
}

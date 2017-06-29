using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Linq;
using System.Collections.Generic;

namespace WpfFormLogin.View
{
    /// <summary>
    /// Logique d'interaction pour OpenFileDialogMultipleFilesSample.xaml
    /// </summary>
    public partial class OpenFileDialogMultipleFilesSample : Window
    {

        public OpenFileDialogMultipleFilesSample()
        {
            InitializeComponent();
        }
        public byte[][] bytearray;
        public List<string> fileName = new List<string>();
        string Answer { get; set; }
        private void BtnOpenFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    lbFiles.Items.Add(Path.GetFileName(filename));
                    fileName.Add(Path.GetFileName(filename));
                }
            }
            var result = openFileDialog.FileNames;
            bytearray = new byte[result.Length][];

            int i = 0;
            foreach (var item in result)
            {
                System.IO.FileStream dd = System.IO.File.OpenRead(item);
                byte[] Bytes = new byte[dd.Length];
                dd.Read(Bytes, 0, Bytes.Length);
                bytearray[i] = Bytes;
                i++;
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if (lbFiles.Items.Count > 0)
            {
                Sender sended = new Sender();
                Answer = sended.SendFiles(bytearray, fileName.ToArray());
                //MessageBox.Show(Answer, "ANSWER");
                //this.Hide();
                if (Answer == "True")
                {
                    MessageBox.Show(Answer, "Traitement des fichiers OK");
                    
                }
            }
        }
    }
}

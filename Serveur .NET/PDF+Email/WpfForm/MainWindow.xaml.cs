using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace WpfForm
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenererPDF_Click(object sender, RoutedEventArgs e)
        {
            var doc = new Document();
            MemoryStream memoryStream = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);

            doc.Open();
            doc.Add(new iTextSharp.text.Paragraph("First Paragraph"));

            writer.CloseStream = false;
            doc.Close();
            memoryStream.Position = 0;

            MailMessage mm = new MailMessage("exiaprojet2017@gmail.com", "exiaprojet2017@gmail.com")
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

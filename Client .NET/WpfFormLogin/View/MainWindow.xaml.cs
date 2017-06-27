﻿using System;
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
using WpfFormLogin.View;

namespace ClientWPF
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

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = emailBox.Text;
            string password = passwordBox.Password;
            string AppToken = "456e7472657a20766f7472652070687261736520696369";
            Logger Logged = new Logger();

            string Answer = Logged.Login(email,password,AppToken);
            if (Answer == "True")
            {
                errorMessage.Text = Answer;
                //this.Hide();
                OpenFileDialogMultipleFilesSample file = new OpenFileDialogMultipleFilesSample();
                file.Show();
            }
            else
            {
                errorMessage.Text = "Error on email or password";
            }
        }
    }
}

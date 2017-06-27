using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Windows;
using Server_WCF_IIS.Connection;

namespace Server_WCF_IIS
{
    public class Connector
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string tokenUser;
        private string server;
        private string database;
        private string uid;
        private string mdp;

        public Connector()
        {
            InitConnexion();
        }

        private void InitConnexion()
        {
            string connectionString = "SERVER=127.0.0.1; DATABASE=dad_db; UID=root; PASSWORD=";
            connection = new MySqlConnection(connectionString);
        }
        //connect to db
        public string Connect(string username, string password)
        {
            try
            {
                connection.Open();
                MessageBox.Show("Connection Open");
                bool CKU = Check_User(username, password);
                if (CKU == true)
                {
                    tokenUser = SelectToken(username);
                    if (tokenUser == "0")
                    {
                        tokenUser = BuildToken(username);
                        UpdateToken(tokenUser, username);
                    }
                   // MessageBox.Show(tokenUser, "TOKENUSER");
                }
            }
            catch (MySqlException co)
            {
                MessageBox.Show(co.ToString());
                MessageBox.Show("Non Connecté");
            }
            return tokenUser;
        }
        //check username+pâssword
        private bool Check_User(string username, string password)
        {
            bool credentials = false;
            string select = "SELECT * FROM User " + "WHERE EmailUser = \'" + username + "\'";
            MySqlCommand cmd = new MySqlCommand(select, connection);
            using (reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    string user_db = reader.GetString(1);
                    string hash_db = reader.GetString(2);
                    if (user_db == username)
                    {
                        string pass = Connection.EncryptPass.EncryptSHA512Managed(password);
                        if (hash_db == pass)
                        {
                            MessageBox.Show("Login OK", " Welcome to the WHITE HAT organisation");
                            credentials = true;
                            reader.Close();
                        }
                        else
                        {
                            reader.Close();
                            MessageBox.Show("Login Error", "Incorrect password.");
                        }
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Login Error", "User not found");
                    }
                }
                return credentials;
            }
        }
        //Check TokenUser
        public string SelectToken(string username)
        {
            string token = null;
            string selectToken = "SELECT UserToken FROM User " + "WHERE EmailUser = \'" + username + "\'";
            MySqlCommand cmd = new MySqlCommand(selectToken, connection);
            using (reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            token = "0";
                        }
                        else
                        {
                            token = reader.GetString(0);
                        }
                    }
                }
            }
            reader.Close();
            return token;
        }
        //Build TokenUser
        public string BuildToken(string username)
        {
            string token = null;
            int length = 20;
            token = TokenGenerator.Instance.BuildSecureToken(length);
            MessageBox.Show(token, "BUILD TOKEN");
            return token;
        }
        //Update TokenUser
        public void UpdateToken(string token, string username)
        {
            string updateToken = "UPDATE User " + "SET UserToken = \'" + token + "\'" + "WHERE EmailUser = \'" + username + "\'"; ;
            MySqlCommand cmd = new MySqlCommand(updateToken, connection);
            cmd.ExecuteNonQuery();
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM tableinfo";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            //if (this.OpenConnection() == true)
            //{
            //    //Create Command
            //    MySqlCommand cmd = new MySqlCommand(query, connection);
            //    //Create a data reader and Execute the command
            //    MySqlDataReader dataReader = cmd.ExecuteReader();

            //    //Read the data and store them in the list
            //    while (dataReader.Read())
            //    {
            //        list[0].Add(dataReader["id"] + "");
            //        list[1].Add(dataReader["name"] + "");
            //        list[2].Add(dataReader["age"] + "");
            //    }

            //    //close Data Reader
            //    dataReader.Close();

            //    //close Connection
            //    this.CloseConnection();

            //    //return list to be displayed
            //    return list;
            //}
            //else
            //{
            return list;
            //}
        }

        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, mdp, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, mdp, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
            }
        }
    }
}
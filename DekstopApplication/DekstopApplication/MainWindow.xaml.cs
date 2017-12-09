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
using DekstopApplication.AdminServiceReference;
using System.Net;
using System.Data.SqlClient;

namespace DekstopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            InitializeComponent();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }


        //Login to a Admin profile and redirect to the CMS.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameInput.Text;
            string password = PasswordInpunt.Password.ToString();
            AdminServiceClient client = new AdminServiceClient();
            

            //Brug et if statement for at tjekke at username og password ikke er null eller ikke indeholder noget 
            if(username.ToUpper() != null && password != null)
            {
                //Anvende client med login metoden og return brugeren. 
                Admin admin = client.Login(username.ToLower(), password);


                //If statement om det der bliver returned er null eller ej. Hvis den ikke er null kan du efterfølgennde sender den videre i koden herunder.
                if (admin != null)
                {
                    CMS cms = new CMS();
                    cms.Show();
                    this.Close();
                }
                else
                {
                    //Display a Message that tells you, your inputs a invalid.
                    MessageBox.Show("Brugernavn eller adgangskode er forkert prøv igen");
                }
            }
        }
    }
}

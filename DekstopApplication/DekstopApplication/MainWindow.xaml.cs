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
using DekstopApplication.AdminServiceReference;
using System.Net;
using System.Data.SqlClient;
using System.Threading;

namespace DekstopApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Instance variables
        private CMS Cms;

        public MainWindow()
        {
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            InitializeComponent();
            Cms = new CMS();
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

        /// <summary>
        /// Login method for loggin in to the CMS System.
        /// Will redirect to cms view if successfull login
        /// </summary>
        private void Login()
        {

            string username = UsernameInput.Text;
            string password = PasswordInpunt.Password.ToString();
            AdminServiceClient client = new AdminServiceClient();
            

            //Brug et if statement for at tjekke at username og password ikke er null eller ikke indeholder noget 
            if (username.ToUpper() != null && password != null)
            {
                //Anvende client med login metoden og return brugeren. 
                Admin admin = client.Login(username.ToLower(), password);
                

                //If statement om det der bliver returned er null eller ej. Hvis den ikke er null kan du efterfølgennde sender den videre i koden herunder.
                if (admin != null)
                {
                    Cms.Show();
                    this.Close();
                }
                else
                {
                    //Display a Message that tells you, your inputs a invalid.
                    MessageBox.Show("Brugernavn eller adgangskode er forkert prøv igen");
                    LoginButton.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Login button listener.
        /// Calls the Login.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Removes the login button and displayes a loading icon under long login times
            LoginButton.Visibility = Visibility.Collapsed;
            Login();
        }

        /// <summary>
        /// Listens for enter key pressed. Calls the Login method if pressed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoginButton.Visibility = Visibility.Hidden;
                Login();
            }
        }
    }
}

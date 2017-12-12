using DekstopApplication.AdminServiceReference;
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

namespace DekstopApplication.Views
{
    /// <summary>
    /// Interaction logic for AdminCreate.xaml
    /// </summary>
    public partial class AdminCreate : UserControl
    {
        
        //Instance variables
        AdminServiceClient adminClient = new AdminServiceClient();
        public delegate void ParentFunction();

        //Poiting to outside function on parent
        public ParentFunction TheFunc;

        /// <summary>
        /// Cunstroctor for the AdminCreateView
        /// </summary>
        public AdminCreate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clear all current textfields. 
        /// This is needed if more than one admin is created in the same session
        /// </summary>
        public void ClearTextFields()
        {
            UsernameInput.Text = "";
            PasswordInput.Password = "";
            PasswordRepeatInput.Password = "";
        }

        /// <summary>
        /// Closes the current view and returns to parent view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        /// <summary>
        /// Creates a new admin when button is pressed. 
        /// Gets all input from the view and assigns it to a new Admin object.
        /// Also checks to see if the password input is the same in passwordRepeat to ensure correct password.
        /// The servicereference method for creating a new admin is then called where the Admin object is set as parameter.
        /// Calls TheFunc wich contains the UpdateTable() method from the parent view.
        /// Closes the current UserControl view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAdminButton_Click(object sender, RoutedEventArgs e)
        {
            if(PasswordInput.Password.ToString() != PasswordRepeatInput.Password.ToString())
            {
                FailCheckLabel.Content = "Kodeordet stemmer ikke overens";
            }
            else
            {
                AdminServiceReference.Admin admin = new AdminServiceReference.Admin
                {
                    Username = UsernameInput.Text.ToLower(),
                    Password = PasswordInput.Password.ToString()
                };

                adminClient.Create(admin);
                TheFunc();
                ((Panel)this.Parent).Children.Remove(this);
            }
        }
    }
}

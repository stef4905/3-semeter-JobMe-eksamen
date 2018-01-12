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
using DekstopApplication.ApplierServiceReference;
using System.Text.RegularExpressions;

namespace DekstopApplication.Views
{
    /// <summary>
    /// Interaction logic for ApplierCreate.xaml
    /// </summary>
    public partial class ApplierCreate : UserControl
    {

        //Instance variables
        public delegate void ParentFunction();
        private ApplierServiceClient ApplierClient = new ApplierServiceClient();
        
        //Pointing to outside function on parent
        public ParentFunction TheFunc;

        /// <summary>
        /// Cunstroctor for the ApplierCreate User Control
        /// </summary>
        public ApplierCreate()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the current User Controll.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        /// <summary>
        /// Gets all the inputs and instaciating a new Applier object wit the values.
        /// Calls the ApplierClient.Create() method given the Applier Object.
        /// This method also ensures validation on the insertet values, to ensure they are correct for their value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string Email = EmailInput.Text;
            string Password = PasswordInput.Password.ToString();
            string PasswordCheck = PasswordCheckInput.Password.ToString();
            Applier applier = new Applier
            {
                Email = Email,
                Password = Password
            };
            if (!Regex.IsMatch(Email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                 FailCheckLabel.Content = "Skriv en valid email";
            }
            else if(Password != PasswordCheck)
            {
                FailCheckLabel.Content = "Kode ordet stemmer ikke overens";
            }
            else
            {
                ApplierClient.Create(applier);
                TheFunc(); //Calling the updateTableAndList() method on the parent User Control
                ((Panel)this.Parent).Children.Remove(this);
            }
        }
    }
}

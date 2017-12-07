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

        ApplierServiceClient applierClient = new ApplierServiceClient();
        public ApplierCreate()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string Email = EmailInput.Text;
            string Password = PasswordInput.Password.ToString();
            string PasswordCheck = PasswordCheckInput.ToString();
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
                applierClient.Create(applier);
            }


            
        }
    }
}

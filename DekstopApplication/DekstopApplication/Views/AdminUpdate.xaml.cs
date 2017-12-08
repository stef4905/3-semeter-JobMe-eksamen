using DekstopApplication.AdminServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AdminUpdate.xaml
    /// </summary>
    public partial class AdminUpdate : UserControl
    {
        AdminServiceReference.Admin adminNew = new AdminServiceReference.Admin();
        AdminServiceClient adminClient = new AdminServiceClient();
        Admin adminView = new Admin();

        public AdminUpdate(AdminServiceReference.Admin admin)
        {
            InitializeComponent();
            adminNew = admin;
            FNameInput.Text = admin.FName;
            LNameInput.Text = admin.LName;
            EmailInput.Text = admin.Email;

        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        /// <summary>
        /// Update admin in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminServiceReference.Admin admin = adminNew;

            if (!Regex.IsMatch(EmailInput.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                FailCheckLabel.Content = "Skriv en valid email";
            }
            else
            {
                if (CurrentPasswordInput.Password.ToString() == "" && NewPasswordInput.Password.ToString() == "" && NewPasswordRepeatInput.Password.ToString() == "")
                {
                    
                    admin.FName = FNameInput.Text;
                    admin.LName = LNameInput.Text;
                    admin.Email = EmailInput.Text;

                    adminClient.Update(admin);


                    ((Panel)this.Parent).Children.Remove(this);
                }

                else if (NewPasswordInput.Password.ToString() != NewPasswordRepeatInput.Password.ToString())
                {
                    FailCheckLabel.Content = "De to kodeord matcher ikke eller felterne er tomme";
                }
                else if (NewPasswordInput.Password.ToString() == "" || NewPasswordRepeatInput.Password.ToString() == "")
                {
                    FailCheckLabel.Content = "Udfyld det nye kodeord";
                }
                else if (CurrentPasswordInput.Password.ToString() != admin.Password)
                {
                    FailCheckLabel.Content = "Nuværende adgangskode passer ikke med den gamle kode";
                }
                else if (CurrentPasswordInput.Password.ToString() == admin.Password && NewPasswordInput.Password.ToString() == "" || NewPasswordRepeatInput.Password.ToString() == "")
                {
                    FailCheckLabel.Content = "Angiv et nyt kodeord";
                }
                else
                {
                    admin.Password = NewPasswordInput.Password.ToString();
                    admin.FName = FNameInput.Text;
                    admin.LName = LNameInput.Text;
                    admin.Email = EmailInput.Text;

                    adminClient.Update(admin);

                    //GuiPanelUpdate.Children.Clear();
                    
                    //GuiPanelUpdate.Children.Add(adminView);
                    ((Panel)this.Parent).Children.Remove(this);
                }
            }
        }
    }
}

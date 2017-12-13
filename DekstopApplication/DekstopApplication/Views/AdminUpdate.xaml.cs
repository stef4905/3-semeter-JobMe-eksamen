﻿using DekstopApplication.AdminServiceReference;
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

        /// <summary>
        /// Closes the current User Control view and returns to parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        /// <summary>
        /// Update Admin Method
        /// Check if the email is in the right structure by Regex.
        /// If not, a label will appear that it's not a valid email
        /// If correct, you will be able to update the admin password on the entered email.
        /// Update method is called by adminClient with Admin object as parameter() with the newly entered input.
        /// And closes the Update Admin view
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

                    admin = UpdateInput(admin);

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
                    admin = UpdateInput(admin);
                    adminClient.Update(admin);
                    ((Panel)this.Parent).Children.Remove(this);
                }
            }
        }

        /// <summary>
        /// Updates the given Admin object with the Input textfields
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public AdminServiceReference.Admin UpdateInput(AdminServiceReference.Admin admin)
        {
            admin.FName = FNameInput.Text;
            admin.LName = LNameInput.Text;
            admin.Email = EmailInput.Text;
            return admin;
        }
    }
}

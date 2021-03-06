﻿using DekstopApplication.ApplierServiceReference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ApplierUpdate.xaml
    /// </summary>
    public partial class ApplierUpdate : UserControl
    {

        //Instance variables
        private ApplierServiceClient ApplierClient = new ApplierServiceClient();
        private Applier Applier = new Applier();
        public delegate void ParentFunction();

        //Poiting to outside function on parent
        public ParentFunction TheFunc;

        /// <summary>
        /// Constructor for the ApplierUpdate User Control.
        /// Takes a Appluer object as parameter.
        /// Calls the SetAlleText method.
        /// </summary>
        /// <param name="applier"></param>
        public ApplierUpdate(Applier applier)
        {
            InitializeComponent();
            Applier = applier;
            SetAllText();
            this.DataContext = this;
        }

        /// <summary>
        /// Sets all inputs in the User Control equal to their corosponding Applier variables.
        /// Calls the CreateCheckBoxList() method.
        /// </summary>
        public void SetAllText()
        {
            EmailInput.Text = Applier.Email;
            FNameInput.Text = Applier.FName;
            LNameInput.Text = Applier.LName;
            BirtdatePicker.Text = Convert.ToString(Applier.Birthdate);
            AdressInput.Text = Applier.Address;
            PhoneInput.Text = Convert.ToString(Applier.Phone);
            DescriptionInput.Text = Applier.Description;
            HomePageInput.Text = Applier.HomePage;
            CurrentJobInput.Text = Applier.CurrentJob;
            // Checks to see if the Apllier has a image or else it sets the default image(Apllier IMAGE)
            Uri imageUri = null;
            if (Applier.ImageURL != null)
            {
                imageUri = new Uri(Applier.ImageURL, UriKind.Absolute);
            }
            else
            {
                imageUri = new Uri("https://i.imgur.com/Csasjwt.png", UriKind.Absolute);
            }
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            ApplierImage.Source = imageBitmap;
        }

        /// <summary>
        /// CLoses the current User Control view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TheFunc();
            ((Panel)this.Parent).Children.Remove(this);
        }

        /// <summary>
        /// Updates the Applier.
        /// Shows a messagebox to ensure user invoked this method on purpose.
        /// Checks and validates all inputs to ensure corrent data values.
        /// Updates the ApplierTable and calls the ApplerClient.Update() given the updated Applier object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Applier applier = Applier;
            if (!Regex.IsMatch(EmailInput.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                FailCheckLabel.Content = "Skriv en valid email";
            }
            else if (EmailInput.Text == "" || FNameInput.Text == "" || LNameInput.Text == "" || BirtdatePicker.Text == "" || AdressInput.Text == ""
                || PhoneInput.Text == "" || DescriptionInput.Text == "" || HomePageInput.Text == "" || CurrentJobInput.Text == "")
            {
                FailCheckLabel.Content = "Alle felter skal være udfyldt!";
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Er du sikker på du vil opdatere " + applier.FName + " " + applier.LName + "?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    applier.Email = EmailInput.Text;
                    applier.FName = FNameInput.Text;
                    applier.LName = LNameInput.Text;
                    applier.Birthdate = Convert.ToDateTime(BirtdatePicker.Text);
                    applier.Address = AdressInput.Text;
                    applier.Phone = Convert.ToInt32(PhoneInput.Text);
                    applier.Description = DescriptionInput.Text;
                    applier.HomePage = HomePageInput.Text;
                    applier.CurrentJob = CurrentJobInput.Text;
                 
                    bool updated = ApplierClient.Update(applier);
                    if(updated == true)
                    {
                        SuccesCheck.Content = "Brugeren er opdateret!";
                    }
                    else
                    {
                        FailCheckLabel.Content = "Brugeren er allerede opdateret. Tryk tilbage og prøv igen! OPS: Dette kan tage nogle sekunder";
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    //No Code here
                }
            }

        }






    }


}


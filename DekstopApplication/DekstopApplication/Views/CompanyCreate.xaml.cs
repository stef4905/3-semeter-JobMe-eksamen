﻿using DekstopApplication.CompanyServiceReference;
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
    /// Interaction logic for CompanyCreate.xaml
    /// </summary>
    public partial class CompanyCreate : UserControl
    {
        //Instance variables
        private CompanyServiceReference.Company Company = new Company();
        private CompanyServiceClient CompanyClient = new CompanyServiceClient();
        private List<BusinessType> BusinessTypeList = new List<BusinessType>();
        public delegate void ParentFunction(); //Delegate function from parent user control

        //delegate function variable
        public ParentFunction TheFunc;

        /// <summary>
        /// Constructor for the CompanyCreate User Control.
        /// Sets the BusinessTypeList equal to the GetAllBusinessType from the CompanyClient.
        /// Calls the SetBusinessTypeCombo.
        /// </summary>
        public CompanyCreate()
        {
            BusinessTypeList = CompanyClient.GetAllBusinessType();
            InitializeComponent();
            SetBusinessTypeCombo();
        }

        /// <summary>
        /// Sets all needed textfields equal to the ovjecct Company
        /// </summary>
        private void SetBusinessTypeCombo()
        {
            //Combobox for BusinessType on Company
            foreach (var businessType in BusinessTypeList)
            {
                BusinessTypeInput.Items.Add(businessType.Type);
            }

        }
        /// <summary>
        /// Sets all the Company objects variables equal to their corosponding input values from the User Control
        /// </summary>
        private void GetAllInputs()
        {

            Company.Email = EmailInput.Text;
            Company.CompanyName = CompanyNameInput.Text;
            Company.CVR = Convert.ToInt32(CVRInput.Text);
            Company.Address = AddressInput.Text;
            Company.Phone = Convert.ToInt32(PhoneInput.Text);
            Company.Description = DescriptionInput.Text;
            Company.Homepage = HomepageInput.Text;
            Company.Password = PasswordInput.Text;
            Company.Country = CountryInput.Text;

            //Get the selected BusinessType
            int selectedBusinessTypeIndex = BusinessTypeInput.SelectedIndex;
            Company.businessType = BusinessTypeList[selectedBusinessTypeIndex];
        }


        /// <summary>
        /// Closes CompanyCreate View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        /// <summary>
        /// Gets all input put the view and assigns it to the new Company Object.
        /// The service refrence method for creating a new company is then called where the Company is set as Parameter
        /// Calls TheFunc which contains the UpdateTable() method from the parent view.
        /// Closes the current UserControl view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCompany_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(EmailInput.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                FailCheckLabel.Content = "Skriv en valid email";
            }
            else
            {

                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil tilføje denne virksomhed?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    GetAllInputs();
                    CompanyClient.CreateCompany(Company);
                    Company companyToUpdate = CompanyClient.Login(Company.Email, Company.Password);
                    Company.Id = companyToUpdate.Id;
                    CompanyClient.UpdateCompany(Company);
                    TheFunc();
                    MessageBox.Show("Virksomhed tilføjet");
                    ((Panel)this.Parent).Children.Remove(this);
                }
                else if (result == MessageBoxResult.No)
                {
                    //No code here
                }
            }
        }

    }
}

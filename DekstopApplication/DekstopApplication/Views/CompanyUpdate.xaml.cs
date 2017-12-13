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
using DekstopApplication.CompanyServiceReference;

namespace DekstopApplication.Views
{
    /// <summary>
    /// Interaction logic for CompanyUpdate.xaml
    /// </summary>
    public partial class CompanyUpdate : UserControl
    {
        //Instance variables
        private CompanyServiceReference.Company Company = null;
        private CompanyServiceClient CompanyClient = new CompanyServiceClient();
        private List<BusinessType> BusinessTypeList = new List<BusinessType>();
        public delegate void ParentFunction(); //Delegate function from parent user control

        //delegate function variable
        public ParentFunction TheFunc;

        /// <summary>
        /// Constructor for the CompanyUpdate User Control.
        /// Takes a Company as a needed parameter, wich is then set to the instance varaible.
        /// This ensures that it can be used through the class.
        /// BusinessTypeList set to GetAllBusinessType from the database.
        /// Calls the SetAllText method.
        /// </summary>
        /// <param name="company"></param>
        public CompanyUpdate(CompanyServiceReference.Company company)
        {
            Company = company;
            BusinessTypeList = CompanyClient.GetAllBusinessType();
            InitializeComponent();
            SetAllText();
        }

        /// <summary>
        /// Sets all needed input textfields equal to the Company objects corosponding variables
        /// </summary>
        private void SetAllText()
        {
            EmailInput.Text = Company.Email;
            CompanyNameInput.Text = Company.CompanyName;
            CVRInput.Text = Company.CVR.ToString();
            AddressInput.Text = Company.Address;
            PhoneInput.Text = Company.Phone.ToString();
            DescriptionInput.Text = Company.Description;
            HomepageInput.Text = Company.Homepage;
            PasswordInput.Text = Company.Password;
            CountryInput.Text = Company.Country;

            //Combobox for BusinessType on Company
            foreach (var businessType in BusinessTypeList)
            {
                BusinessTypeInput.Items.Add(businessType.Type);

                if (businessType.Type == Company.businessType.Type)
                {
                    BusinessTypeInput.SelectedIndex = BusinessTypeInput.Items.IndexOf(Company.businessType.Type);
                }
            }

        }

        /// <summary>
        /// Sets all the Company objects variables equal to their corosponding input values 
        /// from the User Control
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
        /// Closes the current User Controll. This will then show the parent User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }

        /// <summary>
        /// Updates the current Company.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCompany_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil opdater denne virksomhed?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                GetAllInputs();
                CompanyClient.UpdateCompany(Company);
                TheFunc();
                MessageBox.Show("Virksomhed opdateret");
                ((Panel)this.Parent).Children.Remove(this);
            }
            else if(result == MessageBoxResult.No)
            {
                //No code here
            }
        }
    }
}

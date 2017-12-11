using DekstopApplication.CompanyServiceReference;
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
    /// Interaction logic for Companies.xaml
    /// </summary>
    public partial class Companies : UserControl
    {
        CompanyServiceClient companyClient = new CompanyServiceClient();
        public List<CompanyServiceReference.Company> companyList = new List<CompanyServiceReference.Company>();

        public Companies()
        {
            InitializeComponent();
            companyList = companyClient.GetAllCompany();
            Companytabel.ItemsSource = companyList;
        }

        /// <summary>
        /// Calls the get all function, and populates the Company Table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllCompanies_Button(object sender, RoutedEventArgs e)
        {
            Companytabel.ClearValue(ListView.ItemsSourceProperty);
            Companytabel.ItemsSource = companyList;
            CompanySearchBox.Text = "";
        }
        /// <summary>
        /// Search Company Function
        /// Sorts the Companylist after the specific input entered in the Company Search Input Field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanySearch_Button(object sender, RoutedEventArgs e)
        {
            List<CompanyServiceReference.Company> companySearchList = new List<CompanyServiceReference.Company>();
            foreach (var company in companyList)
            {
                int id;

                bool result = Int32.TryParse(CompanySearchBox.Text, out id);

                if (company.CompanyName.ToLower().Contains(CompanySearchBox.Text.ToLower()) || company.Email.ToLower().Contains(CompanySearchBox.Text.ToLower()) || company.Phone.ToString().Contains(CompanySearchBox.Text.ToLower()) || company.CVR.ToString().Contains(CompanySearchBox.Text.ToLower()))
                {
                    companySearchList.Add(company);
                }
                else if (result)
                {
                    if (company.Id == id)
                    {
                        companySearchList.Add(company);
                    }
                }
            }
            if (companySearchList.Count != 0)
            {
                Companytabel.ClearValue(ListView.ItemsSourceProperty);
                Companytabel.ItemsSource = companySearchList;
            }
        }
    }
}

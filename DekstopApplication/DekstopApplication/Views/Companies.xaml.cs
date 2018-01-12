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
        //Instance variables
        CompanyServiceClient CompanyClient = new CompanyServiceClient();
        public List<CompanyServiceReference.Company> CompanyList = new List<CompanyServiceReference.Company>();
        public CompanyServiceReference.Company CompanySelected = null; //Used to keet knowlegde of who the current selected company is
        private int LastIndexSeletected;

        /// <summary>
        /// Constructor for the Companies User Control
        /// </summary>
        public Companies()
        {
            InitializeComponent();
            UpdateTable();
        }

        /// <summary>
        /// Updates the table wich contains all current companies that are available from the database.
        /// This is also used as a delegate function for children user controls
        /// </summary>
        public void UpdateTable()
        {
            CompanyList = CompanyClient.GetAllCompany();
            Companytabel.ItemsSource = CompanyList;
        }

        /// <summary>
        /// Get All Companies Button
        /// Calls the get all function, and populates the Company Table.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllCompanies_Button(object sender, RoutedEventArgs e)
        {
            Companytabel.ClearValue(ListView.ItemsSourceProperty);
            Companytabel.ItemsSource = CompanyList;
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
            foreach (var company in CompanyList)
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

        /// <summary>
        /// Creates a new instance of the window CompanyCreate view
        /// Calls the delegate function UpdateTable()
        /// Adds the new CompanyCreate instance to the Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewCompany(object sender, RoutedEventArgs e)
        {
            CompanyCreate companyCreate = new CompanyCreate();
            companyCreate.TheFunc = UpdateTable;
            CompanyStackPanel.Children.Clear();
            CompanyStackPanel.Children.Add(companyCreate);
        }

        /// <summary>
        /// Update Company Button
        /// Creates a new instance of CompanyUpdate view
        /// Calls the delegate function UpdateTable()
        /// Adds the CompanyUpdate view to the Panel
        /// If no company is selected, a messagebox will show.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateCompany(object sender, RoutedEventArgs e)
        {
            if (CompanySelected != null)
            {
                CompanyUpdate companyUpdateView = new CompanyUpdate(CompanySelected);
                companyUpdateView.TheFunc = UpdateTable; //Sets the delegate function in the CompanyUpdateView
                CompanyStackPanel.Children.Clear();
                CompanyStackPanel.Children.Add(companyUpdateView);
            }
            else
            {
                MessageBox.Show("Du har ikke valgt en virksomhed at opdatere");
            }
        }

        /// <summary>
        /// Delete Company Button
        /// Calls DeleteCompany method throguh CompanyClient on the Selected ID on the Company table view
        /// A messagebox will show to comfirm with a Yes/No response required to remove the Company
        /// If removed, a confirmation will be shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCompany(object sender, RoutedEventArgs e)
        {
            if (Companytabel.SelectedIndex >= 0)
            {
                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil slette denne virksomhed?" + CompanySelected.CompanyName, "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    CompanyClient.DeleteCompany(CompanySelected.Id);
                    MessageBox.Show("Virksomheden " + CompanySelected.CompanyName + " er blevet slettet!");
                    UpdateTable();
                }
                else if (result == MessageBoxResult.No)
                {
                    //No code here since the program should not do anyting
                }
            }
            else
            {
                MessageBox.Show("Du har ikke valgt en virksomhed!");
            }
        }

        /// <summary>
        /// Used to store wich company who is currenty selected on the company tabel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Companytabel_SelectedCompany(object sender, SelectionChangedEventArgs e)
        {
            int index;

            if (Companytabel.SelectedIndex >= 0)
            {
                index = Companytabel.SelectedIndex;
                CompanySelected = CompanyList[index];
            }
            else
            {
                index = LastIndexSeletected;
            }

            LastIndexSeletected = index;
        }
    }
}

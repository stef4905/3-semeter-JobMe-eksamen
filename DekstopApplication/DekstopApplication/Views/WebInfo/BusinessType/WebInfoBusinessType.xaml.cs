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

namespace DekstopApplication.Views.WebInfo.BusinessType
{
    /// <summary>
    /// Interaction logic for WebInfoBusinessType.xaml
    /// </summary>
    public partial class WebInfoBusinessType : UserControl
    {

        //Instance variables
        private List<CompanyServiceReference.BusinessType> BusinessTypeList = new List<CompanyServiceReference.BusinessType>();
        private CompanyServiceClient CompanyClient = new CompanyServiceClient();
        private CompanyServiceReference.BusinessType BusinessTypeSelected = null;
        private int IndexSelected;

        public WebInfoBusinessType()
        {
            InitializeComponent();
            UpdateBusinessTypeListAndTable();
        }

        /// <summary>
        /// Updates the table and the list of all businesstypes
        /// </summary>
        public void UpdateBusinessTypeListAndTable()
        {
            BusinessTypeList = CompanyClient.GetAllBusinessType();
            BusinessTypeTable.ItemsSource = BusinessTypeList;
        }

        private void AddNewBusineesType_Click(object sender, RoutedEventArgs e)
        {
            CompanyServiceReference.BusinessType businessType = new CompanyServiceReference.BusinessType();
            businessType.Type = AddBusinessTypeInput.Text;
            CompanyClient.CreateBusinessType(businessType);
            UpdateBusinessTypeListAndTable();
        }

        private void UpdateBusinessType_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil opdatere denne type?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                BusinessTypeSelected.Type = NewBusinessTypeInput.Text;
                CompanyClient.UpdateBusinessType(BusinessTypeSelected);
                NewBusinessTypeInput.Text = "";
                UpdateBusinessTypeListAndTable();
            }
            else if (result == MessageBoxResult.No)
            {
                //No code here
            }
        }

        private void DeleteBusinessType_Click(object sender, RoutedEventArgs e)
        {
            if (BusinessTypeTable.SelectedIndex >= 0)
            {
                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil slette denne type?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    CompanyClient.DeleteBusinessType(BusinessTypeSelected.Id);
                    UpdateBusinessTypeListAndTable();
                }
                else if (result == MessageBoxResult.No)
                {
                    //No code here
                }

                BusinessTypeTable.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Du har ikke valgt en business type");
            }
        }



        private void BusinessTypeTable_SelectedBusineesType(object sender, SelectionChangedEventArgs e)
        {
            int index;
            //Get the current selected businesstype object from the list 
            if (BusinessTypeTable.SelectedIndex >= 0)
            {
                index = BusinessTypeTable.SelectedIndex;
            }
            else
            {
                index = IndexSelected;
            }

            BusinessTypeSelected = BusinessTypeList[index];

            //Setting the text in update section
            CurrentBusinessTypeInput.Text = BusinessTypeSelected.Type;
        }
    }
}

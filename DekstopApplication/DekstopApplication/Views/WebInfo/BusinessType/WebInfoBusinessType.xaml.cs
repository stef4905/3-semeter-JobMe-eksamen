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

        /// <summary>
        /// Constructor for the WebInfoBusinessType User Control.
        /// Calls the UpdateBusinessTypeListAndTable() method.
        /// </summary>
        public WebInfoBusinessType()
        {
            InitializeComponent();
            UpdateBusinessTypeListAndTable();
        }

        /// <summary>
        /// Updates the table and the list of all businesstypes
        /// </summary>
        private void UpdateBusinessTypeListAndTable()
        {
            BusinessTypeList = CompanyClient.GetAllBusinessType();
            BusinessTypeTable.ItemsSource = BusinessTypeList;
        }

        /// <summary>
        /// Instanciating a new BusinessType object, where the Type input is sat to the objects variable.
        /// CompanyClient create method is then called with the given BusinessType object as parameter.
        /// Calls the updateBusinessTypeListAndTable() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewBusineesType_Click(object sender, RoutedEventArgs e)
        {
            CompanyServiceReference.BusinessType businessType = new CompanyServiceReference.BusinessType();
            businessType.Type = AddBusinessTypeInput.Text;
            CompanyClient.CreateBusinessType(businessType);
            UpdateBusinessTypeListAndTable();
        }

        /// <summary>
        /// Displays a messagebox to ensure that the user invoked this method on purpose. 
        /// Set the new type of the BusinessType equal to the objects variable.
        /// CompanyClient update method is then called with the given BusinessType object as parameter.
        /// Calls the updateBusinessTypeListAndTable() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Displays a messagebox to ensure that the user invoked this method on purpose.
        /// CompanyClient delete method is then called with the given current selected BusinessType object Id as parameter.
        /// Calls the updateBusinessTypeListAndTable() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// live opdates the current selected BusinessType that are used through the class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

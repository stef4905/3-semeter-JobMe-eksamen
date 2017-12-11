using DekstopApplication.AdminServiceReference;
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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {

        //Instance variables
        AdminServiceClient AdminClient = new AdminServiceClient();
        AdminCreate AdminCreateView = new AdminCreate();
        public List<AdminServiceReference.Admin> adminList = new List<AdminServiceReference.Admin>();


        /// <summary>
        /// Construct the User Control view for admin
        /// </summary>
        public Admin()
        {
            InitializeComponent();
            UpdateTable();
            AdminCreateView.TheFunc = UpdateTable;
        }

        /// <summary>
        /// Updates the current list of Admins taken from the database
        /// </summary>
        public void UpdateTable()
        {
            adminList = AdminClient.GetAllAdmin();
            AdminTable.ItemsSource = adminList;
        }

        /// <summary>
        /// Clear textfields method is called on the AdminCreateView and add it to the Child
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminCreateView.ClearTextFields();
            GuiPanelAdmin.Children.Clear();
            GuiPanelAdmin.Children.Add(AdminCreateView);
        }

        /// <summary>
        /// Opens the view for updating the selected Admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateAdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminServiceReference.Admin admin = (AdminServiceReference.Admin)AdminTable.SelectedItem;

            if(admin == null)
            {
                FailCheckLabel.Content = "Vælg en admin at updatere";
            }
            else
            {
                AdminUpdate adminUpdateView = new AdminUpdate(admin);
                GuiPanelAdmin.Children.Clear();
                GuiPanelAdmin.Children.Add(adminUpdateView);
            }
        }

        /// <summary>
        /// Deletes the current selected Admin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAdminButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil slette", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                int index = AdminTable.SelectedIndex;
                AdminClient.Delete(adminList[index].Id);
                adminList.Remove(adminList[index]);
                AdminTable.ClearValue(ListView.ItemsSourceProperty);
                AdminTable.ItemsSource = adminList;
            }
            else if (result == MessageBoxResult.No)
            {
                // No code here
            }

        }
    }
}
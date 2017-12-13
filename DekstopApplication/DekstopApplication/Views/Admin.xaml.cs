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
        public AdminServiceReference.Admin admin = new AdminServiceReference.Admin();


        /// <summary>
        /// Constructor for the User Control view for admin
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
        /// Clear textfields method is called on the AdminCreateView and adds it to the Child
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
        /// Calls Delete() Method through AdminClient on the SelectedIndex, and it will store the SelectedIndex as index variable
        /// A confirmation will show which requires Yes/No response, before the AdminClient will execute the Delete() method
        /// If an admin has been removed, it will show by confirmation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAdminButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil slette" + admin.Email, "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                int index = AdminTable.SelectedIndex;
                AdminClient.Delete(adminList[index].Id);
                adminList.Remove(adminList[index]);
                MessageBox.Show("Admin " + admin.Email + " er blevet slettet!");
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
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
        AdminServiceClient adminClient = new AdminServiceClient();
        AdminCreate adminCreateView = new AdminCreate();
        
        
        public List<AdminServiceReference.Admin> adminList = new List<AdminServiceReference.Admin>();
        public Admin()
        {
            adminList = adminClient.GetAllAdmin();
            InitializeComponent();
            AdminTable.ItemsSource = adminList;
        }

        public class AdminItems
        {
            public string Brugernavn { get; set; }
            public string Kodeord { get; set; }
            public string Fornavn { get; set; }
            public string Efternavn { get; set; }
            public string Email { get; set; }
        }

        private void CreateAdminButton_Click(object sender, RoutedEventArgs e)
        {
            GuiPanelAdmin.Children.Clear();
            GuiPanelAdmin.Children.Add(adminCreateView);
        }

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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            //AdminServiceReference.Admin admin = new AdminServiceReference.Admin();
            //List<Admin> adminList1 = adminList.Items.Clear();
            //var adminList = adminClient.GetAdmin(4);
            //AdminList.ItemsSource = adminList1;
        }

        private void DeleteAdminButton_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil slette", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                int index = AdminTable.SelectedIndex;
                adminClient.Delete(adminList[index].Id);
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
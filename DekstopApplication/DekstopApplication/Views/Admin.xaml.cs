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
        AdminUpdate adminUpdateView = new AdminUpdate();
        public Admin()
        {
            InitializeComponent();
        }

        private void CreateApplierButton_Click(object sender, RoutedEventArgs e)
        {
            GuiPanelAdminCreate.Children.Clear();
            GuiPanelAdminCreate.Children.Add(adminCreateView);
        }

        private void UpdateAdminButton_Click(object sender, RoutedEventArgs e)
        {
            GuiPanelAdminCreate.Children.Clear();
            GuiPanelAdminCreate.Children.Add(adminUpdateView);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            AdminServiceReference.Admin admin = new AdminServiceReference.Admin();
            List<Admin> adminList1 = adminList.Items.Clear();
            var adminList = adminClient.GetAdmin(4);
            AdminList.ItemsSource = adminList1;
        }
    }
}

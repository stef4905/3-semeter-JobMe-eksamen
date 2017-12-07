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
using System.Windows.Shapes;
using DekstopApplication.Views;

namespace DekstopApplication
{
    /// <summary>
    /// Interaction logic for CMS.xaml
    /// </summary>
    public partial class CMS : Window
    {
        Companies CompaniesView = new Companies();
        Dashboard DashboardView = new Dashboard();
        Appliers ApplierView = new Appliers();
        Admin AdminView = new Admin();

        public CMS()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            GuiPanel.Children.Add(DashboardView);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            GuiPanel.Children.Add(CompaniesView);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            ApplierView.GuiPanelApplierCreate.Children.Clear();
            GuiPanel.Children.Add(ApplierView);
        }

        /// <summary>
        /// Log out and redirect to the LogIn screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            AdminView.GuiPanelAdminCreate.Children.Clear();
            GuiPanel.Children.Add(AdminView);
        }
    }
}

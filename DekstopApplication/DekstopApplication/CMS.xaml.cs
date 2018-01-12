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
        JobPost JobPostView = new JobPost();
        WebInfoView WebInfoView = new WebInfoView();

        /// <summary>
        /// Cusntroctor for CMS view.
        /// </summary>
        public CMS()
        {
            InitializeComponent();
            GuiPanel.Children.Clear();
            GuiPanel.Children.Add(DashboardView);
        }

        /// <summary>
        /// Enables mouse dragin the view around the dekstop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        /// <summary>
        /// Enables an image to minimize the view to the taskbar on your machine
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Enables an image to close the view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Clears the GuiPanel that is a stackpanel.
        /// Sets the GuiPanel to the Dashboardview using the Add() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            GuiPanel.Children.Add(DashboardView);
        }

        /// <summary>
        /// Clears the GuiPanel that is a stackpanel.
        /// Sets the GuiPanel to the ComapnuesView using the Add() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            GuiPanel.Children.Add(CompaniesView);
        }

        /// <summary>
        /// Clears the GuiPanel that is a stackpanel.
        /// Sets the GuiPanel to the jobPostView using the Add() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            GuiPanel.Children.Add(JobPostView);
        }

        /// <summary>
        /// Clears the GuiPanel that is a stackpanel.
        /// Sets the GuiPanel to the ApplierView using the Add() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            ApplierView.GuiPanelApplier.Children.Clear();
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

        /// <summary>
        /// Clears the GuiPanel that is a stackpanel.
        /// Sets the GuiPanel to the AdminView using the Add() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            AdminView.GuiPanelAdmin.Children.Clear();
            GuiPanel.Children.Add(AdminView);
        }

        /// <summary>
        /// Clears the GuiPanel that is a stackpanel.
        /// Sets the GuiPanel to the WebInfoView using the Add() method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebInfo_Click(object sender, RoutedEventArgs e)
        {
            GuiPanel.Children.Clear();
            GuiPanel.Children.Add(WebInfoView);
        }
    }
}

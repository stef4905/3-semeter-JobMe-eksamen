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
using DekstopApplication.Views.WebInfo;
using DekstopApplication.Views.WebInfo.BusinessType;

namespace DekstopApplication.Views
{
    /// <summary>
    /// Interaction logic for WebInfoView.xaml
    /// </summary>
    public partial class WebInfoView : UserControl
    {

        //Instance variables
        private LoadingView LoadingView = new LoadingView();


        public WebInfoView()
        {
            InitializeComponent();
        }

        private void JobCategoryButton(object sender, RoutedEventArgs e)
        {
            WebInfoJobCategory webinfoJobCategoryView = new WebInfoJobCategory();
            WebInfoPanel.Children.Clear();
            WebInfoPanel.Children.Add(webinfoJobCategoryView);
        }

        private void WebInfoTextButton(object sender, RoutedEventArgs e)
        {
            WebInfoBusinessType webInfoBusinessType = new WebInfoBusinessType();
            WebInfoPanel.Children.Clear();
            WebInfoPanel.Children.Add(webInfoBusinessType);

        }

        public void DisplayLoadingView()
        {
            WebInfoPanel.Children.Clear();
            WebInfoPanel.Children.Add(LoadingView);
        }
    }
}

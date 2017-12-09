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

namespace DekstopApplication.Views.WebInfo.JobInfoJobCategory
{
    /// <summary>
    /// Interaction logic for UpdateJobCategoryView.xaml
    /// </summary>
    public partial class UpdateJobCategoryView : UserControl
    {
        public UpdateJobCategoryView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the current selected job category in the database and then the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJobCategory(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
using DekstopApplication.JobPostServiceReference;
using DekstopApplication.Views.WebInfo.JobInfoJobCategory;

namespace DekstopApplication.Views.WebInfo
{
    /// <summary>
    /// Interaction logic for WebInfoJobCategory.xaml
    /// </summary>
    public partial class WebInfoJobCategory : UserControl
    {

        //Instance variables
        private List<JobCategory> JobCategoryList = new List<JobCategory>();
        private JobPostServiceClient JobPostClient = new JobPostServiceClient();

        //Instanciating views
        private AddJobCategoryView AddJobCategoryView = new AddJobCategoryView();
        private UpdateJobCategoryView UpdateJobCategoryView = new UpdateJobCategoryView();

        public WebInfoJobCategory()
        {
            JobCategoryList = JobPostClient.GetAllJobCategories();
            InitializeComponent();
            DisplayAllJobCategories();
        }


        /// <summary>
        /// Displayes all currenct available job categories from the database. 
        /// Theise can be used with CRUD functionality
        /// </summary>
        public void DisplayAllJobCategories()
        {
            JobCategoryTable.ItemsSource = JobCategoryList;
        }


        /// <summary>
        /// Displayss the menu for adding a new job category by calling the corosponding user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewJobCategoryView(object sender, RoutedEventArgs e)
        {
            JobCategoryAddAndUpdatePanel.Children.Clear();
            JobCategoryAddAndUpdatePanel.Children.Add(AddJobCategoryView);

        }

        /// <summary>
        /// Displays the menu for the currently selected job category by calling the corosponding user control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJobCategory(object sender, RoutedEventArgs e)
        {
            JobCategoryAddAndUpdatePanel.Children.Clear();
            JobCategoryAddAndUpdatePanel.Children.Add(UpdateJobCategoryView);

        }

        /// <summary>
        /// Deletes the selected job category from the database and the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteJobCategory(object sender, RoutedEventArgs e)
        {

        }
    }
}

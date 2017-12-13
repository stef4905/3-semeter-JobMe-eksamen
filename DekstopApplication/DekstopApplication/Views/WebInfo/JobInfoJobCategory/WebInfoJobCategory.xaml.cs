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
        private JobCategory JobCategorySelected = null; // Used to keep knowing wich job category that is currently selected
        private int IndexSelected;

        /// <summary>
        /// Constructor for the WebInfoJobCategory User Control.
        /// Calls the UpdateJobCategoryListAndTable() method.
        /// </summary>
        public WebInfoJobCategory()
        {
            InitializeComponent();
            UpdateJobCategoryListAndTable();
        }

        /// <summary>
        /// Updates the table and the list of all job categories
        /// </summary>
        public void UpdateJobCategoryListAndTable()
        {
            JobCategoryList = JobPostClient.GetAllJobCategories();
            JobCategoryTable.ItemsSource = JobCategoryList;
        }

        /// /// <summary>
        /// Displays a messagebox to ensure that the user invoked this method on purpose.
        /// JobPostClient delete method is then called with the given current selected JobCategory object Id as parameter.
        /// Calls the UpdateJobCategoryListAndTable() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteJobCategory(object sender, RoutedEventArgs e)
        {
            if (JobCategoryTable.SelectedIndex >= 0)
            {
                MessageBoxResult result = MessageBox.Show("Er du sikker på at du vil slette " + JobCategorySelected.Title, "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    JobPostClient.DeleteJobCategory(JobCategorySelected.Id);
                    UpdateJobCategoryListAndTable();
                }
                else if (result == MessageBoxResult.No)
                {
                    //No code here
                }
                JobCategoryTable.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Du har ikke valgt en job kategori");
            }

        }

        /// <summary>
        /// Instanciating a new JobCategory object, where the Type input is sat to the objects variable.
        /// JobPostClient create method is then called with the given JobCategory object as parameter.
        /// Calls the UpdateJobCategoryListAndTable() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewJobCategory(object sender, RoutedEventArgs e)
        {
            JobCategory jobCategory = new JobCategory();
            jobCategory.Title = AddJobCategoryInput.Text;
            JobPostClient.CreateJobCategory(jobCategory);
            UpdateJobCategoryListAndTable();
        }

        /// <summary>
        /// Displays a messagebox to ensure that the user invoked this method on purpose. 
        /// Set the new type of the JobCategory equal to the objects variable.
        /// JobPostClient update method is then called with the given JobCategory object as parameter.
        /// Calls the UpdateJobCategoryListAndTable() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJobCategory(object sender, RoutedEventArgs e)
        {
            JobCategorySelected.Title = NewJobCategoryTitleInput.Text;
            JobPostClient.UpdateJobCategory(JobCategorySelected);
            NewJobCategoryTitleInput.Text = "";
            UpdateJobCategoryListAndTable();

        }

        /// <summary>
        /// live opdates the current selected JobCategory that are used through the class.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JobCategoryTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index;
            //Get the current selected JobCategory object from the list 
            if (JobCategoryTable.SelectedIndex >= 0)
            {
                index = JobCategoryTable.SelectedIndex;
            }
            else
            {
                index = IndexSelected;
            }
            JobCategorySelected = JobCategoryList[index];
            //Setting the text in update section
            CurrentJobCategoryTitleInput.Text = JobCategorySelected.Title;
        }

    }
}

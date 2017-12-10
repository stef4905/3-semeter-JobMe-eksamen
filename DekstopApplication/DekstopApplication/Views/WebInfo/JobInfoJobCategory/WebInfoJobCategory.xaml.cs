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


        /// <summary>
        /// Deletes the selected job category from the database and the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteJobCategory(object sender, RoutedEventArgs e)
        {
            JobPostClient.DeleteJobCategory(JobCategorySelected.Id);
            UpdateJobCategoryListAndTable();
        }

        /// <summary>
        /// Creates a new job category in the database. 
        /// </summary>
        /// <param name="sernder"></param>
        /// <param name="e"></param>
        private void AddNewJobCategory(object sernder, RoutedEventArgs e)
        {
            JobCategory jobCategory = new JobCategory();
            jobCategory.Title = AddJobCategoryInput.Text;

            JobPostClient.CreateJobCategory(jobCategory);

            UpdateJobCategoryListAndTable();
        }

        /// <summary>
        /// Updaring the current selected job category by the new title set in the inputfield
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
        /// Automaticly sets the textfield text when highlighted
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

            //Sets the indexSelected to the current selected index on the table list. This then used for the next time this mehtod is called
            IndexSelected = index;
        }


    }
}

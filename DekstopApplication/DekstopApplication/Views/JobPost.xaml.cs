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

namespace DekstopApplication.Views
{
    /// <summary>
    /// Interaction logic for JobPost.xaml
    /// </summary>
    public partial class JobPost : UserControl
    {
        JobPostServiceClient jobPostClient = new JobPostServiceClient();
        public List<JobPostServiceReference.JobPost> JobPostList = new List<JobPostServiceReference.JobPost>();
        private int LastIndexSelected; // Stores the last selected index of Job Post Table.
        private JobPostServiceReference.JobPost JobPostSelected = null; // Used to keep knowing which Jobpost is selected.

        /// <summary>
        /// Constructor for the JobPost User Control.
        /// Calls the UpdateTableAndList method.
        /// </summary>
        public JobPost()
        {
            InitializeComponent();
            UpdateTableAndList();
        }

        /// <summary>
        /// Updates the JobPostList using the JobPostClient where a list
        /// of all current JobPost from the database´.
        /// Sets the JobPostTabel equal to the JopPostList, this
        /// displays all the jobPosts on the list.
        /// </summary>
        public void UpdateTableAndList()
        {
            JobPostList = jobPostClient.GetAllJobPost();
            JobPostTabel.ItemsSource = JobPostList;
        }

        /// <summary>
        /// Search Job Post Function.
        /// Calls get all Function in initialize component, 
        /// and then sorts it after the specific input entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchJobPostButton(object sender, RoutedEventArgs e)
        {
            List<JobPostServiceReference.JobPost> jobPostSearchList = new List<JobPostServiceReference.JobPost>();
            foreach (var jobPost in JobPostList)
            {
                int id;
                bool result = Int32.TryParse(JobPostSearchBox.Text, out id);

                if (jobPost.JobTitle.ToLower().Contains(JobPostSearchBox.Text.ToLower()) || jobPost.CompanyName.ToLower().Contains(JobPostSearchBox.Text.ToLower()))
                {
                    jobPostSearchList.Add(jobPost);
                }
                else if (result)
                {
                    if (jobPost.Id == id)
                    {
                        jobPostSearchList.Add(jobPost);
                    }
                }
            }
            if (jobPostSearchList.Count != 0)
            {
                JobPostTabel.ClearValue(ListView.ItemsSourceProperty);
                JobPostTabel.ItemsSource = jobPostSearchList;
            }
        }
        /// <summary>
        /// Delete Job Post method, it will call the delete job post method on click on the delete button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteJobPost(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil slette dette Job Opslag?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                var index = JobPostTabel.SelectedIndex;
                jobPostClient.DeleteJobPost(JobPostList[index].Id);
                JobPostList.Remove(JobPostList[index]);
                JobPostTabel.ClearValue(ListView.ItemsSourceProperty);
                JobPostTabel.ItemsSource = JobPostList;
                MessageBox.Show("Job Post Slettet!");
            }
            else if (result == MessageBoxResult.No)
            {
                //No code yet
            }
            

        }

        /// <summary>
        /// Show all job post button, it will clear the table and populate the table again with the refreshed list.
        /// It also clears the text in the search box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAllJobPost(object sender, RoutedEventArgs e)
        {
            JobPostTabel.ClearValue(ListView.ItemsSourceProperty);
            JobPostTabel.ItemsSource = JobPostList;
            JobPostSearchBox.Text = "";
        }

        /// <summary>
        /// Update Job Post button, it will take the selected JobPost and open it in a new window.
        /// it also stores the selected index in a temporary variable so it remembers the last index.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowJobPostOnNewView(object sender, RoutedEventArgs e)
        {
            int index;
            //Get the current selected JobPost object from the list.
            if (JobPostTabel.SelectedIndex >= 0)
            {
                index = JobPostTabel.SelectedIndex;
                JobPostSelected = JobPostList[index];
                ShowJobPostOnView.Children.Clear();
                ReadEditJobPost readEditJobPost = new ReadEditJobPost(JobPostSelected);
                ShowJobPostOnView.Children.Add(readEditJobPost);
            }
            else
            {
                index = LastIndexSelected;
                MessageBox.Show("Du har ikke valgt en Job Post!");
            }
            //Sets the indexSelected to the current selected index on the tabel list. This is then used for the next time this method is called.
            LastIndexSelected = index;
        }
    }
}

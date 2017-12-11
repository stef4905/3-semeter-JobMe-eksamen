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
    /// Interaction logic for ReadEditJobPost.xaml
    /// </summary>
    public partial class ReadEditJobPost : UserControl
    {
        JobPostServiceClient jobCLient = new JobPostServiceClient();
        List<JobPostServiceReference.JobCategory> categoryList = new List<JobPostServiceReference.JobCategory>();
        public JobPostServiceReference.JobPost jobPost = null;

        public ReadEditJobPost(JobPostServiceReference.JobPost jobPost)
        {
            this.jobPost = jobPost;
            categoryList = jobCLient.GetAllJobCategories();
            InitializeComponent();
            SetAllBoxWithText();
            this.DataContext = this;
        }

        /// <summary>
        /// Sets all the needed information on the user controll by the JobPost object from the main
        /// </summary>
        public void SetAllBoxWithText()
        {
            //Sets all the content boxes with their desired information
            CompanyNameBox.Text = jobPost.CompanyName;
            JobPostTitleTextBox.Text = jobPost.Title;
            JobPostJobTitleTextBox.Text = jobPost.JobTitle;
            JobPostAdressTextbox.Text = jobPost.Address;
            JobPostDescriptionTextBox.Text = jobPost.Description;
            StartDateBox.SelectedDate = jobPost.StartDate;
            EndDateBox.SelectedDate = jobPost.EndDate;

            //Checks to see if the company has a image or else it sets the defoult image (JOBME IMAGE)
            Uri imageUri = null;
            if (jobPost.company.ImageURL != null)
            {
                imageUri = new Uri(jobPost.company.ImageURL, UriKind.Absolute);
            }
            else
            {
                imageUri = new Uri("https://i.imgur.com/Csasjwt.png", UriKind.Absolute);
            }
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            jobPostImage.Source = imageBitmap;

            //Generates a combobox with all the current job categories in the database. 
            //Also sets the selected category corosponding to the jobPost object
            foreach (var category in categoryList)
            {
                CategoryListBox.Items.Add(category.Title);

                if (category.Title == jobPost.jobCategory.Title)
                {
                    CategoryListBox.SelectedIndex = CategoryListBox.Items.IndexOf(jobPost.jobCategory.Title);
                }

            }

        }
        /// <summary>
        /// Method for Updating JobPost fields for a specific JobPost
        /// </summary>
        public void UpdateJobPostBoxes()
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil opdatere dette Job Opslag?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                jobPost.CompanyName = CompanyNameBox.Text;
                jobPost.Title = JobPostTitleTextBox.Text;
                jobPost.JobTitle = JobPostJobTitleTextBox.Text;
                jobPost.Address = JobPostAdressTextbox.Text;
                jobPost.Description = JobPostDescriptionTextBox.Text;
                jobPost.StartDate = StartDateBox.SelectedDate.Value.Date;
                jobPost.EndDate = EndDateBox.SelectedDate.Value.Date;
                jobCLient.UpdateJobPost(jobPost);
            }
            else if (result == MessageBoxResult.No)
            {
                //No Code here
            }
        }

        /// <summary>
        /// On Update button click, it invokes the Update JobPostBoxes method.
        /// Which wil update the fields.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJobPostButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateJobPostBoxes();
            MessageBox.Show("Job Post Opdateret!");
        }
        /// <summary>
        /// Back Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }
    }
}

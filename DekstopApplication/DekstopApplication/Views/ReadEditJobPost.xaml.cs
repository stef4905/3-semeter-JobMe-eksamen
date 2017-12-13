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

        //Instance variables
        private JobPostServiceClient JobClient = new JobPostServiceClient();
        private List<JobPostServiceReference.JobCategory> CategoryList = new List<JobPostServiceReference.JobCategory>();
        public JobPostServiceReference.JobPost JobPost = null;

        /// <summary>
        /// Cunstructor for the ReadEditJobPost User Control.
        /// Takes a JobPost object as parameter, this is then used through the class.
        /// Sets the CategoryList equal to all JobCategories from the database.
        /// Calls the SetAllBoxWithText method.
        /// </summary>
        /// <param name="jobPost"></param>
        public ReadEditJobPost(JobPostServiceReference.JobPost jobPost)
        {
            this.JobPost = jobPost;
            CategoryList = JobClient.GetAllJobCategories();
            InitializeComponent();
            SetAllBoxWithText();
            this.DataContext = this;
        }

        /// <summary>
        /// Sets all the needed information on the user controll by
        /// the JobPost objects corosponding variables.
        /// </summary>
        public void SetAllBoxWithText()
        {
            //Sets all the content boxes with their desired information
            CompanyNameBox.Text = JobPost.CompanyName;
            JobPostTitleTextBox.Text = JobPost.Title;
            JobPostJobTitleTextBox.Text = JobPost.JobTitle;
            JobPostAdressTextbox.Text = JobPost.Address;
            JobPostDescriptionTextBox.Text = JobPost.Description;
            StartDateBox.SelectedDate = JobPost.StartDate;
            EndDateBox.SelectedDate = JobPost.EndDate;

            //Checks to see if the company has a image or else it sets the defoult image (JOBME IMAGE)
            Uri imageUri = null;
            if (JobPost.company.ImageURL != null)
            {
                imageUri = new Uri(JobPost.company.ImageURL, UriKind.Absolute);
            }
            else
            {
                imageUri = new Uri("https://i.imgur.com/Csasjwt.png", UriKind.Absolute);
            }
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            jobPostImage.Source = imageBitmap;

            //Generates a combobox with all the current job categories in the database. 
            //Also sets the selected category corosponding to the jobPost object
            foreach (var category in CategoryList)
            {
                CategoryListBox.Items.Add(category.Title);

                if (category.Title == JobPost.jobCategory.Title)
                {
                    CategoryListBox.SelectedIndex = CategoryListBox.Items.IndexOf(JobPost.jobCategory.Title);
                }

            }

        }

        /// <summary>
        /// Updates the JobPost objects variables corosponding with the inputfields values.
        /// Shows a messagebox to ensure user invoked this update in pourpis. 
        /// Shows a success message and closes the User Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateJobPostButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Er du sikker på du vil opdatere dette Job Opslag?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                JobPost.CompanyName = CompanyNameBox.Text;
                JobPost.Title = JobPostTitleTextBox.Text;
                JobPost.JobTitle = JobPostJobTitleTextBox.Text;
                JobPost.Address = JobPostAdressTextbox.Text;
                JobPost.Description = JobPostDescriptionTextBox.Text;
                JobPost.StartDate = StartDateBox.SelectedDate.Value.Date;
                JobPost.EndDate = EndDateBox.SelectedDate.Value.Date;
                JobClient.UpdateJobPost(JobPost);

                string selected = CategoryListBox.SelectedValue.ToString();

                foreach (var Category in CategoryList)
                {
                    if (selected == Category.Title)
                    {
                        JobPost.jobCategory = Category;
                    }
                }

                MessageBox.Show("Job Post Opdateret!");
                ((Panel)this.Parent).Children.Remove(this);
            }
            else if (result == MessageBoxResult.No)
            {
                //No Code here
            }
        }

        /// <summary>
        /// Closes the current User Control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ((Panel)this.Parent).Children.Remove(this);
        }
    }
}

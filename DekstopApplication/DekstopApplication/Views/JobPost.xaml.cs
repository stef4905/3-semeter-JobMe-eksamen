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
        public List<JobPostServiceReference.JobPost> jobPostList = new List<JobPostServiceReference.JobPost>();
        public JobPost()
        {
            InitializeComponent();
            jobPostList = jobPostClient.GetAllJobPost();
            JobPostTabel.ItemsSource = jobPostList;
        }

        private void SearchJobPostButton(object sender, RoutedEventArgs e)
        {
            List<JobPostServiceReference.JobPost> jobPostSearchList = new List<JobPostServiceReference.JobPost>();
            foreach (var jobPost in jobPostList)
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

        public class JobPostItems
        {
            public string FirmaNavn { get; set; }
            public string JobTitel { get; set; }
            public string OprettelsesDato { get; set; }
            public string AfslutningsDato { get; set; }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var index = JobPostTabel.SelectedIndex;
            jobPostClient.DeleteJobPost(jobPostList[index].Id);
            jobPostList.Remove(jobPostList[index]);
            JobPostTabel.ClearValue(ListView.ItemsSourceProperty);
            JobPostTabel.ItemsSource = jobPostList;

        }

        private void ShowAllJobPost(object sender, RoutedEventArgs e)
        {
            JobPostTabel.ClearValue(ListView.ItemsSourceProperty);
            JobPostTabel.ItemsSource = jobPostList;
            JobPostSearchBox.Text = "";
        }

    }
}

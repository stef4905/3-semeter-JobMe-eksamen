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
            JobPostTabel.ItemsSource = jobPostClient.GetAllJobPost();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

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
            jobPostClient.DeleteJobPost(index);
        }
    }
}

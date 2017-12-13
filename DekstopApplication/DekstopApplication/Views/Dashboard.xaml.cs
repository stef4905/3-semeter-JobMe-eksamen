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
using DekstopApplication.ApplierServiceReference;
using DekstopApplication.JobPostServiceReference;
using DekstopApplication.CompanyServiceReference;

namespace DekstopApplication.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {

        //Instance variables
        private JobPostServiceClient JobPostClient = new JobPostServiceClient();
        private ApplierServiceClient ApplierClient = new ApplierServiceClient();
        private CompanyServiceClient CompanyClient = new CompanyServiceClient();

        /// <summary>
        /// Constructor for the Dashboard User Control
        /// Calls SetAllCounts method. 
        /// </summary>
        public Dashboard()
        {
            InitializeComponent();
            SetAllCounts();
        }

        /// <summary>
        /// Sets all labels in user control view to their needed values
        /// </summary>
        private void SetAllCounts()
        {
            ApplierCountLabel.Content = ApplierClient.GetApplierTableSize().ToString();
            JobPostLabel.Content = JobPostClient.GetJobPostTableSize().ToString();
            CompanyCountLabel.Content = CompanyClient.GetCompanyTableSize().ToString();
        }
    }
}

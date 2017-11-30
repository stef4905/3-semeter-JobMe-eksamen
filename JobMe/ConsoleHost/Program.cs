using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFJobMeService;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)

        // Ændre fra Using til at lukke forbindelsen selv.
        {
            ServiceHost Companyhost = new ServiceHost(typeof(CompanyService));
            ServiceHost Applierhost = new ServiceHost(typeof(ApplierService));
            ServiceHost JobPosthost = new ServiceHost(typeof(JobPostService));
            ServiceHost JobCVhost = new ServiceHost(typeof(JobCVService));
            ServiceHost JobApplicationhost = new ServiceHost(typeof(JobApplicationService));


            foreach (var hostedEndpoint in Companyhost.BaseAddresses)
            {
                Console.WriteLine(hostedEndpoint.AbsoluteUri);
                Console.WriteLine(hostedEndpoint.LocalPath);
            }
            Companyhost.Open();
            printInfo(Companyhost);

            foreach (var hostedEndpoint in Applierhost.BaseAddresses)
            {
                Console.WriteLine(hostedEndpoint.AbsoluteUri);
                Console.WriteLine(hostedEndpoint.LocalPath);
            }
            Applierhost.Open();
            printInfo(Applierhost);

            foreach (var hostedEndpoint in JobPosthost.BaseAddresses)
            {
                Console.WriteLine(hostedEndpoint.AbsoluteUri);
                Console.WriteLine(hostedEndpoint.LocalPath);
            }
            JobPosthost.Open();
            printInfo(JobPosthost);

            foreach (var hostedEndpoint in JobCVhost.BaseAddresses)
            {
                Console.WriteLine(hostedEndpoint.AbsoluteUri);
                Console.WriteLine(hostedEndpoint.LocalPath);
            }
            JobCVhost.Open();
            printInfo(JobCVhost);

            foreach (var hostedEndpoint in JobApplicationhost.BaseAddresses)
            {
                Console.WriteLine(hostedEndpoint.AbsoluteUri);
                Console.WriteLine(hostedEndpoint.LocalPath);
            }
            JobApplicationhost.Open();
            printInfo(JobApplicationhost);
            Console.ReadLine();
        }

        static public void printInfo(ServiceHost host)
        {
            Console.WriteLine(host.State);
            //Do readline here--> if you exit the using block, the connection is closed
            Console.WriteLine("Listening");

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer;
using BusinessLogicLayer;

namespace test
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ApplierCtr applierCtr = new ApplierCtr();

            Applier applier = applierCtr.Get(2);
            Console.WriteLine(applier.JobCV.Id);
            Console.ReadLine();
        }
    }
}

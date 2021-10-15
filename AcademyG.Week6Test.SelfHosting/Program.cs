using AcademyG.Week6Test.WCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week6Test.SelfHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ManagementService)))
            {
                host.Open();

                Console.WriteLine("=== Employee WCF Running ===");
                Console.WriteLine("Press any key to end ...");
                Console.ReadKey();
            }

        }
    }
}

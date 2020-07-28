using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace IRQ_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (ManagementObject Memory in new ManagementObjectSearcher(
                "select * from Win32_IRQResource").Get())
            {
                Console.WriteLine("Name:: " + Memory["Name"]);
                Console.WriteLine("Status:: " + Memory["Status"]);
                Console.WriteLine("IRQNumber:: " + Memory["IRQNumber"]);
                Console.WriteLine("Device Name:: " + Memory["CSName"]);
                Console.WriteLine("-----------------------------------");

            }

            Console.WriteLine("Press Any Key to Exit");
            Console.ReadKey();
        }
    }
}

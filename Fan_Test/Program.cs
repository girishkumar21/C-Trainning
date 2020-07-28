using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Fan_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (ManagementObject Fan in new ManagementObjectSearcher(
                "select SystemName from Win32_Fan").Get())
            {

                Console.WriteLine("Device Name:: " + Fan["SystemName"]);
            }

            Console.WriteLine("Press any to exit");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
                foreach (ManagementObject Memory in new ManagementObjectSearcher(
                "select * from Win32_DeviceMemoryAddress").Get())
                {
                    Console.WriteLine("Address:: " + Memory["Name"] + "Starting Address is " + Memory["StartingAddress"]);
                    try
                    {
                        ManagementObjectSearcher PnPDevices = new ManagementObjectSearcher(
                        "ASSOCIATORS OF {Win32_DeviceMemoryAddress.StartingAddress='" + Memory["StartingAddress"] + "'} WHERE RESULTCLASS  = Win32_PnPEntity");

                        ManagementObjectCollection PnPCollection = PnPDevices.Get();
                        foreach (ManagementObject Pnp in PnPCollection)
                        {

                            Console.WriteLine("PnP Device :: " + Pnp["Caption"]);
                            foreach (ManagementObject IRQ in new ManagementObjectSearcher(
                                "ASSOCIATORS OF {Win32_PnPEntity.PNPDeviceID = '" + Pnp["PNPDeviceID"] + "'} WHERE RESULTCLASS = Win32_IRQResource").Get())
                            {
                                Console.WriteLine("IRQ:: " + IRQ["Name"]);
                            }
                        }
                    }
                    catch (ManagementException e)
                    {
                        Console.WriteLine(e.ErrorCode);
                        continue;
                    }
                    catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            
        }

    }
}

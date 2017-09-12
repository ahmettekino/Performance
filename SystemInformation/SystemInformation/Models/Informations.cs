using System;

using Microsoft.Win32;
using SystemInformation.Models;
using System.Management;
using System.Net.NetworkInformation;

namespace SystemInformation.Models
{
    public class Informations
    {


        public uint CurrentClockSpeed { get; set; }
        public double TotalVisibleUsageMemorySize { get; set; }
        public long SpeedNetwork { get; set; }
       
        public Informations getOperatingSystemInfo()
        {


            foreach (ManagementObject item in new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get())
            {
                this.TotalVisibleUsageMemorySize = Math.Round((Convert.ToDouble(item["TotalVisibleMemorySize"]) / (1024 * 1024)), 2) - Math.Round((Convert.ToDouble((ulong)item["FreePhysicalMemory"]) / (1024 * 1024)), 2);
            }

            foreach (ManagementObject item in new ManagementObjectSearcher("select * from Win32_Processor").Get())
            {
                this.CurrentClockSpeed = (uint)item["CurrentClockSpeed"];
            }

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.Name == "Wi-Fi")
                {
                    this.SpeedNetwork = adapter.Speed;
                }
            }

            return this;
        }
    }
}

// Importing necessary libraries for networking
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ThreadingStaticDataExample
{
    // This class represents the state of a workstation.
    internal class WorkstationState
    {
        // Properties representing the name and IP address of the workstation.
        internal static string Name { get; set; }
        internal static string IpAddress { get; set; }
        // Property representing whether the network is available.
        internal static bool IsNetworkAvailable { get; set; }

        // ThreadStatic attribute ensures that each thread has its own instance of this variable.
        // Property representing the last time network connectivity was updated.
        [ThreadStatic]
        internal static DateTime? NetworkConnectivityLastUpdated;

        // Static constructor that initializes the properties.
        static WorkstationState()
        {
            // Get the name of the workstation.
            Name = Dns.GetHostName();

            // Get the IP address of the workstation.
            IpAddress = GetLocalIPAddress(Name);

            // Check if the network is available.
            IsNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();

            // Set the last updated time to the current UTC time.
            NetworkConnectivityLastUpdated = DateTime.UtcNow;

            // Pause the thread for 2 seconds.
            Thread.Sleep(2000);
        }

        // Helper function to get the local IP address of the workstation.
        private static string GetLocalIPAddress(string hostName)
        {
            // Get the host entry for the given host name.
            var hostEntry = Dns.GetHostEntry(hostName);

            // Loop through the addresses to find the IPv4 address.
            foreach (var address in hostEntry.AddressList
                                    .Where(a => a.AddressFamily == AddressFamily.InterNetwork))
            {
                // Return the first IPv4 address found.
                return address.ToString();
            }

            // If no IPv4 address is found, return an empty string.
            return string.Empty;
        }
    }
}
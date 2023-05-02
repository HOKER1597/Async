// Importing necessary libraries for networking
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ThreadingStaticDataExample
{
    // This class represents the singleton instance of the state of a workstation.
    public class WorkstationStateSingleton
    {
        // Singleton instance variable and lock object to ensure thread safety.
        private static WorkstationStateSingleton? _singleton = null;
        private static readonly object _lock = new();
        // Private constructor to prevent direct instantiation of the class.
        private WorkstationStateSingleton()
        {
            // Get the name of the workstation.
            Name = Dns.GetHostName();

            // Get the IP address of the workstation.
            IpAddress = GetLocalIPAddress(Name);

            // Check if the network is available.
            IsNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();

            // Set the last updated time to the current UTC time.
            NetworkConnectivityLastUpdated = DateTime.UtcNow;
        }

        // Public property that returns the singleton instance of the class.
        public static WorkstationStateSingleton Instance
        {
            get
            {
                // Ensure thread safety using the lock object.
                lock (_lock)
                {
                    // If the singleton instance does not exist, create it.
                    if (_singleton == null)
                    {
                        _singleton = new WorkstationStateSingleton();
                    }
                    // Return the singleton instance.
                    return _singleton;
                }
            }
        }

        // Properties representing the name and IP address of the workstation.
        public string Name { get; set; }
        public string IpAddress { get; set; }

        // Property representing whether the network is available.
        public bool IsNetworkAvailable { get; set; }

        // Property representing the last time network connectivity was updated.
        public DateTime? NetworkConnectivityLastUpdated { get; set; }

        // Helper function to get the local IP address of the workstation.
        private string GetLocalIPAddress(string hostName)
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
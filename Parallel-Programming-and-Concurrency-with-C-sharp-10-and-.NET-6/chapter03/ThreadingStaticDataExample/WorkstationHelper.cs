// Import the System.Net.NetworkInformation namespace.

using System.Net.NetworkInformation;
namespace ThreadingStaticDataExample
{
    internal class WorkstationHelper
    {
        // Create a private static object to use for locking.

        private static object _workstationLock = new object();
        internal async Task<bool> GetNetworkAvailability()
        {
            // Wait for 100 milliseconds (async/await pattern).
            await Task.Delay(100);
            // Use the lock statement to synchronize access to the WorkstationState object.
            lock (_workstationLock)
            {
                // Update the IsNetworkAvailable property of the WorkstationState object.
                WorkstationState.IsNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
                // Update the NetworkConnectivityLastUpdated property of the WorkstationState object.
                WorkstationState.NetworkConnectivityLastUpdated = DateTime.UtcNow;
            }
            // Return the updated value of the IsNetworkAvailable property.
            return WorkstationState.IsNetworkAvailable; 
        }

        internal async Task<bool> GetNetworkAvailabilityFromSingleton()
        {
            // Wait for 100 milliseconds (async/await pattern).
            await Task.Delay(100); 
            // Get a reference to the WorkstationState singleton object.
            var state = WorkstationStateSingleton.Instance; 
            // Use the lock statement to synchronize access to the singleton object.
            lock (_workstationLock) 
            {
                // Update the IsNetworkAvailable property of the singleton object.
                state.IsNetworkAvailable = NetworkInterface.GetIsNetworkAvailable(); 
                // Update the NetworkConnectivityLastUpdated property of the singleton object.
                state.NetworkConnectivityLastUpdated = DateTime.UtcNow; 
            }
            // Return the updated value of the IsNetworkAvailable property of the singleton object.
            return state.IsNetworkAvailable; 
        }
    }
}

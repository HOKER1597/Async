// This is a namespace for an example of an async console application
namespace AsyncConsoleExample
{
    // This is a class that helps with network related tasks
    internal class NetworkHelper
    {
        // This method checks the network status asynchronously
        internal async Task CheckNetworkStatusAsync()
        {
            // Call the NetworkCheckInternalAsync method and store the returned task in a variable
            Task t = NetworkCheckInternalAsync();
            // Loop through 8 times and output a message every half a second
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine("Top level method working...");
                await Task.Delay(500);
            }

            // Wait for the task returned by NetworkCheckInternalAsync to complete
            await t;
        }

        // This is an internal method that checks the network status asynchronously
        private async Task NetworkCheckInternalAsync()
        {
            // Loop through 10 times and check if the network is available
            for (int i = 0; i < 10; i++)
            {
                bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                // Output a message with the result of the network check
                Console.WriteLine($"Is network available? Answer: {isNetworkUp}");
                // Wait for 100 milliseconds
                await Task.Delay(100);
            }
        }
    }
}

// Import the ThreadingStaticDataExample namespace.
using ThreadingStaticDataExample;
// Print "Hello, World!" to the console.
Console.WriteLine("Hello, World!");
// Print the current UTC datetime to the console.
Console.WriteLine($"Current datetime: {DateTime.UtcNow}");
// Create a new instance of the WorkstationHelper class.
var helper = new WorkstationHelper();

// await helper.GetNetworkAvailability(); 

//Parallel.For(1, 30, async (x) =>
//{
//    await helper.GetNetworkAvailability();
//});
// Call the GetNetworkAvailabilityFromSingleton method asynchronously.
await helper.GetNetworkAvailabilityFromSingleton();

Console.WriteLine($"Network availability last updated {WorkstationState.NetworkConnectivityLastUpdated} for computer {WorkstationState.Name} at IP {WorkstationState.IpAddress}"); // Print the network availability status to the console.


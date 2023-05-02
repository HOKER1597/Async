// Import the namespace that contains the NetworkHelper class
using AsyncConsoleExample;

// Output a message to the console
Console.WriteLine("Hello, async!");

// Create a new instance of the NetworkHelper class
var networkHelper = new NetworkHelper();

// Call the CheckNetworkStatusAsync method asynchronously and wait for it to complete
await networkHelper.CheckNetworkStatusAsync();

// Output a message to the console indicating that the main method has completed
Console.WriteLine("Main method complete.");

// Wait for a key press before exiting the console application
Console.ReadKey();
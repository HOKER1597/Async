// Output a message to the console
Console.WriteLine("Hello, World!");

// Queue a new work item to the thread pool
ThreadPool.QueueUserWorkItem((o) =>
{
    // Loop through 20 times and check if the network is available
    for (int i = 0; i < 20; i++)
    {
        bool isNetworkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        // Output a message with the result of the network check
        Console.WriteLine($"Is network available? Answer: {isNetworkUp}");
        // Pause the thread for 100 milliseconds
        Thread.Sleep(100);
    }
});

// Loop through 10 times and output a message every half second
for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Main thread working...");
    Task.Delay(500);
}

// Output a message indicating that the work is done
Console.WriteLine("Done");

// Wait for a key press before exiting the console application
Console.ReadKey();
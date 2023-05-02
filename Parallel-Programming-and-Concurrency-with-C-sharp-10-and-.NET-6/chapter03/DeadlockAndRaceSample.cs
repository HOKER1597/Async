public class DeadlockSample
{
    // Declare a private object for locking and a list to store some data
    private object _lock = new object();
    private List<string> _data;

    // Constructor to initialize the list with some values
    public DeadlockSample()
    {
        _data = new List<string> { "First", "Second", "Third" };
    }

    // Method to process the data with a lock
    public async Task ProcessData()
    {
        // Acquire a lock on the private object
        lock (_lock)
        {
            // Iterate over the data and write it to the console
            foreach (var item in _data)
            {
                Console.WriteLine(item);
            }

            // Call the AddData method asynchronously and await its completion
            await AddData();
        }
    }

    // Method to add more data to the list with a lock
    private async Task AddData()
    {
        // Acquire a lock on the private object
        lock (_lock)
        {
            // Add more data to the list
            _data.AddRange(GetMoreData());

            // Wait for 100ms asynchronously
            await Task.Delay(100);
        }
    }

    // Method to process the data with a Monitor
    public void ProcessDataWithMonitor()
    {
        // Acquire a lock on the private object
        lock (_lock)
        {
            // Iterate over the data and write it to the console
            foreach (var item in _data)
            {
                Console.WriteLine(item);
            }

            // Call the AddDataWithMonitor method
            AddDataWithMonitor();
        }
    }

    // Method to add more data to the list with a Monitor
    private void AddDataWithMonitor()
    {
        // Try to acquire a lock on the private object for 1 second
        if (Monitor.TryEnter(_lock, 1000))
        {
            try
            {
                // Add more data to the list
                _data.AddRange(GetMoreData());
            }
            finally
            {
                // Release the lock on the private object
                Monitor.Exit(_lock);
            }
        }
        else
        {
            // Write a message to the console if the lock cannot be acquired
            Console.WriteLine($"AddData: Unable to acquire lock. Stack trace: {Environment.StackTrace}");
        }
    }

    // Method to perform calculations with a race condition
    private int _runningTotal;
    public void PerformCalculationsRace()
    {
        // Initialize the running total to 3
        _runningTotal = 3;

        // Invoke two methods asynchronously and wait for their completion
        Parallel.Invoke(() =>
        {
            AddValue().Wait();
        }, () =>
        {
            MultiplyValue().Wait();
        });

        // Write the running total to the console
        Console.WriteLine($"Running total is {_runningTotal}");
    }

    // Method to add and multiply values asynchronously without a race condition
    public async Task PerformCalculations()
    {
        // Initialize the running total to 3
        _runningTotal = 3;

        // Multiply the value asynchronously and then add to it
        await MultiplyValue().ContinueWith(async (Task) =>
        {
            await AddValue();
        });

        // Write the running total to the console
        Console.WriteLine($"Running total is {_runningTotal}");
    }

    // Method to get some more data
    private List<string> GetMoreData()
    {
        return new List<string> { "Fourth", "Fifth", "Sixth" };
    }

    private int _runningTotal;

    // Executes AddValue() and MultiplyValue() concurrently and waits for both to complete
    public void PerformCalculationsRace()
    {
        // Initialize _runningTotal to 3
        _runningTotal = 3;
        Parallel.Invoke(() =>
        {
            // Wait for AddValue() to complete and add 15 to _runningTotal
            AddValue().Wait();
        }, () =>
        {
            // Wait for MultiplyValue() to complete and multiply _runningTotal by 10
            MultiplyValue().Wait();
        });
        // Print the final running total
        Console.WriteLine($"Running total is {_runningTotal}");
    }

    // Add 15 to _runningTotal after waiting for 100ms
    private async Task AddValue()
    {
        await Task.Delay(100);
        _runningTotal += 15;
    }

    // Multiply _runningTotal by 10 after waiting for 100ms
    private async Task MultiplyValue()
    {
        await Task.Delay(100);
        _runningTotal = _runningTotal * 10;
    }

    // Waits for MultiplyValue() to complete, and then adds 15 to _runningTotal
    public async Task PerformCalculations()
    {
        // Initialize _runningTotal to 3
        _runningTotal = 3;
        await MultiplyValue().ContinueWith(async (Task) =>
        {
            await AddValue();
        });
        // Print the final running total
        Console.WriteLine($"Running total is {_runningTotal}");
    }
}
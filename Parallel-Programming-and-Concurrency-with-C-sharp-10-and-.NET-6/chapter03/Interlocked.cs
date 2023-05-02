public class InterlockedSample
{
    private long _runningTotal;

    public void PerformCalculations()
    {
        // Set the initial value of _runningTotal to 3
        _runningTotal = 3;

        // Executes AddValue() and MultiplyValue() concurrently and waits for both to complete
        Parallel.Invoke(() =>
        {
            AddValue().Wait();
        }, () =>
        {
            MultiplyValue().Wait();
        });

        // Outputs the final value of _runningTotal
        Console.WriteLine($"Running total is {_runningTotal}");
    }

    private async Task AddValue()
    {
        // Wait for 100 milliseconds
        await Task.Delay(100);

        // Adds 15 to the _runningTotal using Interlocked.Add method to ensure atomicity
        Interlocked.Add(ref _runningTotal, 15);
    }

    private async Task MultiplyValue()
    {
        // Wait for 100 milliseconds
        await Task.Delay(100);

        // Read the current value of _runningTotal using Interlocked.Read method
        var currentTotal = Interlocked.Read(ref _runningTotal);

        // Multiply the current value of _runningTotal by 10 using Interlocked.Exchange method to ensure atomicity
        Interlocked.Exchange(ref _runningTotal, currentTotal * 10);
    }
}

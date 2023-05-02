namespace InterlockedSample
{
    public class InterlockedExample
    {
        // Declare a private field to store the running total.
        private long _runningTotal; 

        public void PerformCalculations()
        {
            // Initialize the running total to 3.
            _runningTotal = 3; 
            // Invoke two actions in parallel.
            Parallel.Invoke(() => 
            {
                // Call AddValue and wait for it to complete.
                AddValue().Wait(); 
            }, () =>
            {
                // Call MultiplyValue and wait for it to complete.
                MultiplyValue().Wait(); 
            });
            // Print the final running total to the console.
            Console.WriteLine($"Running total is {_runningTotal}"); 
        }

        private async Task AddValue()
        {
            // Simulate a delay.
            await Task.Delay(100); 
            // Add 15 to the running total atomically using Interlocked.
            Interlocked.Add(ref _runningTotal, 15); 
        }

        private async Task MultiplyValue()
        {
            // Simulate a delay.
            await Task.Delay(100); 
            // Read the current value of the running total atomically using Interlocked.
            var currentTotal = Interlocked.Read(ref _runningTotal); 
            // Multiply the current value of the running total by 10 and store the result atomically using Interlocked.
            Interlocked.Exchange(ref _runningTotal, currentTotal * 10); 
        }
    }
}

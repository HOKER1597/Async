// This code is contained in the ParallelExamples namespace and defines a class called ParallelForEachExample

namespace ParallelExamples
{
    internal class ParallelForEachExample
    {
        // This method executes a parallel loop over the provided list of numbers
        internal void ExecuteParallelForEach(IList<int> numbers)
        {
            // Use the Parallel.ForEach method to loop over the numbers list in parallel
            Parallel.ForEach(numbers, number =>
            {
                // Check if the current time contains the current number in the loop
                bool timeContainsNumber = DateTime.Now.ToLongTimeString().Contains(number.ToString());
                // Output a message to the console depending on whether or not the current time contains the current number
                if (timeContainsNumber)
                {
                    Console.WriteLine($"The current time contains number {number}. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                }
                else
                {
                    Console.WriteLine($"The current time does not contain number {number}. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                }
            });
        }
    }
}
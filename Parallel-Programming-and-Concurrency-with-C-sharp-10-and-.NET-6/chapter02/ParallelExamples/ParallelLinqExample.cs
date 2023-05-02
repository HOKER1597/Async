namespace ParallelExamples 
{
    internal class ParallelLinqExample 
    {
        // Executes a LINQ query to get even numbers from a list
        internal void ExecuteLinqQuery(IList<int> numbers) 
        {
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            // Outputs even numbers obtained using regular LINQ query
            OutputNumbers(evenNumbers, "Regular");
        }

        // Executes a Parallel LINQ query to get even numbers from a list
        internal void ExecuteParallelLinqQuery(IList<int> numbers) 
        {
            var evenNumbers = numbers.AsParallel().Where(n => IsEven(n));
            // Outputs even numbers obtained using Parallel LINQ query
            OutputNumbers(evenNumbers, "Parallel");
        }

        // Method to check if a number is even
        private bool IsEven(int number) 
        {
            Task.Delay(100); // delay to simulate a computationally intensive operation
            return number % 2 == 0;
        }

        // Method to output a string representation of a list of numbers
        private void OutputNumbers(IEnumerable<int> numbers, string loopType) 
        {
            var numberString = string.Join(",", numbers);
            Console.WriteLine($"{loopType} number string: {numberString}");
        }
    } 
}

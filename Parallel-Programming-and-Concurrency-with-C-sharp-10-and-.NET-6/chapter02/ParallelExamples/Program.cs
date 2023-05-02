// This code imports the ParallelExamples namespace

using ParallelExamples;

// Create an instance of the ParallelInvokeExample class and call the DoWorkInParallel method to execute a set of tasks in parallel
var parallelExample = new ParallelInvokeExample();
parallelExample.DoWorkInParallel();

// Create a list of integers and an instance of the ParallelForEachExample class, and call the ExecuteParallelForEach method to execute a loop over the list in parallel
var numbers = new List<int> { 1, 3, 5, 7, 9, 0 };
var foreachExample = new ParallelForEachExample();
foreachExample.ExecuteParallelForEach(numbers);

// Create a list of integers and an instance of the ParallelLinqExample class, and call the ExecuteLinqQuery and ExecuteParallelLinqQuery methods to execute LINQ queries on the list
var linqNumbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
var linqExample = new ParallelLinqExample();
linqExample.ExecuteLinqQuery(linqNumbers);
linqExample.ExecuteParallelLinqQuery(linqNumbers);
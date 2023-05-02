//namespace for examples related to parallel programming
namespace ParallelExamples
{
    //class for parallel invocation example
    internal class ParallelInvokeExample
    {
        //method to do work in parallel
        internal void DoWorkInParallel()
        {
            //invoke multiple delegates in parallel using Parallel.Invoke method
            Parallel.Invoke(
                DoComplexWork,                                              //1st delegate
                () => {                                                     //2nd delegate with lambda expression
                    Console.WriteLine($"Hello from lambda expression. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                },
                new Action(() =>                                            //3rd delegate using Action delegate
                {
                    Console.WriteLine($"Hello from Action. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                }),
                delegate ()                                                 //4th delegate using anonymous method
                {
                    Console.WriteLine($"Hello from delegate. Thread id: {Thread.CurrentThread.ManagedThreadId}");
                }
            );
        }

        //method to do complex work
        private void DoComplexWork()
        {
            Console.WriteLine($"Hello from DoComplexWork method. Thread id: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
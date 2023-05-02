namespace AsyncSamples
{
    public class TaskSample
    {
        // This method uses the "async/await" pattern correctly
        public async Task DoThingsAsync()
        {
            Console.WriteLine($"Doing things in {nameof(DoThingsAsync)}");
            // This call to an asynchronous method is awaited correctly
            await DoFirstThingAsync();
            // This call to an asynchronous method is awaited correctly
            await DoSecondThingAsync();
            Console.WriteLine($"Did things in {nameof(DoThingsAsync)}");
        }

        // This method calls an asynchronous method incorrectly
        public async Task DoingThingsWrongAsync()
        {
            Console.WriteLine($"Doing things in {nameof(DoingThingsWrongAsync)}");
            // This call to an asynchronous method is not awaited or assigned to a variable
            DoFirstThingAsync();
            // This call to an asynchronous method is awaited correctly
            await DoSecondThingAsync();
            Console.WriteLine($"Did things in {nameof(DoingThingsWrongAsync)}");
        }

        // This method blocks on an asynchronous method, which is not recommended
        public async Task DoBlockingThingsAsync()
        {

            Console.WriteLine($"Doing things in {nameof(DoBlockingThingsAsync)}");
            // This call to an asynchronous method blocks the current thread, which can lead to deadlocks
            DoFirstThingAsync().Wait();
            // This call to an asynchronous method is awaited correctly
            await DoSecondThingAsync();
            Console.WriteLine($"Did things in {nameof(DoBlockingThingsAsync)}");
        }

        // These methods are called correctly with the "await" keyword
        private async Task DoFirstThingAsync()
        {
            Console.WriteLine($"Doing something in {nameof(DoFirstThingAsync)}");
            // This call to an asynchronous method is awaited correctly
            await DoAnotherThingAsync();
            Console.WriteLine($"Did something in {nameof(DoFirstThingAsync)}");
        }

        private async Task DoSecondThingAsync()
        {
            Console.WriteLine($"Doing something in {nameof(DoSecondThingAsync)}");
            // This call to an asynchronous method is awaited correctly
            await Task.Delay(500);
            Console.WriteLine($"Did something in {nameof(DoSecondThingAsync)}");
        }

        private async Task DoAnotherThingAsync()
        {
            Console.WriteLine($"Doing something in {nameof(DoAnotherThingAsync)}");
            // This call to an asynchronous method is awaited correctly
            await Task.Delay(1500);
            Console.WriteLine($"Did something in {nameof(DoAnotherThingAsync)}");
        }
    }
}

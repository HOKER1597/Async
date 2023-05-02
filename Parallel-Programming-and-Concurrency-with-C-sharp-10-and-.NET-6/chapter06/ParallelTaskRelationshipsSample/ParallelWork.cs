namespace ParallelTaskRelationshipsSample
{
    // This class provides examples of parallel work using Task.
    public class ParallelWork
    {
        // Performs three actions in parallel, each on a separate task.
        // The parent task waits for the child tasks to complete.
        public void DoAllWork()
        {
            Console.WriteLine("Starting DoAllWork");
            Task parentTask = Task.Factory.StartNew(() =>
            {
                var child1 = Task.Factory.StartNew(DoFirstItem);
                var child2 = Task.Factory.StartNew(DoSecondItem);
                var child3 = Task.Factory.StartNew(DoThirdItem);
            });
            parentTask.Wait();
            Console.WriteLine("Finishing DoAllWork");
        }

        // Performs three actions in parallel, each on a separate task.
        // The child tasks are attached to the parent task, so the parent task waits for them to complete.
        public void DoAllWorkAttached()
        {
            Console.WriteLine("Starting DoAllWorkAttached");
            Task parentTask = Task.Factory.StartNew(() =>
            {
                var child1 = Task.Factory.StartNew(DoFirstItem, TaskCreationOptions.AttachedToParent);
                var child2 = Task.Factory.StartNew(DoSecondItem, TaskCreationOptions.AttachedToParent);
                var child3 = Task.Factory.StartNew(DoThirdItem, TaskCreationOptions.AttachedToParent);
            });
            parentTask.Wait();
            Console.WriteLine("Finishing DoAllWorkAttached");
        }

        // Performs three actions in parallel, each on a separate task.
        // The child tasks are attached to the parent task, but the parent task is created with the option to deny child task attachment.
        public void DoAllWorkDenyAttach()
        {
            Console.WriteLine("Starting DoAllWorkDenyAttach");
            Task parentTask = Task.Factory.StartNew(() =>
            {
                var child1 = Task.Factory.StartNew(DoFirstItem, TaskCreationOptions.AttachedToParent);
                var child2 = Task.Factory.StartNew(DoSecondItem, TaskCreationOptions.AttachedToParent);
                var child3 = Task.Factory.StartNew(DoThirdItem, TaskCreationOptions.AttachedToParent);
            }, TaskCreationOptions.DenyChildAttach);
            parentTask.Wait();
            Console.WriteLine("Finishing DoAllWorkDenyAttach");
        }

        // Simulates work for the first task.
        public void DoFirstItem()
        {
            Console.WriteLine("Starting DoFirstItem");
            Thread.SpinWait(1000000);
            Console.WriteLine("Finishing DoFirstItem");
        }

        // Simulates work for the second task.
        public void DoSecondItem()
        {
            Console.WriteLine("Starting DoSecondItem");
            Thread.SpinWait(1000000);
            Console.WriteLine("Finishing DoSecondItem");
        }

        // Simulates work for the third task.
        public void DoThirdItem()
        {
            Console.WriteLine("Starting DoThirdItem");
            Thread.SpinWait(1000000);
            Console.WriteLine("Finishing DoThirdItem");
        }
    }
}
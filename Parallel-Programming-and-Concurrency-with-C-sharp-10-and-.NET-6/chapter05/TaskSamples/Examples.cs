namespace TaskSamples
{
    public class Examples
    {
        // This method processes orders asynchronously using multiple tasks.
        // It first creates a task to prepare the orders by calling the PrepareOrders method.
        // Then it creates a long-running task to create labels for the orders by calling the CreateLabels method.
        // Finally, it creates a continuation task that sends the prepared orders by calling the SendOrders method.
        // The method waits for both the label and send tasks to complete by calling the WaitAll method of the Task class.
        // After both tasks complete, it sends a confirmation message to the customer by calling the SendConfirmation method.
        public void ProcessOrders(List<Order> orders, int customerId)
        {
            Task<List<Order>> processOrdersTask = Task.Run(() => PrepareOrders(orders));
            Task labelTask = Task.Factory.StartNew(() => CreateLabels(orders), TaskCreationOptions.LongRunning);
            Task sendTask = processOrdersTask.ContinueWith(task => SendOrders(task.Result));

            Task.WaitAll(new[] { labelTask, sendTask });

            SendConfirmation(customerId);
        }

        // This method processes data asynchronously using a task.
        // It first creates a task to process the data by calling the DoDataProcessing method.
        // If the data processing requires a UI thread, it runs the task synchronously on the current thread.
        // If the data processing does not require a UI thread, it starts the task on a ThreadPool thread in the background.
        public void ProcessData(object data, bool uiRequired)
        {
            Task processTask = new(() => DoDataProcessing(data));

            if (uiRequired)
            {
                // Run on current thread (UI thread assumed for example)
                processTask.RunSynchronously();
            }
            else
            {
                // Run on ThreadPool thread in background
                processTask.Start();
            }
        }

        // This method processes the data.
        // Add the data processing logic here.
        private void DoDataProcessing(object data)
        {
            // TODO: Process the data
        }

        // This method prepares the orders.
        // Add the order preparation logic here.
        private List<Order> PrepareOrders(List<Order> orders)
        {
            // TODO: Prepare orders here
            return orders;
        }

        // This method creates labels for the orders.
        // Add the label creation logic here.
        private void CreateLabels(List<Order> orders)
        {
            // TODO: Create labels here
        }

        // This method sends the prepared orders.
        // Add the order sending logic here.
        private void SendOrders(List<Order> orders)
        {
            // TODO: Send orders here
        }

        // This method sends a confirmation message to the customer.
        // Add the confirmation sending logic here.
        private void SendConfirmation(int customerId)
        {
            // TODO: Send confirmation message to customer
        }
    }
}
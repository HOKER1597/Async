using TaskSamples;

// Create an instance of the Examples class.
var examples = new Examples();

// Process the orders asynchronously by calling the ProcessOrders method of the examples object.
// Pass an empty list of orders and a customer ID to the method.
examples.ProcessOrders(new List<Order>(), 123);

// Write a message to the console to indicate that the order processing is complete.
Console.WriteLine("Done with orders!");
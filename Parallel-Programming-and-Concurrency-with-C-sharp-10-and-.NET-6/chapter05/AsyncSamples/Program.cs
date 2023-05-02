using AsyncSamples;

// Print a message indicating that the processing is starting
Console.WriteLine("Start processing...");

// Create an instance of TaskSample and invoke its DoThingsAsync method asynchronously
var taskSample = new TaskSample();
await taskSample.DoThingsAsync();

// Print a message indicating that the processing is continuing
Console.WriteLine("Continue processing...");

// Invoke the DoingThingsWrongAsync method, which performs a blocking operation on the main thread
await taskSample.DoingThingsWrongAsync();

// Print a message indicating that the processing is continuing
Console.WriteLine("Continue processing...");

// Invoke the DoBlockingThingsAsync method, which performs a blocking operation on a background thread
await taskSample.DoBlockingThingsAsync();

// Print a message indicating that the processing is done
Console.WriteLine("Done processing...");

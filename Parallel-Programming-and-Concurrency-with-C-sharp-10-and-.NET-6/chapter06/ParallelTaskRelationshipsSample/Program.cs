using ParallelTaskRelationshipsSample;

// Create an instance of the ParallelWork class.
var parallelWork = new ParallelWork();

// Call one of the methods to perform parallel work using Task.
// Uncomment one of the following lines to choose a method to call.

// parallelWork.DoAllWork();
// Performs three actions in parallel, each on a separate task.
// The parent task waits for the child tasks to complete.

// parallelWork.DoAllWorkAttached();
// Performs three actions in parallel, each on a separate task attached to the parent task.
// The parent task waits for the child tasks to complete.

parallelWork.DoAllWorkDenyAttach();
// Performs three actions in parallel, each on a separate task attached to the parent task,
// but the parent task is created with the option to deny child task attachment.
// The parent task waits for the child tasks to complete.

// Wait for user input before exiting the program.
Console.ReadKey();
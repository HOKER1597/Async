using SyncAndAsyncSamples.AsyncToSync;
using SyncAndAsyncSamples.Models;
//using SyncAndAsyncSamples.SyncToAsync;

//Console.WriteLine("Hello, sync to async world!");
//var medLoader = new MedicationLoader();
//Patient? patient = medLoader.GetPatientAndMedications(123);

//Console.WriteLine($"Loaded patient: {patient.Name} with {patient.Medications.Count} mediations.");

// Output a greeting message for the async to sync world.
Console.WriteLine("Hello, async to sync world!");

// Create a new instance of the PatientLoader class.
var loader = new PatientLoader();

// Call the GetPatientAndMedsAsync method asynchronously and await its result.
// The patient object and its medications are loaded asynchronously and then converted to synchronous code using the await keyword.
Patient? patient = await loader.GetPatientAndMedsAsync(123);

// Output a message indicating that the patient data has been loaded successfully.
Console.WriteLine($"Loaded patient: {patient.Name} with {patient.Medications.Count} medications.");
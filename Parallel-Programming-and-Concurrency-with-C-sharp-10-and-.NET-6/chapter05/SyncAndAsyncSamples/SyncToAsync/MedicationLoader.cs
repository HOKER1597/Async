// Import the required namespace
using SyncAndAsyncSamples.Models;

namespace SyncAndAsyncSamples.SyncToAsync
{
    // Define a class called MedicationLoader
    public class MedicationLoader
    {
        // Declare a private field of type HealthcareService
        private HealthcareService _healthcareService;

        // Define a constructor for the MedicationLoader class
        public MedicationLoader()
        {
            // Instantiate a new HealthcareService object and assign it to the _healthcareService field
            _healthcareService = new HealthcareService();
        }

        // Define a public method called GetPatientAndMedications that returns a nullable Patient object
        public Patient? GetPatientAndMedications(int patientId)
        {
            // Declare a null Patient object
            Patient? patient = null;
            try
            {
                // Call the asynchronous GetPatientInfoAsync method of the _healthcareService field and get its result
                patient = _healthcareService.GetPatientInfoAsync(patientId).Result;
            }
            catch (AggregateException ae)
            {
                // If an exception occurs, write an error message to the console
                Console.WriteLine($"Error loading patient. Message: {ae.Flatten().Message}");
            }

            // If the patient object is not null, call the ProcessPatientInfo method and return the resulting patient object
            if (patient != null)
            {
                patient = ProcessPatientInfo(patient);
                return patient;
            }
            // Otherwise, return null
            else
            {
                return null;
            }
        }

        // Define a private method called ProcessPatientInfo that takes a Patient object as a parameter and returns a Patient object
        private Patient ProcessPatientInfo(Patient patient)
        {
            // Add additional processing to the patient object here, if needed
            return patient;
        }
    }
}

using SyncAndAsyncSamples.Models;

namespace SyncAndAsyncSamples.AsyncToSync
{
    public class PatientService
    {
        // Method that retrieves patient information synchronously and returns a Patient object.
        public Patient GetPatientInfo(int patientId)
        {
            // Simulate a delay of 2 seconds to mimic a long-running operation.
            Thread.Sleep(2000);

            // Create a new Patient object with some sample data.
            Patient patient = new()
            {
                Id = patientId,
                Name = "Smith, Terry",
                PrimaryCareProvider = new Provider
                {
                    Id = 999,
                    Name = "Dr. Amy Ng"
                },
                Medications = new List<Medication>
                {
                    new Medication { Id = 1, Name = "acetaminophen" },
                    new Medication { Id = 2, Name = "hydrocortisone cream" }
                }
            };

            // Return the patient object.
            return patient;
        }
    }
}

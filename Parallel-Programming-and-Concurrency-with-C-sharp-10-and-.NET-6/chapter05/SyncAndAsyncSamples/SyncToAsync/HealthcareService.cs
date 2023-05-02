using SyncAndAsyncSamples.Models;

namespace SyncAndAsyncSamples.SyncToAsync
{
    public class HealthcareService
    {
        // This method asynchronously loads patient information by simulating a delay of 2 seconds using Task.Delay.
        // It then creates a new Patient object with some sample data, including an ID, name, primary care provider, and a list of medications.
        // The method returns the patient object wrapped in a Task object, which allows it to be awaited asynchronously.
        public async Task<Patient> GetPatientInfoAsync(int patientId)
        {
            await Task.Delay(2000);

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

            return patient;
        }
    }
}
using SyncAndAsyncSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncAndAsyncSamples.AsyncToSync
{
    public class PatientLoader
    {
        private PatientService _patientService;

        // Constructor initializes a new PatientService instance.
        public PatientLoader()
        {
            _patientService = new PatientService();
        }

        // Method that loads patient information asynchronously and returns a Patient object.
        public async Task<Patient?> GetPatientAndMedsAsync(int patientId)
        {
            Patient? patient = null;
            try
            {
                // Load patient information asynchronously using Task.Run and GetPatientInfo method from the PatientService.
                patient = await Task.Run(() => _patientService.GetPatientInfo(patientId));
            }
            catch (Exception e)
            {
                // Catch any exceptions thrown during loading and print an error message to the console.
                Console.WriteLine($"Error loading patient. Message: {e.Message}");
            }

            if (patient != null)
            {
                // Process patient information asynchronously using the ProcessPatientInfoAsync method.
                patient = await ProcessPatientInfoAsync(patient);
                return patient;
            }
            else
            {
                // If the patient object is null, return null.
                return null;
            }
        }

        // Method that processes patient information asynchronously and returns a Patient object.
        private async Task<Patient> ProcessPatientInfoAsync(Patient patient)
        {
            // Introduce an artificial delay of 100 milliseconds to simulate additional processing.
            await Task.Delay(100);
            // Add additional processing logic here.
            return patient;
        }
    }
}

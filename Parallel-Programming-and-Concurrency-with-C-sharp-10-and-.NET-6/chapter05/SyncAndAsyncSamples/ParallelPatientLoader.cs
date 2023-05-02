using SyncAndAsyncSamples.Models;

namespace SyncAndAsyncSamples
{
    public class ParallelPatientLoader
    {
        // Fields to store patient, provider, and medications data.
        private Patient _patient;
        private Provider _provider;
        private List<Medication> _medications;

        // This method loads patient information asynchronously by calling three other asynchronous methods that load patient info, provider info, and medications.
        // The three tasks are added to a list of tasks and awaited using Task.WhenAll.
        // Once all three tasks are completed, the patient object is updated with the loaded information and returned.
        public async Task<Patient> LoadPatientAsync(int patientId)
        {
            var taskList = new List<Task>
            {
                LoadPatientInfoAsync(patientId),
                LoadProviderAsync(patientId),
                LoadMedicationsAsync(patientId)
            };

            await Task.WhenAll(taskList.ToArray());
            _patient.Medications = _medications;
            _patient.PrimaryCareProvider = _provider;

            return _patient;
        }

        // This method loads patient information synchronously by calling three other asynchronous methods that load patient info, provider info, and medications.
        // The three tasks are added to a list of tasks and waited using Task.WaitAll.
        // Once all three tasks are completed, the patient object is updated with the loaded information and returned.
        public Patient LoadPatient(int patientId)
        {
            var taskList = new List<Task>
            {
                LoadPatientInfoAsync(patientId),
                LoadProviderAsync(patientId),
                LoadMedicationsAsync(patientId)
            };

            Task.WaitAll(taskList.ToArray());
            _patient.Medications = _medications;
            _patient.PrimaryCareProvider = _provider;

            return _patient;
        }

        // This method loads patient information asynchronously by simulating a delay using Task.Delay and then creating a new Patient object with some sample data.
        // The patient object is stored in the _patient field.
        public async Task LoadPatientInfoAsync(int patientId)
        {
            await Task.Delay(100);
            _patient = new Patient { Id = patientId, Name = "Smith, Gail" };
        }

        // This method loads provider information asynchronously by simulating a delay using Task.Delay and then creating a new Provider object with some sample data.
        // The provider object is stored in the _provider field.
        public async Task LoadProviderAsync(int patientId)
        {
            await Task.Delay(100);
            _provider = new Provider { Id = 44, Name = "Dr. Sammy Hamm" };
        }

        // This method loads medication information asynchronously by simulating a delay using Task.Delay and then creating a new List of Medication objects with some sample data.
        // The medication list is stored in the _medications field.
        public async Task LoadMedicationsAsync(int patientId)
        {
            await Task.Delay(100);
            _medications = new List<Medication>
                {
                    new Medication { Id = 1, Name = "acetaminophen" },
                    new Medication { Id = 2, Name = "hydrocortisone cream" }
                };
        }
    }
}
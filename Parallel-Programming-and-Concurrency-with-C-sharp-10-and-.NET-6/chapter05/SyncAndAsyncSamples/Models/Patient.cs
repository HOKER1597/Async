namespace SyncAndAsyncSamples.Models
{
    // A class representing a patient.
    public class Patient
    {
        // The ID of the patient.
        public int Id { get; set; }
        
        // The name of the patient (nullable string).
        public string? Name { get; set; }
        
        // A list of medications that the patient is currently taking (nullable list of Medication objects).
        public List<Medication>? Medications { get; set; }
        
        // The primary care provider for the patient (nullable Provider object).
        public Provider? PrimaryCareProvider { get; set; }
    }
}

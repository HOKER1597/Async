namespace AsyncSamples
{
    // This class represents a journal entry
    [Serializable]
    public class JournalEntry
    {
        // The title of the entry
        public string Title { get; set; }
        
        // A short description of the entry
        public string Description { get; set; }
        
        // The date the entry was made
        public DateTime EntryDate { get; set; }
        
        // The content of the entry
        public string EntryText { get; set; }
    }
}

namespace WinFormsParallelLoopApp
{
    // Represents data about a collection of FileInfo objects.
    public class FileData
    {
        // Gets or sets the list of FileInfo objects.
        public List<FileInfo> FileInfoList { get; set; } = new();

        // Gets or sets the total size of all FileInfo objects in bytes.
        public long TotalSize { get; set; } = 0;

        // Gets or sets the name of the last FileInfo object that was written to.
        public string LastWrittenFileName { get; set; } = "";

        // Gets or sets the date and time the last FileInfo object was written to.
        public DateTime LastFileWriteTime { get; set; }
    }
}
// Import required namespaces
using System.Text;

// Declare namespace for the application
namespace WinFormsParallelLoopApp
{
    // Declare the main form class that inherits the Form class
    public partial class ParallelLoopForm : Form
    {
        // Declare a CancellationTokenSource instance variable
        private CancellationTokenSource _cts;

        // Declare the class constructor
        public ParallelLoopForm()
        {
            // Call the InitializeComponent() method
            InitializeComponent();
        }

        // Declare the event handler for the FolderBrowseButton click event
        private void FolderBrowseButton_Click(object sender, EventArgs e)
        {
            // Show the folder browser dialog and get the result
            var result = folderToProcessDialog.ShowDialog();
            // If the user clicked OK
            if (result == DialogResult.OK)
            {
                // Set the selected path to the text box
                FolderToProcessTextBox.Text = folderToProcessDialog.SelectedPath;
            }
        }

        // Declare the event handler for the FolderProcessButton click event
        private void FolderProcessButton_Click(object sender, EventArgs e)
        {
            // Check if the folder text box is not empty and the folder exists
            if (!string.IsNullOrWhiteSpace(FolderToProcessTextBox.Text) &&
                Directory.Exists(FolderToProcessTextBox.Text))
            {
                // Get an array of file names from the selected folder
                string[] filesToProcess = Directory.GetFiles(FolderToProcessTextBox.Text);
                // Call the GetInfoForFilesThreadLocal() method to get file data
                FileData? results = FileProcessor.GetInfoForFilesThreadLocal(filesToProcess);

                // If the file data is null
                if (results == null)
                {
                    // Set the folder results text box to empty and return
                    FolderResultsTextBox.Text = "";
                    return;
                }

                // Declare a StringBuilder instance to store the result text
                StringBuilder resultText = new();
                // Append the total file count and file size to the result text
                resultText.Append($"Total file count: {results.FileInfoList.Count}; ");
                resultText.AppendLine($"Total file size: {results.TotalSize} bytes");
                // Append the name and time of last written file to the result text
                resultText.Append($"Last written file: {results.LastWrittenFileName} ");
                resultText.Append($"at {results.LastFileWriteTime}");
                // Set the folder results text box text to the result text
                FolderResultsTextBox.Text = resultText.ToString();
            }
        }

        // Declare the event handler for the ProcessJpgsButton click event
        private async void ProcessJpgsButton_Click(object sender, EventArgs e)
        {
            // Check if the folder text box is not empty and the folder exists
            if (!string.IsNullOrWhiteSpace(FolderToProcessTextBox.Text) &&
                Directory.Exists(FolderToProcessTextBox.Text))
            {
                // Initialize a new CancellationTokenSource instance
                _cts = new CancellationTokenSource();
                // Get a list of file names from the selected folder
                List<string> filesToProcess = Directory.GetFiles(FolderToProcessTextBox.Text).ToList();
                // Call the ConvertFilesToBitmapsAsync() method to convert files to bitmaps
                List<Bitmap> results = await FileProcessor.ConvertFilesToBitmapsAsync(filesToProcess, _cts);

                // Declare a StringBuilder instance to store the result text
                StringBuilder resultText = new();

                // Iterate through each bitmap in the results list
                foreach (var bmp in results)
                {
                    // Append the bitmap height to the result text
                    resultText.AppendLine($"Bitmap height: {bmp.Height}");
                }

                // Set the folder results text box text to the result text\n                
                FolderResultsTextBox.Text = resultText.ToString();
            }
        }

        // Declare the event handler for the CancelButton click event
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // If the CancellationTokenSource instance is not null
            if (_cts != null)
            {
                // Cancel the asynchronous operation
                _cts.Cancel();
            }
        }
    }
}
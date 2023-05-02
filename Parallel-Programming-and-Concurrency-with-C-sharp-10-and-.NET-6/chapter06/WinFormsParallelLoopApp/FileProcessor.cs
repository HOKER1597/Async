//This is the WinFormsParallelLoopApp namespace.
namespace WinFormsParallelLoopApp 
{
    //This is the FileProcessor class.
    public class FileProcessor 
    {
        //This is the GetInfoForFiles method that takes an array of file paths and returns file information.
        public static FileData GetInfoForFiles(string[] files) 
        {
            //Create a new instance of FileData.
            var results = new FileData();
            //Create a new List object to store file information.
            var fileInfos = new List<FileInfo>();
            //Initialize the total file size to 0.
            long totalFileSize = 0;
            //Initialize lastWriteTime to the minimum DateTime value.
            DateTime lastWriteTime = DateTime.MinValue;
            //Initialize lastFileWritten to an empty string.
            string lastFileWritten = "";
            //Create an object to lock date operations.
            object dateLock = new();

            //Execute a parallel loop over the files array using Parallel.For.
            Parallel.For(0, files.Length,
                   index => {
                        //Get the file information for the current file.
                       FileInfo fi = new(files[index]);
                        //Get the size of the current file.
                       long size = fi.Length;
                        //Get the last write time of the current file.
                       DateTime lastWrite = fi.LastWriteTimeUtc;
                       //Lock date operations with dateLock.
                       lock (dateLock)
                       {
                           //If the last write time of the current file is greater than the current lastWriteTime value, update lastWriteTime and lastFileWritten.
                           if (lastWriteTime < lastWrite)
                           {
                               lastWriteTime = lastWrite;
                               lastFileWritten = fi.Name;
                           }
                       }
                       //Add the size of the current file to the total file size using Interlocked.Add.
                       Interlocked.Add(ref totalFileSize, size);
                       //Add the FileInfo object for the current file to fileInfos.
                       fileInfos.Add(fi);
                   });

            //Assign the results for total size, last file write time, last written file name, and file information List.
            results.FileInfoList = fileInfos;
            results.TotalSize = totalFileSize;
            results.LastFileWriteTime = lastWriteTime;
            results.LastWrittenFileName = lastFileWritten;

            //Return the results object.
            return results;
        }

        //This is the GetInfoForFilesThreadLocal method that takes an array of file paths and returns file information.
        public static FileData GetInfoForFilesThreadLocal(string[] files) 
        {
            //Create a new instance of FileData.
            var results = new FileData();
            //Create a new List object to store file information.
            var fileInfos = new List<FileInfo>();
            //Initialize the total file size to 0.
            long totalFileSize = 0;
            //Initialize lastWriteTime to the minimum DateTime value.
            DateTime lastWriteTime = DateTime.MinValue;
            //Initialize lastFileWritten to an empty string.
            string lastFileWritten = "";
            //Create an object to lock date operations.
            object dateLock = new();

            //Execute a parallel loop over the files array using Parallel.For.
            Parallel.For<long>(0, files.Length, () => 0,
                (index, loop, subtotal) => {
                    //Get the file information for the current file.
                    FileInfo fi = new(files[index]);
                    //Get the size of the current file.
                    long size = fi.Length;
                    //Get the last write time of the current file.
                    DateTime lastWrite = fi.LastWriteTimeUtc;
                    //Lock date operations with dateLock.
                    lock (dateLock)
                    {
                        //If the last write time of the current file is greater than the current lastWriteTime value, update lastWriteTime and lastFileWritten.
                        if (lastWriteTime < lastWrite)
                        {
                            lastWriteTime = lastWrite;
                            lastFileWritten = fi.Name;
                        }
                    }
                    //Add the size of the current file to the subtotal using the accumulator.
                    subtotal += size;
                    //Add the FileInfo object for the current file to fileInfos.
                    fileInfos.Add(fi);
                    //Return the updated subtotal value as the result.
                    return subtotal;
                   },
                //Use Interlocked.Add to add all the subtotals together and update totalFileSize.
                (runningTotal) => Interlocked.Add(ref totalFileSize, runningTotal)
            );

            //Assign the results for total size, last file write time, last written file name, and file information List.
            results.FileInfoList = fileInfos;
            results.TotalSize = totalFileSize;
            results.LastFileWriteTime = lastWriteTime;
            results.LastWrittenFileName = lastFileWritten;

            //Return the results object.
            return results;
        }

        //This is the ConvertFilesToBitmaps method that takes a List of file paths and returns a List of Bitmaps.
        public static List<Bitmap> ConvertFilesToBitmaps(List<string> files) 
        {
            //Create a new List object to store the Bitmaps.
            var result = new List<Bitmap>();

            //Execute a parallel loop over the files array using Parallel.ForEach.
            Parallel.ForEach(files, file => 
            {
                //Get the file information for the current file.\n                
                FileInfo fi = new(file);
                //Get the file extension for the current file.
                string ext = fi.Extension.ToLower();

                //If the file is a jpeg, convert it to a Bitmap and add it to the result List.
                if (ext == ".jpg" || ext == "jpeg") 
                {
                    result.Add(ConvertJpgToBitmap(file));
                }
            });

            //Return the result List.
            return result;
        }

        //This is the ConvertFilesToBitmapsAsync method that takes a List of file paths and a CancellationTokenSource and returns a List of Bitmaps asynchronously.
        public static async Task<List<Bitmap>> ConvertFilesToBitmapsAsync(List<string> files, CancellationTokenSource cts) 
        {
            //Create a new ParallelOptions object and set its CancellationToken and MaxDegreeOfParallelism properties.
            ParallelOptions po = new()
            {
                CancellationToken = cts.Token,
                MaxDegreeOfParallelism = Environment.ProcessorCount == 1 ? 1
                                            : Environment.ProcessorCount - 1
            };

            //Create a new List object to store the Bitmaps.
            var result = new List<Bitmap>();

            try
            {
                //Execute a parallel forEach loop over the files array using Parallel.ForEachAsync.
                await Parallel.ForEachAsync(files, po, async (file, _cts) => 
                {
                    //Get the file information for the current file.
                    FileInfo fi = new(file);
                    //Get the file extension for the current file.
                    string ext = fi.Extension.ToLower();

                    //If the file is a jpeg, convert it to a Bitmap, add it to the result List, and delay for 2 seconds.
                    if (ext == ".jpg" || ext == "jpeg")
                    {
                        result.Add(ConvertJpgToBitmap(file));
                        await Task.Delay(2000, _cts);
                    }
                });
            }
            catch (OperationCanceledException e)
            {
                //Display an error message if the operation was cancelled.
                MessageBox.Show(e.Message);
            }
            finally
            {
                //Dispose of the CancellationTokenSource.
                cts.Dispose();
            }

            //Return the result List.
            return result;
        }

        //This is the ConvertJpgToBitmap method that takes a file path for a jpeg and returns a Bitmap object.
        private static Bitmap ConvertJpgToBitmap(string fileName) 
        {
            Bitmap bmp;
            //Open the file stream and create an Image object from it.
            using (Stream bmpStream = File.Open(fileName, FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);
                //Create a new Bitmap object from the Image object and assign it to bmp.
                bmp = new Bitmap(image);
            }
            //Return the bmp object.
            return bmp;
        }
    }
}
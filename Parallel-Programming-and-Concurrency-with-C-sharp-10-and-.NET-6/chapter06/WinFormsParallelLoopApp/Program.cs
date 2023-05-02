namespace WinFormsParallelLoopApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize the application configuration settings.
            // This method sets high DPI settings or default font.
            ApplicationConfiguration.Initialize();

            // Create an instance of the ParallelLoopForm and run it.
            Application.Run(new ParallelLoopForm());
        }
    }
}

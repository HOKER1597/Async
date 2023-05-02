// The namespace WorkingWithTimers holds the TimerForm class and the Program class that will execute the form.

namespace WorkingWithTimers
{
        // The Program class is internal as it only executes the TimerForm class.

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // Initialize the application configuration.
            ApplicationConfiguration.Initialize();
            // Run the TimerForm.
            Application.Run(new TimerForm());
        }
    }
}
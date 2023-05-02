namespace WorkingWithTimers
{
    public partial class TimerForm : Form
    {
        private TimerSample _timerSample;
        private ThreadingTimerSample _threadingTimerSample;
        // Constructor
        public TimerForm()
        {
            InitializeComponent();

            // Initialize the TimerSample and ThreadingTimerSample instances
            _timerSample = new TimerSample();
            _threadingTimerSample = new ThreadingTimerSample();
        }

        // Event handler for the startTimerButton Click event
        // Calls the StartTimer method of the TimerSample instance
        private void startTimerButton_Click(object sender, EventArgs e)
        {
            _timerSample.StartTimer();
        }

        // Event handler for the stopTimerButton Click event
        // Calls the StopTimer method of the TimerSample instance
        private void stopTimerButton_Click(object sender, EventArgs e)
        {
            _timerSample.StopTimer();
        }

        // Event handler for the startThreadingTimerButton Click event
        // Calls the StartTimer method of the ThreadingTimerSample instance
        private void startThreadingTimerButton_Click(object sender, EventArgs e)
        {
            _threadingTimerSample.StartTimer();
        }

        // Event handler for the stopThreadingTimerButton Click event
        // Calls the DisposeTimerAsync method of the ThreadingTimerSample instance asynchronously
        private async void stopThreadingTimerButton_Click(object sender, EventArgs e)
        {
            await _threadingTimerSample.DisposeTimerAsync();
        }
    }

}
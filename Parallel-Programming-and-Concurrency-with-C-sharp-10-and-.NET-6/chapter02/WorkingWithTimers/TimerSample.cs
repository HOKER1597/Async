using System.Diagnostics;

namespace WorkingWithTimers
{
    internal class TimerSample : IDisposable
    {
        private System.Timers.Timer? _timer;
        // Start the timer
        public void StartTimer()
        {
            // If the timer has not been initialized yet, initialize it
            if (_timer == null)
            {
                InitializeTimer();
            }

            // If the timer is not enabled, enable it
            if (_timer != null && !_timer.Enabled)
            {
                _timer.Enabled = true;
            }
        }

        // Stop the timer
        public void StopTimer()
        {
            // If the timer is enabled, disable it
            if (_timer != null && _timer.Enabled)
            {
                _timer.Enabled = false;
            }
        }

        // Initialize the timer
        private void InitializeTimer()
        {
            _timer = new System.Timers.Timer
            {
                Interval = 1000
            };

            // Add the elapsed event handler for the timer
            _timer.Elapsed += _timer_Elapsed;
        }

        // Handle the elapsed event of the timer
        private void _timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            // Check for new messages
            int messageCount = CheckForNewMessageCount();

            // If there are new messages, alert the user
            if (messageCount > 0)
            {
                AlertUser(messageCount);
            }
        }

        // Alert the user about new messages
        private void AlertUser(int messageCount)
        {
            Debug.WriteLine($"You have {messageCount} new messages!");
        }

        // Check for new messages and return their count
        private int CheckForNewMessageCount()
        {
            // Generate a random number of messages to return
            return new Random().Next(100);
        }

        // Dispose the timer
        public void Dispose()
        {
            if (_timer != null)
            {
                // Remove the elapsed event handler for the timer
                _timer.Elapsed -= _timer_Elapsed;
                // Dispose the timer
                _timer.Dispose();
            }
        }
    }
}
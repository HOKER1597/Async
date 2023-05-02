using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithTimers
{
    internal class ThreadingTimerSample
    {
        private System.Threading.Timer? _timer;
        // Start the timer if it hasn't already been started
        public void StartTimer()
        {
            if (_timer == null)
            {
                InitializeTimer();
            }
        }

        // Dispose the timer asynchronously
        public async Task DisposeTimerAsync()
        {
            if (_timer != null)
            {
                await _timer.DisposeAsync();
            }
        }

        // Initialize the timer
        private void InitializeTimer()
        {
            // Create a new instance of the MessageUpdater class
            var updater = new MessageUpdater();

            // Create a new System.Threading.Timer that will call the TimerFired method every 1 second
            _timer = new System.Threading.Timer(
                callback: new TimerCallback(TimerFired),
                state: updater,
                dueTime: 500,
                period: 1000);
        }

        // This method is called by the timer every 1 second
        private void TimerFired(object? state)
        {
            // Check for new messages
            int messageCount = CheckForNewMessageCount();

            // If there are new messages and the state object is a MessageUpdater instance, update the UI
            if (messageCount > 0 && state is MessageUpdater updater)
            {
                updater.Update(messageCount);
            }
        }

        // This method generates a random number of new messages to simulate checking for new messages
        private int CheckForNewMessageCount()
        {
            // Generate a random number of messages to return
            return new Random().Next(100);
        }
    }

    // This class is responsible for updating the UI with the new message count
    internal class MessageUpdater
    {
        internal void Update(int messageCount)
        {
            Debug.WriteLine($"You have {messageCount} new messages!");
        }
    }
}
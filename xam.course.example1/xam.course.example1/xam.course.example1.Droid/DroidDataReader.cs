using System;
using System.Timers;
using xam.course.example1.Services;

namespace xam.course.example1.Droid
{
    public class DroidDataReader : IDataReader
    {
        private readonly Random _random;
        public event EventHandler<int> DataReceived;

        public DroidDataReader()
        {
            this._random = new Random();
            var timer = new Timer();
            timer.Elapsed += TimerOnElapsed;
            timer.Interval = 5000;
            timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            var nextValue = this._random.Next();
            
            this.DataReceived?.Invoke(this,nextValue);
        }
    }
}
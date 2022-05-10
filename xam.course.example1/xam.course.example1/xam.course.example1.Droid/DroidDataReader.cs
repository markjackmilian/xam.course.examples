using System;
using System.Timers;
using Android.Content;
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

            //Android.App.Application.Context.RegisterReceiver(new ProvaReceiver(), new IntentFilter(""));
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            var nextValue = this._random.Next();
            
            this.DataReceived?.Invoke(this,nextValue);
        }
    }

    
    public class ProvaReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            
        }
    }
}
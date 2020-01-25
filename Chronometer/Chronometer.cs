using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chronometer
{
    public class Chronometer : IChronometer
    {
        private long miliSeconds;
        private bool isRunning;
        public Chronometer()
        {
            this.Reset();
            
        }

        public string GetTime { get { return $"{miliSeconds / 60000:D2}:{miliSeconds / 1000:D2}:{miliSeconds % 1000:D2}"; } }

        public List<string> Laps { get; private set; }

        public string Lap()
        {
            string lap = GetTime;
            this.Laps.Add(lap);
            return lap;
           
        }

        public void Reset()
        {
            this.Stop();
            miliSeconds = 0;
            this.Laps = new List<string>();
        }

        public void Start()
        {
            this.isRunning = true;
 
               Task.Run(() =>
          {       while (isRunning)
            {
                Thread.Sleep(1);
                miliSeconds++;
            }
          });
        }

        public void Stop()
        {
            this.isRunning = false;
        }
    }
}

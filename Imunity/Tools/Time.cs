using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Imunity.Tools
{
    public class Time
    {
        private static Stopwatch timer;

        public float loopStartTime;

        public float _loopEndTime;

        public float loopEndTime
        {
            get { return _loopEndTime; }
            set 
            {
                _loopEndTime = value;
                loopTime = _loopEndTime - loopStartTime;
            }
        }

        public static float loopTime { get; private set; }

        public static float now { get { return LongMillisecondsToFloatSecond(timer.ElapsedMilliseconds); } }

        public Time()
        {
            timer = new Stopwatch();
            timer.Start();
        }

        private static float LongMillisecondsToFloatSecond(long milliseconds)
        {
            return Convert.ToSingle(milliseconds)/1000f;
        }
    }
}

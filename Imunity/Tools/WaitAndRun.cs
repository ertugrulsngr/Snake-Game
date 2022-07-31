using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Imunity.Tools
{
    public class WaitAndRun
    {
        public WaitAndRun(float second, Action function)
        {
            Timer _timer = new Timer(second * 1000);
            _timer.Elapsed += (sender, e) => function();
            _timer.AutoReset = false;
            _timer.Enabled = true;
        }
    }
}

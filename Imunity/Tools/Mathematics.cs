using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imunity.Tools
{
    public abstract class Mathematics
    {
        public static int Round(int number, int roundingFactor)
        {
            int remaining = (number % roundingFactor);
            if (remaining >= roundingFactor/2)
            {
                return number+(roundingFactor-remaining);
            }
            else
            {
                return number - remaining;
            }
        }
    }
}

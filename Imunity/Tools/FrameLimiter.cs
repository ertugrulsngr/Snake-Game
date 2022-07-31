using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Imunity.Tools
{
    public class FrameLimiter
    {
        private static float _targetFPS;
        private static float targetLoopTime;


        private Time gameTime;

        public FrameLimiter(Time gameTime)
        {
            this.gameTime = gameTime;
        }

        public static void SetTargetFPS(float targetFPS)
        {
            if (targetFPS < 0)
            {
                return;
            }
            _targetFPS = targetFPS;
            targetLoopTime = 1 / targetFPS;
            
        }


        public void Wait()
        {
            while (!newLoopAllowed) { }
        }

        public bool newLoopAllowed
        {
            get
            {
                if (Time.now - gameTime.loopStartTime >= targetLoopTime)
                {
                    return true;
                }
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imunity.Engine;
namespace Imunity.Tools
{
    public class FrameCounter
    {
        private float countStartTime;
        private float startFrame;

        public void Count()
        {
            if (Time.now - countStartTime >= 1)
            {
                GameEngine.FPS = (int)Math.Round(GameEngine.frameCount - startFrame);
                countStartTime = Time.now;
                startFrame = GameEngine.frameCount;
            }
        }


    }
}

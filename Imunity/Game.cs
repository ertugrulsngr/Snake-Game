using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Imunity.Tools;
using Imunity.Tools.Shapes;
using Imunity.GameScripts;
using Imunity.Engine;
namespace Imunity
{
    public class Game
    {
        // Last visible pixel coordinates
        public static int lastVisibleX;
        public static int lastVisibleY;

        private Text fps = new Text(new Vector2(), 8);
        public static Text scoreText = new Text(new Vector2(270, 585), 12);

        private Snake snake;

        public Game()
        {
            lastVisibleX = (int)GameEngine.windowSize.x - 40;
            lastVisibleY = (int)GameEngine.windowSize.y - 44;
        }

        public void OnLoad()
        {
            FrameLimiter.SetTargetFPS(144);
            
        }

        public void OnStart()
        {
            snake = new Snake();
            scoreText.color = Color.SaddleBrown;
        }

        public void BeforeUpdate()
        {
            fps.text = $"FPS: {GameEngine.FPS}";
            scoreText.text = $"Score: {snake.score}"; 
        }

        public void AfterUpdate()
        {

        }
    }
}

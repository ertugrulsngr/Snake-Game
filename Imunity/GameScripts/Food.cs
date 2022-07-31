using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imunity.Tools;
using Imunity.Tools.Shapes;
using Imunity.Engine;
using System.Drawing;
namespace Imunity.GameScripts
{
    public class Food : GameObject
    {
        private Random random = new Random();
        private FilledRectangle shape;
        public Food()
        {
            shape = new FilledRectangle(this);
            shape.scale = Snake.squareSize;
            shape.color = Color.Red;
            AddShape(shape);
            pose = RandomPose();
        }

        private Vector2 RandomPose()
        {
            float x = Mathematics.Round(random.Next(Game.lastVisibleX-Snake.movedPixel), (int)Snake.movedPixel);
            float y = Mathematics.Round(random.Next(Game.lastVisibleY-Snake.movedPixel), (int)Snake.movedPixel);
            return new Vector2(x, y);
        }

        public override void OnUpdate()
        {
            shape.SetRenderOrder(Shape.renderFirst);

        }
        public void NewPose()
        {
            pose = RandomPose();
        }
    }
}

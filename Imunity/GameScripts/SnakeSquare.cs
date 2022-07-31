using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imunity.Tools;
using Imunity.Tools.Shapes;
namespace Imunity.GameScripts
{
    public class SnakeSquare : GameObject
    {
        public FilledRectangle squareShape;
        public SnakeSquare(Vector2 startPose) : base(startPose)
        {
            squareShape = new FilledRectangle(this);
            squareShape.scale = Snake.squareSize;
        }
    }
}

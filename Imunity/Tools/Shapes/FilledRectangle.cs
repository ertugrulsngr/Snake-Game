using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imunity.Tools.Shapes
{
    public class FilledRectangle : Shape
    {
        public FilledRectangle(GameObject parent) : base(parent) { }

        public FilledRectangle(GameObject parent, Vector2 relativePose, Vector2 scale, Color color) : base(parent, relativePose, scale, color) { }
        public override void RenderShape(Graphics g)
        {
            ShapeRenderer.solidBrush.Color = color;
            g.FillRectangle(ShapeRenderer.solidBrush, pose.x, pose.y, scale.x, scale.y);
        }
    }
}

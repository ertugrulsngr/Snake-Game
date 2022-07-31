using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imunity.Tools;
namespace Imunity.Tools.Shapes
{
    public class Text : Shape
    {
        public Font font;
        public string text;

        public Text(Vector2 startPose, string text="") : base(new GameObject())
        {
            font = new Font(FontFamily.GenericSerif, 12);
            color = Color.Black;
            this.text = text;
            parent.pose = startPose;
        }
        public Text(Vector2 startPose, float size, string text = "") : base(new GameObject())
        {
            font = new Font(FontFamily.GenericSerif, size);
            color = Color.Black;
            this.text = text;
            parent.pose = startPose;
        }

        public override void RenderShape(Graphics g)
        {
            ShapeRenderer.solidBrush.Color = color;
            ShapeRenderer.font = font;
            g.DrawString(text, font, ShapeRenderer.solidBrush, pose.x, pose.y);
        }
    }
}

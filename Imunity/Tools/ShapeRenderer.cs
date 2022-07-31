using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Imunity.Tools.Shapes;
namespace Imunity.Tools
{
    public class ShapeRenderer
    {
        public static SolidBrush solidBrush = new SolidBrush(Color.Black);

        public static Font font = new Font(FontFamily.GenericSerif, 12);

        public static void OnDraw(Graphics g)
        {
            for (int i=0; i < Shape.AllShapes.Count; i++)
            {
                if (Shape.AllShapes[i].visible) { Shape.AllShapes[i].RenderShape(g); }
            }
        }
    }
}

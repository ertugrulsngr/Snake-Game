using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Imunity.Tools.Shapes
{
    public abstract class Shape
    {
        public static int renderFirst { get{ return AllShapes.Count-1; } }
        public static int renderLast { get{ return 0; } }
        public static List<Shape> AllShapes = new List<Shape>();

        public Vector2 scale;

        public Vector2 relativePose;

        public Vector2 pose;

        public Color color;

        public bool visible = true;

        public GameObject parent;

        public Shape(GameObject parent)
        {
            this.parent = parent;
            pose = parent.pose;
            relativePose = new Vector2();
            scale = Vector2.one;
            color = Color.Black;
            AllShapes.Add(this);
            parent.AddShape(this);
        }
        public Shape(GameObject parent, Vector2 relativePose, Vector2 scale, Color color)
        {
            this.parent = parent;
            pose = parent.pose;
            this.relativePose = relativePose;
            this.scale = scale;
            this.color = color;
            AllShapes.Add(this);
            parent.AddShape(this);
        }

        public abstract void RenderShape(Graphics g);

        public void SetRenderOrder(int order)
        {
            AllShapes.Remove(this);
            AllShapes.Insert(order, this);
        }

    }
}

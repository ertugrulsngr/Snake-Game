using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imunity.Tools.Shapes;
namespace Imunity.Tools
{
    public class GameObject
    {
        public static List<GameObject> allGameObjects = new List<GameObject>();
        
        private List<Shape> shapes = new List<Shape>();

        public Vector2 pose = Vector2.one;

        public bool enabled = true;

        public GameObject() { pose = new Vector2(); allGameObjects.Add(this); }

        public GameObject(Vector2 pose) { this.pose = pose; allGameObjects.Add(this); }

        public void AddShape(Shape newShape)
        {
            shapes.Add(newShape);
        }

        public virtual void OnUpdate() { }

        public void Destroy()
        {
            allGameObjects.Remove(this);
            for (int i = 0; i<shapes.Count; i++)
            {
                Shape.AllShapes.Remove(shapes[i]);
            }
        }
    }
}

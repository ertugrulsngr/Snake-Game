using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Imunity.Tools
{
    public class Vector2
    {
        public float x, y;

        public Vector2() { }

        public Vector2(float x, float y) { this.x = x; this.y = y; }

        public static Vector2 up { get { return new Vector2(0, 1); } }
        public static Vector2 down { get { return new Vector2(0, -1); } }
        public static Vector2 right { get { return new Vector2(1, 0); } }
        public static Vector2 left { get { return new Vector2(-1, 0); } }

        public static Vector2 one { get { return new Vector2(1f, 1f); } }
        public static Vector2 zero { get { return new Vector2(0, 0); } }

        public Vector2 Normalize()
        {
            float absX = Math.Abs(x);
            float absY = Math.Abs(y);
            Vector2 normalizedVector = new Vector2();
            if (absX > 0) { normalizedVector.x = x / absX; }
            if (absY > 0) { normalizedVector.y = y / absY; }
            return normalizedVector;
        }

        public static float Distance(Vector2 v1, Vector2 v2)
        {
            return (float)Math.Sqrt(Math.Pow(v1.x - v2.x, 2) + Math.Pow(v1.y - v2.y, 2));
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2 (v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x * v2.x, v1.y * v2.y);
        }
        public static Vector2 operator /(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x / v2.x, v1.y / v2.y);
        }
        public static Vector2 operator *(Vector2 v1, float n)
        {
            return new Vector2(v1.x * n, v1.y * n);
        }
        public static Vector2 operator /(Vector2 v1, float n)
        {
            return new Vector2(v1.x / n, v1.y / n);
        }

        public static bool operator == (Vector2 v1, Vector2 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }

        public static bool operator != (Vector2 v1, Vector2 v2)
        {
            return (v1.x != v2.x || v1.y != v2.y);
        }

        public override string ToString()
        {
            return ($"Vector2(x: {x} , y: {y})");
        }
    }
}

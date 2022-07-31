using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imunity.Tools.Shapes
{
    public class Grid : Shape
    {
        private Pen pen;

        private int numberOfCells;
        private float cellSize;


        public Grid(Color color, int numberOfCells, float cellSize) : base(new GameObject())
        {
            pen = new Pen(new SolidBrush(color));
            this.numberOfCells = numberOfCells;
            this.cellSize = cellSize;
        }

        public override void RenderShape (Graphics g)
        {
            for (int i = 0; i < numberOfCells; i++)
            {
                // Vertical
                g.DrawLine(pen, i * cellSize, 0, i * cellSize, numberOfCells * cellSize);

                // Horizontal
                g.DrawLine(pen, 0, i * cellSize, numberOfCells * cellSize, i * cellSize);
            }
        }
    }
}

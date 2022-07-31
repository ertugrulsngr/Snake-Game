using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Imunity.Tools
{
    public class    Canvas : Form
    {
        public Canvas(Vector2 size) 
        {
            //DoubleBuffered = true;
            this.SetStyle(ControlStyles.DoubleBuffer |
               ControlStyles.UserPaint |
               ControlStyles.AllPaintingInWmPaint,
               true);
            this.UpdateStyles();

            Size = new Size((int)size.x, (int)size.y);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.LightSkyBlue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Imunity.Tools
{
    public class Input
    {
        public static bool upArrowPressed;
        public static bool downArrowPressed;
        public static bool leftArrowPressed;
        public static bool rightArrowPressed;

        public static void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { upArrowPressed = true; }
            if (e.KeyCode== Keys.Down) { downArrowPressed = true; }
            if (e.KeyCode == Keys.Left) { leftArrowPressed = true; }
            if (e.KeyCode == Keys.Right) { rightArrowPressed = true; }
        }

        public static void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up) { upArrowPressed = false; }
            if (e.KeyCode == Keys.Down) { downArrowPressed = false; }
            if (e.KeyCode == Keys.Left) { leftArrowPressed = false; }
            if (e.KeyCode == Keys.Right) { rightArrowPressed = false; }
        }
    }
}

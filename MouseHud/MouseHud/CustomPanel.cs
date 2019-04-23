using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace MouseHud
{
    class CustomPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.Green, ButtonBorderStyle.Solid);

        }

    }
}

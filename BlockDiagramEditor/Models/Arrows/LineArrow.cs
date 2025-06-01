using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockDiagramEditor.Services;
using System.Windows.Forms;

namespace BlockDiagramEditor.Models.Arrows
{
    public class LineArrow : Arrow
    {
        public LineArrow(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            base.Draw(e, tr);
        }
    }
}
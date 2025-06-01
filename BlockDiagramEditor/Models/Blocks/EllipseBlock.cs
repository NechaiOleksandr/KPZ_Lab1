using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Services;

namespace BlockDiagramEditor.Models
{
    public class EllipseBlock : Block
    {
        public EllipseBlock() : base() { }

        public EllipseBlock(float x, float y, int id) : base(x, y, id) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            float sx = tr.CTSX(X);
            float sy = tr.CTSY(Y);
            float sw = tr.CTSS(Width);
            float sh = tr.CTSS(Height);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brush, sx, sy, sw, sh);
            e.Graphics.DrawEllipse(new Pen(Border.Color, tr.CTSS(Border.Width)), sx, sy, sw, sh);
            base.Draw(e, tr);
        }
    }
}

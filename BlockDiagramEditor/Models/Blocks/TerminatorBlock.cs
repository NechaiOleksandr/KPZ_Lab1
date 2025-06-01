using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Services;

namespace BlockDiagramEditor.Models
{
    public class TerminatorBlock : Block
    {
        public TerminatorBlock() : base() { }

        public TerminatorBlock(float x, float y, int id) : base(x, y, id) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            float sx = tr.CTSX(X);
            float sy = tr.CTSY(Y);
            float sw = tr.CTSS(Width);
            float sh = tr.CTSS(Height);

            GraphicsPath path = new GraphicsPath();
            path.AddArc(sx, sy, sh, sh, 90, 180);
            path.AddArc(sx + sw - sh, sy, sh, sh, 270, 180);
            path.CloseFigure();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(Brushes.White, path);
            e.Graphics.DrawPath(new Pen(Border.Color, tr.CTSS(Border.Width)), path);
            base.Draw(e, tr);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Services;

namespace BlockDiagramEditor.Models
{
    public class ParalelogramBlock : Block
    {
        public ParalelogramBlock(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            float sx = tr.CTSX(X);
            float sy = tr.CTSY(Y);
            float sw = tr.CTSS(Width);
            float sh = tr.CTSS(Height);

            GraphicsPath path = new GraphicsPath();
            PointF[] points =
            {
                new PointF(sx, sy + sh),
                new PointF(sx + sw / 8, sy),
                new PointF(sx + sw, sy),
                new PointF(sx + sw - sw / 8, sy + sh)
            };
            path.AddLines(points);
            path.CloseFigure();
            e.Graphics.FillPath(Brush, path);
            e.Graphics.DrawPath(new Pen(Border.Color, tr.CTSS(Border.Width)), path);
            base.Draw(e, tr);
        }
    }
}
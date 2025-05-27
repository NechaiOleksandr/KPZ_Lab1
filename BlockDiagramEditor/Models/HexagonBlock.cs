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
    public class HexagonBlock : Block
    {
        public HexagonBlock(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            float sx = tr.CTSX(X);
            float sy = tr.CTSY(Y);
            float sw = tr.CTSS(Width);
            float sh = tr.CTSS(Height);

            GraphicsPath path = new GraphicsPath();
            PointF[] points =
            {
                new PointF(sx + sw / 8, sy),
                new PointF(sx + sw - sw / 8, sy),
                new PointF(sx + sw, sy + sh / 2),
                new PointF(sx + sw - sw / 8, sy + sh),
                new PointF(sx + sw / 8, sy + sh),
                new PointF(sx, sy + sh / 2)
            };
            path.AddLines(points);
            path.CloseFigure();
            e.Graphics.FillPath(Brushes.White, path);
            e.Graphics.DrawPath(IsSelected ? new Pen(Color.Black, tr.CTSS(5)) : new Pen(Border.Color, tr.CTSS(Border.Width)), path);
            base.Draw(e, tr);
        }

        public override bool Contains(float x, float y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

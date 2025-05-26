using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagramEditor.Models
{
    public class ParalelogramBlock : Block
    {
        public ParalelogramBlock(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, float scale, PointF offset)
        {
            float sx = X * scale + offset.X;
            float sy = Y * scale + offset.Y;
            float sw = Width * scale;
            float sh = Height * scale;

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
            e.Graphics.FillPath(Brushes.White, path);
            e.Graphics.DrawPath(IsSelected ? new Pen(Color.Black, 5 * scale) : new Pen(Border.Color, Border.Width * scale), path);
            base.Draw(e, scale, offset);
        }

        public override bool Contains(float x, float y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

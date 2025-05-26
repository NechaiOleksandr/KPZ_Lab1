using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagramEditor.Models
{
    public class TerminatorBlock : Block
    {
        public TerminatorBlock(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, float scale, PointF offset)
        {
            float sx = X * scale + offset.X;
            float sy = Y * scale + offset.Y;
            float sw = Width * scale;
            float sh = Height * scale;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(sx, sy, sh, sh, 90, 180);
            path.AddArc(sx + sw - sh, sy, sh, sh, 270, 180);
            path.CloseFigure();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
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

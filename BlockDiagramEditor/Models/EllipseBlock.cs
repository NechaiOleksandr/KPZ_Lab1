using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagramEditor.Models
{
    public class EllipseBlock : Block
    {
        public EllipseBlock(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, float scale, PointF offset)
        {
            float sx = X * scale + offset.X;
            float sy = Y * scale + offset.Y;
            float sw = Width * scale;
            float sh = Height * scale;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.White, sx, sy, sw, sh);
            e.Graphics.DrawEllipse(IsSelected ? new Pen(Color.Black, 5 * scale) : new Pen(Border.Color, Border.Width * scale), sx, sy, sw, sh);
            base.Draw(e, scale, offset);
        }

        public override bool Contains(float x, float y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

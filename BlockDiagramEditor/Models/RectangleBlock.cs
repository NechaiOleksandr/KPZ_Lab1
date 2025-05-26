using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Services;

namespace BlockDiagramEditor.Models
{
    public class RectangleBlock : Block
    {
        public RectangleBlock(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, float scale, PointF offset)
        {
            float sx = X * scale + offset.X;
            float sy = Y * scale + offset.Y;
            float sw = Width * scale;
            float sh = Height * scale;

            e.Graphics.FillRectangle(Brushes.White,sx, sy, sw, sh);
            e.Graphics.DrawRectangle(IsSelected ? new Pen(Color.Black, 5 * scale) : new Pen(Border.Color, Border.Width * scale), sx, sy, sw, sh);
            base.Draw(e, scale, offset);
        }

        public override bool Contains(float x, float y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

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
        public EllipseBlock(int x, int y) : base(x, y) { }

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(Brushes.White, X, Y, Width, Height);
            e.Graphics.DrawEllipse(Pens.Black, X, Y, Width, Height);
            base.Draw(e);
        }

        public override bool Contains(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

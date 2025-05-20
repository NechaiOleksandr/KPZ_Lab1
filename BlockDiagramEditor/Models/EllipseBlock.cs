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
        public EllipseBlock() : base() { }

        public EllipseBlock(int x, int y) : base(x, y) { }

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(Pens.Black, X, Y, Width, Height);
        }

        public override bool Contains(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

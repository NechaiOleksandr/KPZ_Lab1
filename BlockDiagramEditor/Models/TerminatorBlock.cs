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
        public TerminatorBlock(int x, int y) : base(x, y) { }

        public override void Draw(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(X, Y, Height, Height, 90, 180);
            path.AddArc(X + Width - Height, Y, Height, Height, 270, 180);
            path.CloseFigure();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(Brushes.White, path);
            e.Graphics.DrawPath(Pens.Black, path);
            base.Draw(e);
        }

        public override bool Contains(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

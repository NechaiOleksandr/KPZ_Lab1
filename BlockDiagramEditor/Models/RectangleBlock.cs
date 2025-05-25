using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagramEditor.Models
{
    public class RectangleBlock : Block
    {
        public RectangleBlock(int x, int y) : base(x, y) { }

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, X, Y, Width, Height);
            e.Graphics.DrawRectangle(Pens.Black, X, Y, Width, Height);
            base.Draw(e);
        }

        public override bool Contains(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

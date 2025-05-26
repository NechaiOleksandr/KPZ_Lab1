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
    public class HexagonBlock : Block
    {
        public HexagonBlock(int x, int y) : base(x, y) { }

        public override void Draw(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            Point[] points =
            {
                new Point(X + Width / 8, Y),
                new Point(X + Width - Width / 8, Y),
                new Point(X + Width, Y + Height / 2),
                new Point(X + Width - Width / 8, Y + Height),
                new Point(X + Width / 8, Y + Height),
                new Point(X, Y + Height / 2)
            };
            path.AddLines(points);
            path.CloseFigure();
            e.Graphics.FillPath(Brushes.White, path);
            e.Graphics.DrawPath(IsSelected ? new Pen(Color.Black, 5) : Border, path);
            base.Draw(e);
        }

        public override bool Contains(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}

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
        public RectangleBlock() : base() { }

        public RectangleBlock(float x, float y, int id) : base(x, y, id) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            float sx = tr.CTSX(X);
            float sy = tr.CTSY(Y);
            float sw = tr.CTSS(Width);
            float sh = tr.CTSS(Height);

            e.Graphics.FillRectangle(Brush, sx, sy, sw, sh);
            e.Graphics.DrawRectangle(new Pen(Border.Color, tr.CTSS(Border.Width)), sx, sy, sw, sh);
            base.Draw(e, tr);
        }
    }
}
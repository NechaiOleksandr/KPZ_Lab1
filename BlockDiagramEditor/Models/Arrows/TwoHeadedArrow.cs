using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockDiagramEditor.Services;
using System.Windows.Forms;

namespace BlockDiagramEditor.Models.Arrows
{
    public class TwoHeadedArrow : Arrow
    {
        public TwoHeadedArrow() : base() { }
        public TwoHeadedArrow(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            PointF[] head = CalculateHead(tr.CTSP(Points[Points.Count - 2]), tr.CTSP(Points[Points.Count - 1]), tr);
            e.Graphics.DrawLines(new Pen(Pen.Color, tr.CTSS(Pen.Width)), head);
            head = CalculateHead(tr.CTSP(Points[1]), tr.CTSP(Points[0]), tr);
            e.Graphics.DrawLines(new Pen(Pen.Color, tr.CTSS(Pen.Width)), head);
            base.Draw(e, tr);
        }
    }
}
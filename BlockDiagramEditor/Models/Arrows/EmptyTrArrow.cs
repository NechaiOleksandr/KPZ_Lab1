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
    public class EmptyTrArrow : Arrow
    {
        public EmptyTrArrow(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            PointF[] head = new PointF[5];
            PointF[] headBase = CalculateHead(tr.CTSP(Points[Points.Count - 2]), tr.CTSP(Points[Points.Count - 1]), tr);
            Array.Copy(headBase, 0, head, 0, headBase.Length);
            head[3] = head[0];
            head[4] = head[1];

            e.Graphics.DrawLines(new Pen(Pen.Color, tr.CTSS(Pen.Width)), head);

            base.Draw(e, tr);
        }
    }
}
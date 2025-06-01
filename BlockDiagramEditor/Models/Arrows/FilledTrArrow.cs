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
    public class FilledTrArrow : Arrow
    {
        public FilledTrArrow() : base() { }
        public FilledTrArrow(float x, float y) : base(x, y) { }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            PointF[] head = new PointF[5];
            PointF[] headBase = CalculateHead(tr.CTSP(Points[Points.Count - 2]), tr.CTSP(Points[Points.Count - 1]), tr);
            Array.Copy(headBase, 0, head, 0, headBase.Length);
            head[3] = head[0];
            head[4] = head[1];

            e.Graphics.DrawLines(new Pen(Pen.Color, tr.CTSS(Pen.Width)), head);
            GraphicsPath path = new GraphicsPath();
            path.AddLines(headBase);
            path.CloseFigure();
            e.Graphics.FillPath(new SolidBrush(Pen.Color), path);
            base.Draw(e, tr);
        }
    }
}
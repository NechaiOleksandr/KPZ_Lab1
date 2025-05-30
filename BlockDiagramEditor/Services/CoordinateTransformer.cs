using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDiagramEditor.Services
{
    public class CoordinateTransformer
    {
        public float Scale { get; set; } = 1;
        public PointF CanvasOffset { get; set; }

        public void ChangeScale(int delta)
        {
            if (delta < 0 && Scale > 0.11)
            {
                Scale -= 0.1F;
                Scale = (float)Math.Round(Scale, 1);
            }
            else if (delta > 0 && Scale < 5)
            {
                Scale += 0.1F;
                Scale = (float)Math.Round(Scale, 1);
            }
        }

        public float STCX(float x) //ScreenToCanvasX
        {
            return (x - CanvasOffset.X) / Scale;
        }

        public float STCY(float y) //ScreenToCanvasY
        {
            return (y - CanvasOffset.Y) / Scale;
        }

        public PointF STCP(PointF point)
        {
            return new PointF((point.X - CanvasOffset.X) / Scale, (point.Y - CanvasOffset.Y) / Scale);
        }

        public float CTSX(float x) //CanvasToScreenX
        {
            return x * Scale + CanvasOffset.X;
        }

        public float CTSY(float y) //CanvasToScreenY
        {
            return y * Scale + CanvasOffset.Y;
        }

        public PointF CTSP(PointF point)
        {
            return new PointF(point.X * Scale + CanvasOffset.X, point.Y * Scale + CanvasOffset.Y);
        }

        public float CTSS(float s) // ScrenToCanvasSize
        {
            return s * Scale;
        }
    }
}

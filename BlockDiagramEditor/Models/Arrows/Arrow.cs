using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockDiagramEditor.Services;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Net;

namespace BlockDiagramEditor.Models.Arrows
{
    public class Arrow
    {
        public float StartX;
        public float StartY;
        public float EndX;
        public float EndY;
        public Pen Pen;
        public bool IsSelected;

        public Arrow(float x, float y)
        {
            StartX = x;
            StartY = y;
            EndX = x + 100;
            EndY = y + 100;
            Pen = new Pen(Color.Black, 2);
            IsSelected = false;
        }

        public virtual void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            float ssx = tr.CTSX(StartX);
            float ssy = tr.CTSY(StartY);
            float esx = tr.CTSX(EndX);
            float esy = tr.CTSY(EndY);

            e.Graphics.DrawLine(new Pen(Pen.Color, tr.CTSS(Pen.Width)), ssx, ssy, esx, esy);
            PointF[] head = CalculateHead(ssx, ssy, esx, esy, tr);
            e.Graphics.DrawLines(new Pen(Pen.Color, tr.CTSS(Pen.Width)), head);

            if (IsSelected)
            {
                e.Graphics.FillRectangle(Brushes.Black, ssx - 5, ssy - 5, 10, 10);
                e.Graphics.FillRectangle(Brushes.Black, esx - 5, esy - 5, 10, 10);
            }
        }
        public static PointF[] CalculateHead(float fromX, float fromY, float toX, float toY, CoordinateTransformer tr)
        {
            float headSize = tr.CTSS(10);

            float dx = toX - fromX;
            float dy = toY - fromY;

            float length = (float)Math.Sqrt(dx * dx + dy * dy);
            if (length > 0)
            {
                dx /= length;
                dy /= length;
            }

            float perpX = -dy;
            float perpY = dx;

            return new PointF[]
            {
                new PointF(toX - dx * headSize + perpX * headSize, toY - dy * headSize + perpY * headSize),
                new PointF(toX, toY),
                new PointF(toX - dx * headSize - perpX * headSize, toY - dy * headSize - perpY * headSize)
            };
        }

        public bool Contains(float x, float y)
        {
            float dx = EndX - StartX;
            float dy = EndY - StartY;

            float length = (float)Math.Sqrt(dx * dx + dy * dy);
            if (length > 0)
            {
                dx /= length;
                dy /= length;
            }

            float perpX = -dy;
            float perpY = dx;

            float vx = x - StartX;
            float vy = y - StartY;

            float t = vx * dx + vy * dy;

            float dist = Math.Abs(vx * perpX + vy * perpY);

            return t >= -10 && t <= length && dist <= 10;
        }

        public int GetHandleAt(Point screenPoint, CoordinateTransformer tr)
        {
            float ssx = tr.CTSX(StartX);
            float ssy = tr.CTSY(StartY);
            float esx = tr.CTSX(EndX);
            float esy = tr.CTSY(EndY);

            RectangleF startHandle = new RectangleF(ssx - 5, ssy - 5, 10, 10);
            RectangleF endHandle = new RectangleF(esx - 5, esy - 5, 10, 10);

            if (startHandle.Contains(screenPoint))
                return 0;
            if (endHandle.Contains(screenPoint))
                return 1;

            return -1;
        }
    }
}

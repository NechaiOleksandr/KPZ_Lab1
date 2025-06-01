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
using System.Security.Cryptography.X509Certificates;

namespace BlockDiagramEditor.Models.Arrows
{
    public abstract class Arrow
    {
        public string Type => GetType().Name;
        public List<PointF> Points;
        public List<(Block Block, int Side)> Bracing;
        public Pen Pen;
        public bool IsSelected;

        public Arrow(float x, float y)
        {
            Points = new List<PointF>
            {
                new PointF(x, y),
                new PointF(x + 100, y + 100),
            };
            Bracing = new List<(Block Block, int Side)>
            {
                (null, 0),
                (null, 0),
            };
            Pen = new Pen(Color.Black, 2);
            IsSelected = false;
        }

        public virtual void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            Pen sPen = new Pen(Pen.Color, tr.CTSS(Pen.Width));
            for (int i = 0; i < Points.Count - 1; i++)
            {
                e.Graphics.DrawLine(sPen, tr.CTSP(Points[i]), tr.CTSP(Points[i + 1]));
            }

            if (IsSelected)
            {
                for (int i = 0; i < Points.Count; i++)
                {
                    e.Graphics.FillEllipse(Brushes.Black, tr.CTSX(Points[i].X) - 5, tr.CTSY(Points[i].Y) - 5, 10, 10);
                    e.Graphics.FillEllipse(Brushes.White, tr.CTSX(Points[i].X) - 3, tr.CTSY(Points[i].Y) - 3, 6, 6);
                }
                for (int i = 0; i < Points.Count - 1; i++)
                {
                    e.Graphics.FillEllipse(Brushes.Black, tr.CTSX((Points[i].X + Points[i + 1].X) / 2) - 5, tr.CTSY((Points[i].Y + Points[i + 1].Y) / 2) - 5, 10, 10);
                    e.Graphics.FillEllipse(Brushes.Gray, tr.CTSX((Points[i].X + Points[i + 1].X) / 2) - 3, tr.CTSY((Points[i].Y + Points[i + 1].Y) / 2) - 3, 6, 6);
                }
                if (Bracing[0] != (null, 0))
                {
                    e.Graphics.FillEllipse(Brushes.Black, tr.CTSX(Points[0].X) - 5, tr.CTSY(Points[0].Y) - 5, 10, 10);
                    e.Graphics.FillEllipse(Brushes.LimeGreen, tr.CTSX(Points[0].X) - 3, tr.CTSY(Points[0].Y) - 3, 6, 6);
                }
                if (Bracing[1] != (null, 0))
                {
                    e.Graphics.FillEllipse(Brushes.Black, tr.CTSX(Points.Last().X) - 5, tr.CTSY(Points.Last().Y) - 5, 10, 10);
                    e.Graphics.FillEllipse(Brushes.LimeGreen, tr.CTSX(Points.Last().X) - 3, tr.CTSY(Points.Last().Y) - 3, 6, 6);
                }
            }
        }

        public static PointF[] CalculateHead(PointF from, PointF to, CoordinateTransformer tr)
        {
            float headSize = tr.CTSS(10);

            PointF v = new PointF(to.X - from.X, to.Y - from.Y);

            float l = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
            if (l > 0)
            {
                v.X /= l;
                v.Y /= l;
            }

            PointF perpV = new PointF(-v.Y, v.X);

            return new PointF[]
            {
                new PointF(to.X - v.X * headSize + perpV.X * headSize, to.Y - v.Y * headSize + perpV.Y * headSize),
                new PointF(to.X, to.Y),
                new PointF(to.X - v.X * headSize - perpV.X * headSize, to.Y - v.Y * headSize - perpV.Y * headSize)
            };
        }

        public bool Contains(float x, float y)
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                PointF v = new PointF(Points[i + 1].X - Points[i].X, Points[i + 1].Y - Points[i].Y);

                float l = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y);
                if (l > 0)
                {
                    v.X /= l;
                    v.Y /= l;
                }

                PointF perpV = new PointF(-v.Y, v.X);

                float vx = x - Points[i].X;
                float vy = y - Points[i].Y;

                float t = vx * v.X + vy * v.Y;

                float dist = Math.Abs(vx * perpV.X + vy * perpV.Y);

                if (t >= -10 && t <= l && dist <= 10)
                    return true;
            }
            return false;
        }

        public int GetHandleAt(Point screenPoint, CoordinateTransformer tr)
        {
            RectangleF Handle = new RectangleF();
            for (int i = 0; i < Points.Count; i++)
            {
                Handle = new RectangleF(tr.CTSX(Points[i].X) - 5, tr.CTSY(Points[i].Y) - 5, 10, 10);

                if (Handle.Contains(screenPoint))
                    return i;
            }
            return -1;
        }

        public void AddPoint(Point ScreenPoint, CoordinateTransformer tr)
        {
            RectangleF Handle = new RectangleF();
            for (int i = 0; i < Points.Count - 1; i++)
            {
                PointF newPoint = new PointF(
                    (Points[i].X + Points[i + 1].X) / 2, (Points[i].Y + Points[i + 1].Y) / 2);
                Handle = new RectangleF(tr.CTSX(newPoint.X) - 5, tr.CTSY(newPoint.Y) - 5, 10, 10);

                if (Handle.Contains(ScreenPoint))
                {
                    Points.Insert(i + 1, newPoint);
                    return;
                }
            }
        }

        public bool RebuildArrow()
        {
            for (int i = 0; i < Points.Count - 1; i++)
            {
                if (Points[i] == Points[i + 1])
                {
                    if (Points.Count != 2)
                    {
                        Points.Remove(Points[i]);
                        return false;
                    }
                    else
                        return true;
                }
            }
            return false;
        }
    }
}

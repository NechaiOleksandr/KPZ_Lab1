using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Services;

namespace BlockDiagramEditor.Models
{
    public abstract class Block
    {
        public string Type => GetType().Name;
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Text { get; set; }
        public Font Font { get; set; }
        public SolidBrush TextColor { get; set; }
        public RectangleF TextArea { get; set; }
        public Pen Border {  get; set; }
        public SolidBrush Brush { get; set; }
        public bool IsSelected { get; set; }
        public bool IsFound {  get; set; }
        public int Id { get; set; }

        public Block()
        {
            X = 0;
            Y = 0;
            Width = 160;
            Height = 80;
            Text = string.Empty;
            Font = new Font("Microsoft YaHei UI", 12);
            Border = new Pen(Color.Black, 2);
            Brush = new SolidBrush(Color.White);
            TextColor = new SolidBrush(Color.Black);
            IsSelected = false;
            Id = -1;
        }

        public Block(float x, float y, int id)
        {
            X = x;
            Y = y;
            Width = 160;
            Height = 80;
            Text = string.Empty;
            Font = new Font("Microsoft YaHei UI", 12);
            Border = new Pen(Color.Black, 2);
            Brush = new SolidBrush(Color.White);
            TextColor = new SolidBrush(Color.Black);
            IsSelected = false;
            Id = id;
        }

        public virtual void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            TextArea = new RectangleF(tr.CTSX(X + 5), tr.CTSY(Y + 5), tr.CTSS(Width - 10), tr.CTSS(Height - 10));
            StringFormat Format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(Text, new Font(Font.FontFamily, tr.CTSS(Font.Size)), TextColor, TextArea, Format);

            if (IsFound)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Green, 3), tr.CTSX(X - 5), tr.CTSY(Y - 5), tr.CTSS(Width + 10), tr.CTSS(Height + 10));
            }

            if (IsSelected)
            {
                float sx = tr.CTSX(X);
                float sy = tr.CTSY(Y);
                float sw = tr.CTSS(Width);
                float sh = tr.CTSS(Height);

                e.Graphics.DrawRectangle(new Pen(Color.Black, 1)
                {
                    DashStyle = DashStyle.Custom,
                    DashPattern = new float[] { 5, 3 }
                },
                sx - 5, sy - 5, sw + 10, sh + 10);

                e.Graphics.FillRectangle(Brushes.Black, sx - 10, sy - 10, 10, 10);
                e.Graphics.FillRectangle(Brushes.White, sx - 8, sy - 8, 6, 6);
                e.Graphics.FillRectangle(Brushes.Black, sx + sw / 2 - 5, sy - 10, 10, 10);
                e.Graphics.FillRectangle(Brushes.White, sx + sw / 2 - 3, sy - 8, 6, 6);
                e.Graphics.FillRectangle(Brushes.Black, sx + sw, sy + sh, 10, 10);
                e.Graphics.FillRectangle(Brushes.White, sx + sw + 2, sy + sh + 2, 6, 6);
                e.Graphics.FillRectangle(Brushes.Black, sx + sw, sy + sh / 2 - 5, 10, 10);
                e.Graphics.FillRectangle(Brushes.White, sx + sw + 2, sy + sh / 2 - 3, 6, 6);
                e.Graphics.FillRectangle(Brushes.Black, sx + sw, sy - 10, 10, 10);
                e.Graphics.FillRectangle(Brushes.White, sx + sw + 2, sy - 8, 6, 6);
                e.Graphics.FillRectangle(Brushes.Black, sx + sw / 2 - 5, sy + sh, 10, 10);
                e.Graphics.FillRectangle(Brushes.White, sx + sw / 2 - 3, sy + sh + 2, 6, 6);
                e.Graphics.FillRectangle(Brushes.Black, sx - 10, sy + sh, 10, 10);
                e.Graphics.FillRectangle(Brushes.White, sx - 8, sy + sh + 2, 6, 6);
                e.Graphics.FillRectangle(Brushes.Black, sx - 10, sy + sh / 2 - 5, 10, 10);
                e.Graphics.FillRectangle(Brushes.White, sx - 8, sy + sh / 2 - 3, 6, 6);
            }
        }

        public bool Contains(float x, float y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }

        public ResizeHandle GetResizeHandleAt(Point screenPoint, CoordinateTransformer tr)
        {
            float sx = tr.CTSX(X);
            float sy = tr.CTSY(Y);
            float sw = tr.CTSS(Width);
            float sh = tr.CTSS(Height);

            Dictionary<ResizeHandle, RectangleF> handles = new Dictionary<ResizeHandle, RectangleF>
            {
                { ResizeHandle.TopLeft, new RectangleF(sx - 10, sy - 10, 10, 10) },
                { ResizeHandle.TopCenter, new RectangleF(sx + sw / 2 - 5, sy - 10, 10, 10) },
                { ResizeHandle.TopRight, new RectangleF(sx + sw, sy - 10, 10, 10) },
                { ResizeHandle.RightCenter, new RectangleF(sx + sw, sy + sh / 2 - 5, 10, 10) },
                { ResizeHandle.BottomRight, new RectangleF(sx + sw, sy + sh, 10, 10) },
                { ResizeHandle.BottomCenter, new RectangleF(sx + sw / 2 - 5, sy + sh, 10, 10) },
                { ResizeHandle.BottomLeft, new RectangleF(sx - 10, sy + sh, 10, 10) },
                { ResizeHandle.LeftCenter, new RectangleF(sx - 10, sy + sh / 2 - 5, 10, 10) }
            };

            foreach (var handle in handles)
            {
                if (handle.Value.Contains(screenPoint))
                    return handle.Key;
            }

            return ResizeHandle.None;
        }
    }
}

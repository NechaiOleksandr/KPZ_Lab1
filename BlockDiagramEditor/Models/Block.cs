using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Services;

namespace BlockDiagramEditor.Models
{
    public abstract class Block
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Text { get; set; }
        public Font Font { get; set; }
        public RectangleF TextArea { get; set; }
        public Pen Border {  get; set; }
        public Brush Brush { get; set; }
        public bool IsSelected { get; set; }

        public Block(float x, float y)
        {
            X = x;
            Y = y;
            Width = 160;
            Height = 80;
            Text = string.Empty;
            Font = new Font("consolas", 12);
            Border = new Pen(Color.Black, 1);
            IsSelected = false;
        }

        public virtual void Draw(PaintEventArgs e, float scale, PointF offset)
        {
            PointF location = new PointF(X, Y);
            TextArea = new RectangleF((X + 5) * scale + offset.X, (Y + 5) * scale + offset.Y, (Width - 10) * scale, (Height - 10) * scale);
            StringFormat Format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(Text, new Font(Font.FontFamily, Font.Size * scale), Brushes.Black, TextArea, Format);
        }

        public abstract bool Contains(float x, float y);
    }
}

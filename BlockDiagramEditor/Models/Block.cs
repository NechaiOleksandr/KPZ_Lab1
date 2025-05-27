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

        public virtual void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {

            PointF location = new PointF(X, Y);
            TextArea = new RectangleF(tr.CTSX(X + 5), tr.CTSY(Y + 5), tr.CTSS(Width - 10), tr.CTSS(Height - 10));
            StringFormat Format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(Text, new Font(Font.FontFamily, tr.CTSS(Font.Size)), Brushes.Black, TextArea, Format);
        }

        public abstract bool Contains(float x, float y);
    }
}

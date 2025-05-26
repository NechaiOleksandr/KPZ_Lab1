using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagramEditor.Models
{
    public abstract class Block
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Text { get; set; }
        public Font Font { get; set; }
        public Rectangle TextArea { get; set; }
        public Pen Border {  get; set; }
        public Brush Brush { get; set; }
        public bool IsSelected { get; set; }

        public Block(int x, int y)
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

        public virtual void Draw(PaintEventArgs e)
        {
            TextArea = new Rectangle(X + 5, Y + 5, Width - 10, Height - 10);
            StringFormat Format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(Text, Font, Brushes.Black, TextArea, Format);
        }
        public abstract bool Contains(int x, int y);
    }
}

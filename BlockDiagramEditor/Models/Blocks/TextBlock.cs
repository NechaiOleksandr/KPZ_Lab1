using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Services;
using static System.Net.Mime.MediaTypeNames;

namespace BlockDiagramEditor.Models
{
    public class TextBlock : Block
    {
        public TextBlock() : base() { }

        public TextBlock(float x, float y, int id) : base(x, y, id) {
            Width = 70;
            Height = 30;
            Text = "Текст";
        }

        public override void Draw(PaintEventArgs e, CoordinateTransformer tr)
        {
            TextArea = new RectangleF(tr.CTSX(X), tr.CTSY(Y), tr.CTSS(Width), tr.CTSS(Height));
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
            }
        }

        public void ResizeByText()
        {
            SizeF newSize = TextRenderer.MeasureText(Text, Font);
            Width = newSize.Width + newSize.Width % 10;
            Height = newSize.Height + newSize.Height % 10;
        }
    }
}
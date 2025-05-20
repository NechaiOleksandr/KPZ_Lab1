using System;
using System.Collections.Generic;
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

        public Block()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
        }

        public Block(int x, int y)
        {
            X = x;
            Y = y;
            Width = 160;
            Height = 80;
        }

        public abstract void Draw(PaintEventArgs e);
        public abstract bool Contains(int x, int y);
    }
}

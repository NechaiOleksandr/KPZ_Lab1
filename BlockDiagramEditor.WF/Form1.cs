using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor;
using BlockDiagramEditor.Models;

namespace BlockDiagramEditor.WF
{
    public partial class Form1 : Form
    {
        private List<Block> blocks = new List<Block>();
        private Block currentBlock;
        private int selectedModel;
        private Block selectedBlock;
        private bool isDragging = false;
        private Point offset;

        public Form1()
        {
            InitializeComponent();
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var block in blocks) block.Draw(e);
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            selectedBlock = blocks.LastOrDefault(block => block.Contains(e.X, e.Y));
            if (selectedBlock != null)
            {
                isDragging = true;
                offset = new Point(e.X - selectedBlock.X, e.Y - selectedBlock.Y);
                return;
            }
            int x = (e.X - 80) - (e.X - 80) % 10;
            int y = (e.Y - 40) - (e.Y - 40) % 10;
            if (selectedModel == 0) currentBlock = new RectangleBlock(x, y);
            else if (selectedModel == 1) currentBlock = new EllipseBlock(x, y);
            else if (selectedModel == 2) currentBlock = new TerminatorBlock(x, y);
            else if (selectedModel == 3) currentBlock = new ParalelogramBlock(x, y);
            else if (selectedModel == 4) currentBlock = new DiamondBlock(x, y);
            else if (selectedModel == 5) currentBlock = new HexagonBlock(x, y);
            
            blocks.Add(currentBlock);
            panelCanvas.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedModel = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedModel = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedModel = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedModel = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            selectedModel = 4;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            selectedModel = 5;
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                selectedBlock.X = (e.X - offset.X) - (e.X - offset.X) % 10;
                selectedBlock.Y = (e.Y - offset.Y) - (e.Y - offset.Y) % 10;
                panelCanvas.Invalidate();
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            selectedBlock = null;
        }
    }
}

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
using BlockDiagramEditor.Services;

namespace BlockDiagramEditor.WF
{
    public partial class Form1 : Form
    {
        private List<Block> blocks = new List<Block>();
        private Block currentBlock = null;
        private int selectedModel;
        private Block selectedBlock = null;
        private Block editingBlock = null;
        private bool isDragging = false;
        private Point offset;
        private TextBox editText = null;

        //private BlockManager BlockManager = new BlockManager();

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
            int x = (e.X - 80) - (e.X - 80) % 10;
            int y = (e.Y - 40) - (e.Y - 40) % 10;

            switch (selectedModel)
            {
                case 1: currentBlock = new TerminatorBlock(x, y); break;
                case 2: currentBlock = new ParalelogramBlock(x, y); break;
                case 3: currentBlock = new RectangleBlock(x, y); break;
                case 4: currentBlock = new DiamondBlock(x, y); break;
                case 5: currentBlock = new HexagonBlock(x, y); break;
                case 6: currentBlock = new EllipseBlock(x, y); break;
            }

            if (currentBlock != null) blocks.Add(currentBlock);
            selectedModel = 0;

            //BlockManager.AddBlock(selectedModel, x, y);

            selectedBlock = blocks.LastOrDefault(block => block.Contains(e.X, e.Y));
            if (selectedBlock != null && selectedModel == 0)
            {
                isDragging = true;
                offset = new Point(e.X - selectedBlock.X, e.Y - selectedBlock.Y);
            }

            if (editText != null && editingBlock != null)
            {
                editingBlock.Text = editText.Text;
                panelCanvas.Controls.Remove(editText);
                editingBlock = null;
                editText = null;
            }
            panelCanvas.Invalidate();
        }

        private void btnSelectTerminator_Click(object sender, EventArgs e)
        {
            selectedModel = 1;
            ActiveControl = null;
        }

        private void btnSelectParalelogram_Click(object sender, EventArgs e)
        {
            selectedModel = 2;
            ActiveControl = null;
        }

        private void btnSelectRectangle_Click(object sender, EventArgs e)
        {
            selectedModel = 3;
            ActiveControl = null;
        }

        private void btnSelectDiamond_Click(object sender, EventArgs e)
        {
            selectedModel = 4;
            ActiveControl = null;
        }

        private void btnSelectHexagon_Click(object sender, EventArgs e)
        {
            selectedModel = 5;
            ActiveControl = null;
        }

        private void btnSelectEllipse_Click(object sender, EventArgs e)
        {
            selectedModel = 6;
            ActiveControl = null;
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

        private void panelCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editingBlock = blocks.LastOrDefault(block => block.Contains(e.X, e.Y));
            if (editingBlock != null)
            {
                editText = new TextBox()
                {
                    Location = new Point(editingBlock.X + 5, editingBlock.Y + 5),
                    Size = new Size(editingBlock.Width - 10, editingBlock.Height - 10),
                    Text = editingBlock.Text,
                    Multiline = true,
                    Font = editingBlock.Font,
                    TextAlign = HorizontalAlignment.Center,
                    BorderStyle = BorderStyle.None,
                };
                panelCanvas.Controls.Add(editText);
                panelCanvas.Invalidate();
            };
        }
    }
}

using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BlockDiagramEditor.Services;

namespace BlockDiagramEditor.WF
{
    public partial class Form1 : Form
    {
        private int selectedModel = 0;
        private bool isDragging = false;
        private Point offset;

        private BlockManager BlockManager = new BlockManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var block in BlockManager.Blocks) block.Draw(e);
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            BlockManager.SelectBlock(e.X, e.Y);

            if (selectedModel != 0)
            {
                int x = (e.X - 80) - (e.X - 80) % 10;
                int y = (e.Y - 40) - (e.Y - 40) % 10;
                BlockManager.AddBlock(selectedModel, x, y);
                selectedModel = 0;
            }

            if (BlockManager.SelectedBlock != null && selectedModel == 0)
            {
                isDragging = true;
                offset = new Point(e.X - BlockManager.SelectedBlock.X, e.Y - BlockManager.SelectedBlock.Y);
            }

            BlockManager.EndEditingText(panelCanvas);

            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                BlockManager.MoveBlock(e.X, e.Y, offset);
                panelCanvas.Invalidate();
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            BlockManager.SelectedBlock = null;
        }

        private void panelCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BlockManager.StartEditingText(panelCanvas, e.X, e.Y);
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

        private void btnDeleteBlock_Click(object sender, EventArgs e)
        {
            BlockManager.DeleteBlock(panelCanvas);
            ActiveControl = null;
            panelCanvas.Invalidate();
        }
    }
}

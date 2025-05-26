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
        private bool isPanning = false;
        private PointF lastMousePosition;
        private PointF dragOffset;

        private BlockManager BlockManager = new BlockManager();

        public Form1()
        {
            InitializeComponent();
            panelCanvas.MouseWheel += PanelCanvas_MouseWheel;
        }

        private void PanelCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            BlockManager.ChangeScale(e.Delta);
            labelScale.Text = $"Масштаб: {BlockManager.Scale * 100}%";
            BlockManager.EndEditingText(panelCanvas);
            panelCanvas.Invalidate();
        }   

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var block in BlockManager.Blocks) block.Draw(e, BlockManager.Scale, BlockManager.CanvasOffset);
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            BlockManager.SelectBlock(e.X, e.Y);

            if (selectedModel != 0)
            {
                BlockManager.AddBlock(selectedModel, e.X, e.Y);
                selectedModel = 0;
            }

            if (BlockManager.SelectedBlock != null && selectedModel == 0)
            {
                isDragging = true;
                dragOffset = new PointF(e.X / BlockManager.Scale - BlockManager.SelectedBlock.X, e.Y / BlockManager.Scale - BlockManager.SelectedBlock.Y);
            }

            if (BlockManager.SelectedBlock == null && e.Button == MouseButtons.Right)
            {
                isPanning = true;
                lastMousePosition = e.Location;
                Cursor = Cursors.SizeAll;
            }

            BlockManager.EndEditingText(panelCanvas);

            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                BlockManager.MoveBlock(e.X / BlockManager.Scale, e.Y / BlockManager.Scale, dragOffset);
            }

            if (BlockManager.SelectedBlock == null && isPanning)
            {
                BlockManager.CanvasOffset = new PointF(BlockManager.CanvasOffset.X + e.X - lastMousePosition.X, BlockManager.CanvasOffset.Y + e.Y - lastMousePosition.Y);
                lastMousePosition = e.Location;
            }

            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            isPanning = false;
            Cursor = Cursors.Default;
            BlockManager.SelectedBlock = null;
        }

        private void panelCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BlockManager.StartEditingText(panelCanvas, e.X / BlockManager.Scale, e.Y / BlockManager.Scale);
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

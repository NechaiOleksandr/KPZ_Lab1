using System;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private Pen centerLine = new Pen(Color.Black, 1)
        {
            DashStyle = DashStyle.Custom,
            DashPattern = new float[] { 5, 3 }
        }
        ;
        private CoordinateTransformer tr = new CoordinateTransformer();
        private BlockManager BlockManager;

        public Form1()
        {
            InitializeComponent();
            panelCanvas.MouseWheel += PanelCanvas_MouseWheel;
            BlockManager = new BlockManager(tr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tr.CanvasOffset = new Point(panelCanvas.Width / 2, panelCanvas.Height / 2);
        }

        private void PanelCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            tr.ChangeScale(e.Delta);
            labelScale.Text = $"Масштаб: {tr.Scale * 100}%";
            BlockManager.EndEditingText(panelCanvas);
            panelCanvas.Invalidate();
        }   

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (showCenter.Checked)
            {
                e.Graphics.DrawLine(centerLine, tr.CanvasOffset.X % 8 - 5, tr.CanvasOffset.Y, panelCanvas.Width, tr.CanvasOffset.Y);
                e.Graphics.DrawLine(centerLine, tr.CanvasOffset.X, tr.CanvasOffset.Y % 8 - 5, tr.CanvasOffset.X, panelCanvas.Height);
            }
            foreach (var block in BlockManager.Blocks) block.Draw(e, tr);
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectedModel == 0)
            {
                BlockManager.SelectBlock(e.X, e.Y);
            }

            if (selectedModel != 0)
            {
                BlockManager.AddBlock(selectedModel, e.X, e.Y);
                selectedModel = 0;
            }

            if (BlockManager.SelectedBlock != null && selectedModel == 0 && e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragOffset = new PointF(e.X / tr.Scale - BlockManager.SelectedBlock.X, e.Y / tr.Scale - BlockManager.SelectedBlock.Y);
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
                BlockManager.MoveBlock(e.X / tr.Scale, e.Y / tr.Scale, dragOffset);
            }

            if (BlockManager.SelectedBlock == null && isPanning)
            {
                tr.CanvasOffset = new PointF(tr.CanvasOffset.X + e.X - lastMousePosition.X, tr.CanvasOffset.Y + e.Y - lastMousePosition.Y);
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
            BlockManager.StartEditingText(panelCanvas, e.X / tr.Scale, e.Y / tr.Scale);
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

        private void showCenter_CheckedChanged(object sender, EventArgs e)
        {
            panelCanvas.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                BlockManager.DeleteBlock(panelCanvas);
                panelCanvas.Invalidate();
            }
        }
    }
}

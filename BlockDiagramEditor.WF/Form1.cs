using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using BlockDiagramEditor.Models;
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
        };
        private CoordinateTransformer tr = new CoordinateTransformer();
        private BlockManager BlockManager;
        private ArrowManager ArrowManager;
        private ResizeHandle currentBlockResizeHandle = ResizeHandle.None;
        private int currentArrowResizeHandle = -1;
        private bool isResizing = false;

        public Form1()
        {
            InitializeComponent();
            panelCanvas.MouseWheel += PanelCanvas_MouseWheel;
            BlockManager = new BlockManager(tr);
            ArrowManager = new ArrowManager(tr);
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

            if (BlockManager.SelectedBlock != null || ArrowManager.SelectedArrow != null)
            {
                btnDelete.Enabled = true;
                btnDelete.ForeColor = Color.Black;
            }
            else
            {
                btnDelete.Enabled = false;
                btnDelete.ForeColor = Color.Gainsboro;
                btnDelete.FlatAppearance.BorderColor = Color.Black;
            }

            foreach (var block in BlockManager.Blocks) block.Draw(e, tr);
            foreach (var arrow in ArrowManager.Arrows) arrow.Draw(e, tr);
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isPanning = true;
                lastMousePosition = e.Location;
                Cursor = Cursors.SizeAll;
            }

            if (BlockManager.SelectedBlock != null && e.Button == MouseButtons.Left)
            {
                currentBlockResizeHandle = BlockManager.SelectedBlock.GetResizeHandleAt(e.Location, tr);
                if (currentBlockResizeHandle != ResizeHandle.None)
                {
                    isResizing = true;
                    BlockManager.EndEditingText(panelCanvas);
                    return;
                }
            }

            if (ArrowManager.SelectedArrow != null && e.Button == MouseButtons.Left)
            {
                ArrowManager.SelectedArrow.AddPoint(e.Location, tr);
                currentArrowResizeHandle = ArrowManager.SelectedArrow.GetHandleAt(e.Location, tr);
                if (currentArrowResizeHandle != -1)
                {
                    isResizing = true;
                    return;
                }
            }

            if (e.Button == MouseButtons.Left && selectedModel == 0)
            {
                if (BlockManager.SelectedBlock == null)
                ArrowManager.SelectArrow(e.X, e.Y);
                if (ArrowManager.SelectedArrow == null)
                BlockManager.SelectBlock(e.X, e.Y);
            }

            if (selectedModel != 0)
            {
                if (selectedModel <= 6)
                    BlockManager.AddBlock(selectedModel, e.X, e.Y);
                else
                    ArrowManager.AddArrow(selectedModel - 6, e.X, e.Y);
                selectedModel = 0;
            }

            if ((BlockManager.SelectedBlock != null || ArrowManager.SelectedArrow != null) && selectedModel == 0 && e.Button == MouseButtons.Left)
            {
                isDragging = true;
                if (ArrowManager.SelectedArrow != null)
                    dragOffset = new PointF(e.X / tr.Scale - ArrowManager.SelectedArrow.Points[0].X, e.Y / tr.Scale - ArrowManager.SelectedArrow.Points[0].Y);
                else if (BlockManager.SelectedBlock != null)
                    dragOffset = new PointF(e.X / tr.Scale - BlockManager.SelectedBlock.X, e.Y / tr.Scale - BlockManager.SelectedBlock.Y);
            }

            BlockManager.EndEditingText(panelCanvas);

            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                BlockManager.MoveBlock(e.X / tr.Scale, e.Y / tr.Scale, dragOffset);
                ArrowManager.ResizeArrowsByBracing();
                ArrowManager.MoveArrow(e.X / tr.Scale, e.Y / tr.Scale, dragOffset);

                if (ArrowManager.SelectedArrow != null && BlockManager.Blocks.Count > 0)
                    ArrowManager.Connect(BlockManager.Blocks, currentArrowResizeHandle);
            }

            if (isPanning)
            {
                tr.CanvasOffset = new PointF(tr.CanvasOffset.X + e.X - lastMousePosition.X, tr.CanvasOffset.Y + e.Y - lastMousePosition.Y);
                lastMousePosition = e.Location;
            }

            if (isResizing && (BlockManager.SelectedBlock != null || ArrowManager.SelectedArrow != null))
            {
                if (ArrowManager.SelectedArrow != null && currentArrowResizeHandle != -1)
                {
                    ArrowManager.ResizeSelectedArrow(currentArrowResizeHandle, tr.STCX(e.X), tr.STCY(e.Y));
                    if (BlockManager.Blocks.Count > 0)
                        ArrowManager.Connect(BlockManager.Blocks, currentArrowResizeHandle);
                }

                else if (BlockManager.SelectedBlock != null && currentBlockResizeHandle != ResizeHandle.None)
                {
                    BlockManager.ResizeSelectedBlock(currentBlockResizeHandle, tr.STCX(e.X), tr.STCY(e.Y));
                    ArrowManager.ResizeArrowsByBracing();
                }
            }

            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            isPanning = false;
            Cursor = Cursors.Default;
            isResizing = false;
            currentBlockResizeHandle = ResizeHandle.None;
            currentArrowResizeHandle = -1;
            if (ArrowManager.SelectedArrow != null) 
                if (ArrowManager.SelectedArrow.RebuildArrow() == true) 
                    ArrowManager.Arrows.Remove(ArrowManager.SelectedArrow);
            ArrowManager.ResizeArrowsByBracing();
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

        private void btnSelectArrow_Click(object sender, EventArgs e)
        {
            selectedModel = 7;
            ActiveControl = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BlockManager.DeleteBlock(panelCanvas);
            ArrowManager.DeleteArrow(panelCanvas);
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
                ArrowManager.DeleteArrow(panelCanvas);
                panelCanvas.Invalidate();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ActiveControl = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            BlockManager.Search(textBoxSearch.Text);
            panelCanvas.Invalidate();
        }

        private void unsetSearch_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            BlockManager.UnsetSearch();
            panelCanvas.Invalidate();
        }
    }
}

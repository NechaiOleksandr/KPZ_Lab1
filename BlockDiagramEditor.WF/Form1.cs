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
        private Pen centerLine = new Pen(Color.LightGray, 2);
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
            if (showGrid.Checked)
            {
                e.Graphics.DrawLine(centerLine, tr.CanvasOffset.X % 8 - 5, tr.CanvasOffset.Y, panelCanvas.Width, tr.CanvasOffset.Y);
                e.Graphics.DrawLine(centerLine, tr.CanvasOffset.X, tr.CanvasOffset.Y % 8 - 5, tr.CanvasOffset.X, panelCanvas.Height);

                int step;
                if (tr.Scale == 5) step = 5;
                else if (tr.Scale >= 2.5) step = 10;
                else if (tr.Scale >= 1) step = 20;
                else if (tr.Scale >= 0.5) step = 40;
                else step = 80;

                for (float y = tr.CanvasOffset.Y - step * tr.Scale; y >= 0; y -= step * tr.Scale)
                    e.Graphics.DrawLine(Pens.Silver, 0, y, panelCanvas.Width, y);
                for (float y = tr.CanvasOffset.Y + step * tr.Scale; y < panelCanvas.Height; y += step * tr.Scale)
                    e.Graphics.DrawLine(Pens.Silver, 0, y, panelCanvas.Width, y);
                for (float x = tr.CanvasOffset.X - step * tr.Scale; x >= 0; x -= step * tr.Scale)
                    e.Graphics.DrawLine(Pens.Silver, x, 0, x, panelCanvas.Height);
                for (float x = tr.CanvasOffset.X + step * tr.Scale; x < panelCanvas.Width; x += step * tr.Scale)
                    e.Graphics.DrawLine(Pens.Silver, x, 0, x, panelCanvas.Height);

                panelBlockStyleEdit.Visible = BlockManager.SelectedBlock != null;
                if (BlockManager.SelectedBlock != null)
                {
                    ActiveControl = null;
                    nudBlockX.Value = (int)BlockManager.SelectedBlock.X;
                    nudBlockY.Value = (int)BlockManager.SelectedBlock.Y;
                    nudBlockWidth.Value = (int)BlockManager.SelectedBlock.Width;
                    nudBlockHeight.Value = (int)BlockManager.SelectedBlock.Height;
                    btnBLockColor.BackColor = BlockManager.SelectedBlock.Brush.Color;
                    btnBLockColor.FlatAppearance.MouseOverBackColor = btnBLockColor.BackColor;
                    btnBLockColor.FlatAppearance.MouseDownBackColor = btnBLockColor.BackColor;
                    btnBlockBorderColor.BackColor = BlockManager.SelectedBlock.Border.Color;
                    btnBlockBorderColor.FlatAppearance.MouseOverBackColor = btnBlockBorderColor.BackColor;
                    btnBlockBorderColor.FlatAppearance.MouseDownBackColor = btnBlockBorderColor.BackColor;
                    nudBlockBorderWidth.Value = (int)BlockManager.SelectedBlock.Border.Width;
                    fontDialog.Font = BlockManager.SelectedBlock.Font;
                    tbBlockFont.Text = $"{BlockManager.SelectedBlock.Font.FontFamily.Name}, {(int)BlockManager.SelectedBlock.Font.Size}";
                    btnBlockTextColor.BackColor = BlockManager.SelectedBlock.TextColor.Color;
                    btnBlockTextColor.FlatAppearance.MouseOverBackColor = btnBlockTextColor.BackColor;
                    btnBlockTextColor.FlatAppearance.MouseDownBackColor = btnBlockTextColor.BackColor;
                }

                panelArrowStyleEdit.Visible = ArrowManager.SelectedArrow != null;
                if (ArrowManager.SelectedArrow != null)
                {
                    ActiveControl = null;
                    btnArrowColor.BackColor = ArrowManager.SelectedArrow.Pen.Color;
                    btnArrowColor.FlatAppearance.MouseOverBackColor = btnArrowColor.BackColor;
                    btnArrowColor.FlatAppearance.MouseDownBackColor = btnArrowColor.BackColor;
                    nudArrowWidth.Value = (int)ArrowManager.SelectedArrow.Pen.Width;
                }
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

            if (ArrowManager.Arrows.Count > 0 && ArrowManager.Arrows[0].Bracing[0].Block != null) 
            labelBlocks.Text = ArrowManager.Arrows[0].Bracing[0].Block.IsSelected.ToString();
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
                if (selectedModel <= 7)
                    BlockManager.AddBlock(selectedModel, e.X, e.Y);
                else
                    ArrowManager.AddArrow(selectedModel - 7, e.X, e.Y);
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

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) 
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

        private void btnSelectText_Click(object sender, EventArgs e)
        {
            selectedModel = 7;
            ActiveControl = null;
        }

        private void btnSelectClasicArrow_Click(object sender, EventArgs e)
        {
            selectedModel = 8;
            ActiveControl = null;
        }

        private void btnSelectEmptyTrArrow_Click(object sender, EventArgs e)
        {
            selectedModel = 9;
            ActiveControl = null;
        }

        private void btnSelectFilledTrArrow_Click(object sender, EventArgs e)
        {
            selectedModel = 10;
            ActiveControl = null;
        }

        private void btnSelectLineArrow_Click(object sender, EventArgs e)
        {
            selectedModel = 11;
            ActiveControl = null;
        }

        private void btnSelectTwoHeadedArrow_Click(object sender, EventArgs e)
        {
            selectedModel = 12;
            ActiveControl = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BlockManager.DeleteBlock(panelCanvas, ArrowManager.Arrows);
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
                BlockManager.DeleteBlock(panelCanvas, ArrowManager.Arrows);
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

        private void panelBlockEdit_MouseClick(object sender, MouseEventArgs e)
        {
            ActiveControl = null;
        }

        private void btnBlockStyleApply_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            BlockManager.SelectedBlock.X = (float)nudBlockX.Value;
            BlockManager.SelectedBlock.Y = (float)nudBlockY.Value;
            BlockManager.SelectedBlock.Width = (float)nudBlockWidth.Value;
            BlockManager.SelectedBlock.Height = (float)nudBlockHeight.Value;
            BlockManager.SelectedBlock.Brush.Color = btnBLockColor.BackColor;
            BlockManager.SelectedBlock.Border.Color = btnBlockBorderColor.BackColor;
            BlockManager.SelectedBlock.Border.Width = (float)nudBlockBorderWidth.Value;
            BlockManager.SelectedBlock.Font = fontDialog.Font;
            BlockManager.SelectedBlock.TextColor.Color = btnBlockTextColor.BackColor;

            panelCanvas.Invalidate();
        }

        private void btnApplyArrowStyle_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            ArrowManager.SelectedArrow.Pen.Color = btnArrowColor.BackColor;
            ArrowManager.SelectedArrow.Pen.Width = (float)nudArrowWidth.Value;

            panelCanvas.Invalidate();
        }

        private void btnBLockColor_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            colorDialog.Color = BlockManager.SelectedBlock.Brush.Color;
            colorDialog.ShowDialog();
            btnBLockColor.BackColor = colorDialog.Color;
            btnBLockColor.FlatAppearance.MouseOverBackColor = btnBLockColor.BackColor;
            btnBLockColor.FlatAppearance.MouseDownBackColor = btnBLockColor.BackColor;
        }

        private void btnBlockBorderColor_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            colorDialog.Color = BlockManager.SelectedBlock.Border.Color;
            colorDialog.ShowDialog();
            btnBlockBorderColor.BackColor = colorDialog.Color;
            btnBlockBorderColor.FlatAppearance.MouseOverBackColor = btnBlockBorderColor.BackColor;
            btnBlockBorderColor.FlatAppearance.MouseDownBackColor = btnBlockBorderColor.BackColor;
        }

        private void btnBlockTextColor_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            colorDialog.Color = BlockManager.SelectedBlock.TextColor.Color;
            colorDialog.ShowDialog();
            btnBlockTextColor.BackColor = colorDialog.Color;
            btnBlockTextColor.FlatAppearance.MouseOverBackColor = btnBlockTextColor.BackColor;
            btnBlockTextColor.FlatAppearance.MouseOverBackColor = btnBlockTextColor.BackColor;
        }

        private void tbBlockFont_MouseClick(object sender, MouseEventArgs e)
        {
            ActiveControl = null;
            fontDialog.Font = BlockManager.SelectedBlock.Font;
            fontDialog.ShowDialog();
            tbBlockFont.Text = $"{fontDialog.Font.FontFamily.Name}, {(int)fontDialog.Font.Size}";
        }

        private void btnArrowColor_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            colorDialog.Color = ArrowManager.SelectedArrow.Pen.Color;
            colorDialog.ShowDialog();
            btnArrowColor.BackColor = colorDialog.Color;
            btnArrowColor.FlatAppearance.MouseOverBackColor = btnArrowColor.BackColor;
            btnArrowColor.FlatAppearance.MouseDownBackColor = btnArrowColor.BackColor;
        }

    }
}

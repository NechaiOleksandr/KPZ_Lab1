using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BlockDiagramEditor.Models;
using BlockDiagramEditor.Services;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using BlockDiagramEditor.Models.Arrows;

namespace BlockDiagramEditor.WF
{
    public partial class Form1 : Form
    {
        private ElementType selectedType = ElementType.None;
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
            DrawGrid(e.Graphics);

            foreach (var block in BlockManager.Blocks) block.Draw(e, tr);
            foreach (var arrow in ArrowManager.Arrows) arrow.Draw(e, tr);

            if (ArrowManager.Arrows.Count > 0 && ArrowManager.Arrows[0].Bracing[0].Block != null) 
            labelBlocks.Text = ArrowManager.Arrows[0].Bracing[0].Block.IsSelected.ToString();
        }

        private void DrawGrid(Graphics g)
        {
            if (!showGrid.Checked) return;

            g.DrawLine(centerLine, tr.CanvasOffset.X % 8 - 5, tr.CanvasOffset.Y, panelCanvas.Width, tr.CanvasOffset.Y);
            g.DrawLine(centerLine, tr.CanvasOffset.X, tr.CanvasOffset.Y % 8 - 5, tr.CanvasOffset.X, panelCanvas.Height);

            int step;
            float currentScale = tr.Scale;

            if (currentScale >= 5f)
            {
                step = 5;
            }
            else if (currentScale >= 2.5f)
            {
                step = 10;
            }
            else if (currentScale >= 1f)
            {
                step = 20;
            }
            else if (currentScale >= 0.5f)
            {
                step = 40;
            }
            else
            {
                step = 80;
            }

            for (float y = tr.CanvasOffset.Y - step * tr.Scale; y >= 0; y -= step * tr.Scale)
                g.DrawLine(Pens.Silver, 0, y, panelCanvas.Width, y);
            for (float y = tr.CanvasOffset.Y + step * tr.Scale; y < panelCanvas.Height; y += step * tr.Scale)
                g.DrawLine(Pens.Silver, 0, y, panelCanvas.Width, y);
            for (float x = tr.CanvasOffset.X - step * tr.Scale; x >= 0; x -= step * tr.Scale)
                g.DrawLine(Pens.Silver, x, 0, x, panelCanvas.Height);
            for (float x = tr.CanvasOffset.X + step * tr.Scale; x < panelCanvas.Width; x += step * tr.Scale)
                g.DrawLine(Pens.Silver, x, 0, x, panelCanvas.Height);
        }

        private void UpdatePropertiesPanel()
        {
            var selectedBlock = BlockManager.SelectedBlock;
            var selectedArrow = ArrowManager.SelectedArrow;

            panelBlockStyleEdit.Visible = selectedBlock != null;
            if (selectedBlock != null)
            {
                bool isNotText = selectedBlock.Type != "TextBlock";
                nudBlockWidth.Minimum = isNotText ? 30 : 0;
                nudBlockHeight.Minimum = isNotText ? 30 : 0;

                lblBlockWidth.Visible = lblBlockHeight.Visible = nudBlockWidth.Visible =
                nudBlockHeight.Visible = lblBlockColor.Visible = btnBLockColor.Visible =
                lblBlockBorderColor.Visible = btnBlockBorderColor.Visible =
                lblBlockBorderWidth.Visible = nudBlockBorderWidth.Visible = isNotText;

                nudBlockX.Value = (int)selectedBlock.X;
                nudBlockY.Value = (int)selectedBlock.Y;
                nudBlockWidth.Value = (int)selectedBlock.Width;
                nudBlockHeight.Value = (int)selectedBlock.Height;

                btnBLockColor.BackColor = selectedBlock.Brush.Color;
                btnBlockBorderColor.BackColor = selectedBlock.Border.Color;
                nudBlockBorderWidth.Value = (int)selectedBlock.Border.Width;
                tbBlockFont.Text = $"{selectedBlock.Font.FontFamily.Name}, {Math.Round(selectedBlock.Font.Size)}";
                btnBlockTextColor.BackColor = selectedBlock.TextColor.Color;
            }

            panelArrowStyleEdit.Visible = selectedArrow != null;
            if (selectedArrow != null)
            {
                btnArrowColor.BackColor = selectedArrow.Pen.Color;
                nudArrowWidth.Value = (int)selectedArrow.Pen.Width;
            }

            bool hasSelection = selectedBlock != null || selectedArrow != null;
            btnDelete.Enabled = hasSelection;
            btnDelete.ForeColor = hasSelection ? Color.Black : Color.Gainsboro;
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

            if (BlockManager.Blocks.Count > 0 && ArrowManager.SelectedArrow != null)
                ArrowManager.Connect(BlockManager.Blocks, currentArrowResizeHandle);

            if (e.Button == MouseButtons.Left && selectedType == ElementType.None)
            {
                if (BlockManager.SelectedBlock == null)
                ArrowManager.SelectArrow(e.X, e.Y);
                if (ArrowManager.SelectedArrow == null)
                BlockManager.SelectBlock(e.X, e.Y);
            }

            if (selectedType != ElementType.None)
            {
                string typeName = selectedType.ToString();

                if (typeName.StartsWith("Block"))
                {
                    BlockManager.AddBlock(selectedType, e.X, e.Y);
                }
                else if (typeName.StartsWith("Arrow"))
                {
                    ArrowManager.AddArrow(selectedType, e.X, e.Y);
                }

                selectedType = ElementType.None;
            }

            if ((BlockManager.SelectedBlock != null || ArrowManager.SelectedArrow != null) && selectedType == ElementType.None && e.Button == MouseButtons.Left)
            {
                isDragging = true;
                if (ArrowManager.SelectedArrow != null)
                    dragOffset = new PointF(e.X / tr.Scale - ArrowManager.SelectedArrow.Points[0].X, e.Y / tr.Scale - ArrowManager.SelectedArrow.Points[0].Y);
                else if (BlockManager.SelectedBlock != null)
                    dragOffset = new PointF(e.X / tr.Scale - BlockManager.SelectedBlock.X, e.Y / tr.Scale - BlockManager.SelectedBlock.Y);
            }

            BlockManager.EndEditingText(panelCanvas);

            UpdatePropertiesPanel();

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

            if (isPanning)
            {
                tr.CanvasOffset = new PointF(tr.CanvasOffset.X + e.X - lastMousePosition.X, tr.CanvasOffset.Y + e.Y - lastMousePosition.Y);
                lastMousePosition = e.Location;
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

            UpdatePropertiesPanel();

            panelCanvas.Invalidate();
        }

        private void panelCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BlockManager.StartEditingText(panelCanvas, e.X, e.Y);
            panelCanvas.Invalidate();
        }

        private void btnSelectTerminator_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.BlockTerminator;
            ActiveControl = null;
        }

        private void btnSelectParalelogram_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.BlockParalelogram;
            ActiveControl = null;
        }

        private void btnSelectRectangle_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.BlockRectangle;
            ActiveControl = null;
        }

        private void btnSelectDiamond_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.BlockDiamond;
            ActiveControl = null;
        }

        private void btnSelectHexagon_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.BlockHexagon;
            ActiveControl = null;
        }

        private void btnSelectEllipse_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.BlockEllipse;
            ActiveControl = null;
        }

        private void btnSelectText_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.BlockText;
            ActiveControl = null;
        }

        private void btnSelectClasicArrow_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.ArrowClassic;
            ActiveControl = null;
        }

        private void btnSelectEmptyTrArrow_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.ArrowEmptyTr;
            ActiveControl = null;
        }

        private void btnSelectFilledTrArrow_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.ArrowFilledTr;
            ActiveControl = null;
        }

        private void btnSelectLineArrow_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.ArrowLine;
            ActiveControl = null;
        }

        private void btnSelectTwoHeadedArrow_Click(object sender, EventArgs e)
        {
            selectedType = ElementType.ArrowTwoHeaded;
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

        private void btnApplyBlockStyle_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            BlockManager.EndEditingText(panelCanvas);
            BlockManager.SelectedBlock.X = (float)(nudBlockX.Value - nudBlockX.Value % 10);
            BlockManager.SelectedBlock.Y = (float)(nudBlockY.Value - nudBlockY.Value % 10);
            BlockManager.SelectedBlock.Width = (float)(nudBlockWidth.Value - nudBlockWidth.Value % 10);
            BlockManager.SelectedBlock.Height = (float)(nudBlockHeight.Value - nudBlockHeight.Value % 10);
            BlockManager.SelectedBlock.Brush.Color = btnBLockColor.BackColor;
            BlockManager.SelectedBlock.Border.Color = btnBlockBorderColor.BackColor;
            BlockManager.SelectedBlock.Border.Width = (float)nudBlockBorderWidth.Value;
            BlockManager.SelectedBlock.Font = fontDialog.Font;
            BlockManager.SelectedBlock.TextColor.Color = btnBlockTextColor.BackColor;
            if (BlockManager.SelectedBlock is TextBlock textBlock)
                textBlock.ResizeByText();

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
            tbBlockFont.Text = $"{fontDialog.Font.FontFamily.Name}, {Math.Round(fontDialog.Font.Size)}";
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            var blockDTOs = BlockManager.Blocks.Select(b => new BlockDTO(b)).ToList();
            var arrowDTOs = ArrowManager.Arrows.Select(a => new ArrowDTO(a)).ToList();
            var data = new { Blocks = blockDTOs, Arrows = arrowDTOs };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON файли (*.json)|*.json";
            saveFileDialog.Title = "Зберегти діаграму";
            saveFileDialog.FileName = "diagram.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON файли (*.json)|*.json";
            openFileDialog.Title = "Відкрити діаграму";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string json = File.ReadAllText(openFileDialog.FileName);
                    var canvasDto = JsonConvert.DeserializeObject<CanvasDTO>(json);

                    if (canvasDto != null && canvasDto.Blocks != null && canvasDto.Arrows != null)
                    {
                        var loadedBlocks = canvasDto.Blocks.Select(dto => dto.ToBlock()).ToList();
                        var loadedArrows = canvasDto.Arrows.Select(dto => dto.ToArrow(loadedBlocks)).ToList();
                        BlockManager = new BlockManager(tr);
                        BlockManager.Blocks.AddRange(loadedBlocks);
                        BlockManager.CurrentId = BlockManager.Blocks.Max(block => block.Id) + 1;
                        ArrowManager = new ArrowManager(tr);
                        ArrowManager.Arrows.AddRange(loadedArrows);
                        UpdatePropertiesPanel();
                        panelCanvas.Invalidate();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Під час завантаження файлу сталася помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

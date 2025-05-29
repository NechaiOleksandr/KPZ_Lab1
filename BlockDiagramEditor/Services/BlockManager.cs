using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Models;

namespace BlockDiagramEditor.Services
{
    public class BlockManager
    {
        public List<Block> Blocks { get; private set; } = new List<Block>();
        public Block SelectedBlock { get; set; }
        public Block LastSelectedBlock { get; set; }
        public Block EditingBlock { get; set; }
        public TextBox EditText { get; set; }
        public CoordinateTransformer Tr { get; set; }
        public BlockManager(CoordinateTransformer transformer)
        {
            Tr = transformer;
        }

        public void SelectBlock(int x, int y)
        {
            if (LastSelectedBlock != null && !LastSelectedBlock.Contains(Tr.STCX(x), Tr.STCY(y)))
            {
                LastSelectedBlock.IsSelected = false;
            }
            SelectedBlock = Blocks.LastOrDefault(block => block.Contains(Tr.STCX(x), Tr.STCY(y)));
            if (SelectedBlock != null)
            {
                SelectedBlock.IsSelected = true;
                LastSelectedBlock = SelectedBlock;
                Blocks.Remove(SelectedBlock);
                Blocks.Add(SelectedBlock);
            }
        }

        public void AddBlock(int model, int x, int y)
        {
            float X = (Tr.STCX(x) - 80) - (Tr.STCX(x) - 80) % 10;
            float Y = (Tr.STCY(y) - 40) - (Tr.STCY(y) - 40) % 10;
            Block newBlock = null;
            switch (model)
            {
                case 1: newBlock = new TerminatorBlock(X, Y); break;
                case 2: newBlock = new ParalelogramBlock(X, Y); break;
                case 3: newBlock = new RectangleBlock(X, Y); break;
                case 4: newBlock = new DiamondBlock(X, Y); break;
                case 5: newBlock = new HexagonBlock(X, Y); break;
                case 6: newBlock = new EllipseBlock(X, Y); break;
            }
            if (newBlock != null)
            {
                Blocks.Add(newBlock);
            }
        }

        public void DeleteBlock(Control canvas)
        {
            Blocks.RemoveAll(block => block.IsSelected == true);
            SelectedBlock = null;

            if (EditText != null)
            {
                canvas.Controls.Remove(EditText);
                EditText = null;
            }
        }

        public void MoveBlock(float x, float y, PointF offset)
        {
            if (SelectedBlock != null)
            {
                SelectedBlock.X = (x - offset.X) - (x - offset.X) % 10;
                SelectedBlock.Y = (y - offset.Y) - (y - offset.Y) % 10;
            }
        }

        public void StartEditingText(Control canvas, float x, float y)
        {
            EditingBlock = Blocks.LastOrDefault(block => block.Contains(Tr.STCX(x), Tr.STCY(y)));
            if (EditingBlock != null)
            {
                EditText = new TextBox()
                {
                    Location = new Point((int)Tr.CTSX(EditingBlock.X + 5), (int)Tr.CTSY(EditingBlock.Y + 5)),
                    Size = new Size((int)Tr.CTSS(EditingBlock.Width - 10), (int)Tr.CTSS(EditingBlock.Height - 10)),
                    Text = EditingBlock.Text,
                    Multiline = true,
                    Font = new Font(EditingBlock.Font.FontFamily, (int)Tr.CTSS(EditingBlock.Font.Size)),
                    TextAlign = HorizontalAlignment.Center,
                    BorderStyle = BorderStyle.None,
                };
                canvas.Controls.Add(EditText);
                EditText.Focus();
                EditText.SelectAll();
            }
        }

        public void EndEditingText(Control canvas)
        {
            if (EditText != null && EditingBlock != null)
            {
                EditingBlock.Text = EditText.Text;
                canvas.Controls.Remove(EditText);
                EditingBlock = null;
                EditText = null;
            }
        }

        public void ResizeSelectedBlock(ResizeHandle handle, float canvasX, float canvasY)
        {
            switch (handle)
            {
                case ResizeHandle.BottomRight:
                    if (canvasX - SelectedBlock.X >= 30)
                        SelectedBlock.Width = (canvasX - SelectedBlock.X) - (canvasX - SelectedBlock.X) % 10;
                    if (canvasY - SelectedBlock.Y >= 30)
                        SelectedBlock.Height = (canvasY - SelectedBlock.Y) - (canvasY - SelectedBlock.Y) % 10;
                    break;

                case ResizeHandle.RightCenter:
                    if (canvasX - SelectedBlock.X >= 30)
                        SelectedBlock.Width = (canvasX - SelectedBlock.X) - (canvasX - SelectedBlock.X) % 10;
                    break;

                case ResizeHandle.BottomCenter:
                    if (canvasY - SelectedBlock.Y >= 30)
                        SelectedBlock.Height = (canvasY - SelectedBlock.Y) - (canvasY - SelectedBlock.Y) % 10;
                    break;

                case ResizeHandle.TopLeft:
                    if (SelectedBlock.Width + SelectedBlock.X - canvasX >= 30)
                    {
                        SelectedBlock.Width = (SelectedBlock.Width + (SelectedBlock.X - canvasX)) - (SelectedBlock.Width + (SelectedBlock.X - canvasX)) % 10;
                        SelectedBlock.X += (SelectedBlock.Width - ((SelectedBlock.Width + (SelectedBlock.X - canvasX)) - (SelectedBlock.Width + (SelectedBlock.X - canvasX)) % 10));
                    }
                    if (SelectedBlock.Height + SelectedBlock.Y - canvasY >= 30)
                    {
                        SelectedBlock.Height = (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) - (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) % 10;
                        SelectedBlock.Y += (SelectedBlock.Height - ((SelectedBlock.Height + (SelectedBlock.Y - canvasY)) - (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) % 10));
                    }
                    break;
                        
                case ResizeHandle.TopCenter:
                    if (SelectedBlock.Height + SelectedBlock.Y - canvasY >= 30)
                    {
                        SelectedBlock.Height = (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) - (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) % 10;
                        SelectedBlock.Y += (SelectedBlock.Height - ((SelectedBlock.Height + (SelectedBlock.Y - canvasY)) - (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) % 10));
                    }
                    break;

                case ResizeHandle.LeftCenter:
                    if (SelectedBlock.Width + SelectedBlock.X - canvasX >= 30)
                    {
                        SelectedBlock.Width = (SelectedBlock.Width + (SelectedBlock.X - canvasX)) - (SelectedBlock.Width + (SelectedBlock.X - canvasX)) % 10;
                        SelectedBlock.X += (SelectedBlock.Width - ((SelectedBlock.Width + (SelectedBlock.X - canvasX)) - (SelectedBlock.Width + (SelectedBlock.X - canvasX)) % 10));
                    }
                    break;

                case ResizeHandle.TopRight:
                    if ((canvasX - SelectedBlock.X) - (canvasX - SelectedBlock.X) % 10 >= 30)
                        SelectedBlock.Width = (canvasX - SelectedBlock.X) - (canvasX - SelectedBlock.X) % 10;
                    if (SelectedBlock.Height + SelectedBlock.Y - canvasY >= 30)
                    {
                        SelectedBlock.Height = (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) - (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) % 10;
                        SelectedBlock.Y += (SelectedBlock.Height - ((SelectedBlock.Height + (SelectedBlock.Y - canvasY)) - (SelectedBlock.Height + (SelectedBlock.Y - canvasY)) % 10));
                    }
                    break;

                case ResizeHandle.BottomLeft:
                    if (SelectedBlock.Width + SelectedBlock.X - canvasX >= 30)
                    {
                        SelectedBlock.Width = (SelectedBlock.Width + (SelectedBlock.X - canvasX)) - (SelectedBlock.Width + (SelectedBlock.X - canvasX)) % 10;
                        SelectedBlock.X += (SelectedBlock.Width - ((SelectedBlock.Width + (SelectedBlock.X - canvasX)) - (SelectedBlock.Width + (SelectedBlock.X - canvasX)) % 10));
                    }
                    if (canvasY - SelectedBlock.Y >= 30)
                        SelectedBlock.Height = (canvasY - SelectedBlock.Y) - (canvasY - SelectedBlock.Y) % 10;
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Models;
using BlockDiagramEditor.Models.Arrows;

namespace BlockDiagramEditor.Services
{
    public class BlockManager
    {
        public List<Block> Blocks { get; private set; }
        public Block SelectedBlock { get; set; }
        public Block LastSelectedBlock { get; set; }
        public Block EditingBlock { get; set; }
        public TextBox EditText { get; set; }
        public CoordinateTransformer Tr { get; set; }
        public int CurrentId { get; set; } = 1;
        public BlockManager(CoordinateTransformer transformer)
        {
            Tr = transformer;
            Blocks = new List<Block>();
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
                case 1: newBlock = new TerminatorBlock(X, Y, CurrentId); break;
                case 2: newBlock = new ParalelogramBlock(X, Y, CurrentId); break;
                case 3: newBlock = new RectangleBlock(X, Y, CurrentId); break;
                case 4: newBlock = new DiamondBlock(X, Y, CurrentId); break;
                case 5: newBlock = new HexagonBlock(X, Y, CurrentId); break;
                case 6: newBlock = new EllipseBlock(X, Y, CurrentId); break;
                case 7:
                    X = (Tr.STCX(x) - 10) - (Tr.STCX(x) - 10) % 10;
                    Y = (Tr.STCY(y) - 10) - (Tr.STCY(y) - 10) % 10;
                    newBlock = new TextBlock(X, Y, CurrentId); 
                    break;
            }
            CurrentId++;
            if (newBlock != null)
            {
                Blocks.Add(newBlock);
            }
        }

        public void DeleteBlock(Control canvas, List<Arrow> arrows)
        {
            if (arrows != null)
            {
                foreach (Arrow arrow in arrows)
                {
                    if (arrow.Bracing[0].Block == SelectedBlock)
                        arrow.Bracing[0] = (null, 0);
                    if (arrow.Bracing[1].Block == SelectedBlock)
                        arrow.Bracing[1] = (null, 0);
                }
            }
            Blocks.Remove(SelectedBlock);
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
                    Location = EditingBlock is TextBlock ?
                    new Point((int)Tr.CTSX(EditingBlock.X), (int)Tr.CTSY(EditingBlock.Y)) :
                    new Point((int)Tr.CTSX(EditingBlock.X + 5), (int)Tr.CTSY(EditingBlock.Y + 5)),

                    Size = EditingBlock is TextBlock ?
                    new Size((int)Tr.CTSS(EditingBlock.Width), (int)Tr.CTSS(EditingBlock.Height)) :
                    new Size((int)Tr.CTSS(EditingBlock.Width - 10), (int)Tr.CTSS(EditingBlock.Height - 10)),

                    BackColor = EditingBlock is TextBlock ?
                    Color.DarkGray : 
                    Color.White,

                    Text = EditingBlock.Text,
                    Multiline = true,
                    Font = new Font(EditingBlock.Font.FontFamily, (int)Tr.CTSS(EditingBlock.Font.Size)),

                    TextAlign = EditingBlock is TextBlock ? 
                    HorizontalAlignment.Left :
                    HorizontalAlignment.Center,
                    BorderStyle = BorderStyle.None,
                };
                canvas.Controls.Add(EditText);
            }
        }

        public void EndEditingText(Control canvas)
        {
            if (EditText != null && EditingBlock != null)
            {
                EditingBlock.Text = EditText.Text;
                canvas.Controls.Remove(EditText);
                EditText = null;

                if (EditingBlock is TextBlock textBlock)
                {
                    textBlock.ResizeByText();
                    if (string.IsNullOrWhiteSpace(textBlock.Text))
                    {
                        Blocks.Remove(textBlock);
                    }
                }
                
                EditingBlock = null;
            }
        }

        public void ResizeSelectedBlock(ResizeHandle handle, float canvasX, float canvasY)
        {
            if (SelectedBlock.Type == "TextBlock") return;

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

        public void Search(string str)
        {
            foreach (var block in Blocks)
            {
                if (!string.IsNullOrEmpty(block.Text) && !string.IsNullOrWhiteSpace(str) && block.Text.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    block.IsFound = true;
                }
                else
                {
                    block.IsFound = false;
                }
            }
        }

        public void UnsetSearch()
        {
            foreach (var block in Blocks)
                block.IsFound = false;
        }
    }
}

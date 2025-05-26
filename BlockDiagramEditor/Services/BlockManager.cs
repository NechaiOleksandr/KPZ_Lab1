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

        public void SelectBlock(int x, int y)
        {

            if (LastSelectedBlock != null && !LastSelectedBlock.Contains(x, y))
            {
                LastSelectedBlock.IsSelected = false;
            }
            SelectedBlock = Blocks.FirstOrDefault(block => block.Contains(x, y));
            if (SelectedBlock != null)
            {
                SelectedBlock.IsSelected = true;
                LastSelectedBlock = SelectedBlock;
            }
        }

        public void AddBlock(int model, int x, int y)
        {
            Block newBlock = null;
            switch (model)
            {
                case 1: newBlock = new TerminatorBlock(x, y); break;
                case 2: newBlock = new ParalelogramBlock(x, y); break;
                case 3: newBlock = new RectangleBlock(x, y); break;
                case 4: newBlock = new DiamondBlock(x, y); break;
                case 5: newBlock = new HexagonBlock(x, y); break;
                case 6: newBlock = new EllipseBlock(x, y); break;
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

        public void MoveBlock(int x, int y, Point offset)
        {
            if (SelectedBlock != null)
            {
                SelectedBlock.X = (x - offset.X) - (x - offset.X) % 10;
                SelectedBlock.Y = (y - offset.Y) - (y - offset.Y) % 10;
            }
        }

        public void StartEditingText(Control canvas, int x, int y)
        {
            EditingBlock = Blocks.LastOrDefault(block => block.Contains(x, y));
            if (EditingBlock != null)
            {
                EditText = new TextBox()
                {
                    Location = new Point(EditingBlock.X + 5, EditingBlock.Y + 5),
                    Size = new Size(EditingBlock.Width - 10, EditingBlock.Height - 10),
                    Text = EditingBlock.Text,
                    Multiline = true,
                    Font = EditingBlock.Font,
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
    }
}

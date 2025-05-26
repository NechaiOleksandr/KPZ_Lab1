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
        public float Scale { get; set; } = 1;
        public PointF CanvasOffset { get; set; } = new PointF(0, 0);

        public void SelectBlock(int x, int y)
        {
            if (LastSelectedBlock != null && !LastSelectedBlock.Contains((x - CanvasOffset.X) / Scale, (y - CanvasOffset.Y) / Scale))
            {
                LastSelectedBlock.IsSelected = false;
            }
            SelectedBlock = Blocks.LastOrDefault(block => block.Contains((x - CanvasOffset.X) / Scale, (y - CanvasOffset.Y) / Scale));
            if (SelectedBlock != null)
            {
                SelectedBlock.IsSelected = true;
                LastSelectedBlock = SelectedBlock;
            }
        }

        public void AddBlock(int model, int x, int y)
        {
            float X = ((x - CanvasOffset.X) / Scale - 80) - ((x - CanvasOffset.X) / Scale - 80) % 10;
            float Y = ((y - CanvasOffset.Y) / Scale - 40) - ((y - CanvasOffset.Y) / Scale - 40) % 10;
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
            EditingBlock = Blocks.LastOrDefault(block => block.Contains(x - CanvasOffset.X, y - CanvasOffset.Y));
            if (EditingBlock != null)
            {
                EditText = new TextBox()
                {
                    Location = new Point((int)((EditingBlock.X + 5) * Scale + CanvasOffset.X), (int)((EditingBlock.Y + 5) * Scale + CanvasOffset.Y)),
                    Size = new Size((int)((EditingBlock.Width - 10) * Scale), (int)((EditingBlock.Height - 10) * Scale)),
                    Text = EditingBlock.Text,
                    Multiline = true,
                    Font = new Font(EditingBlock.Font.FontFamily, EditingBlock.Font.Size * Scale),
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

        public void ChangeScale(int delta)
        {
            if (delta < 0 && Scale > 0.11)
            {
                Scale -= 0.1F;
                Scale = (float)Math.Round(Scale, 1);
            }
            else if (delta > 0 && Scale < 2.5)
            {
                Scale += 0.1F;
                Scale = (float)Math.Round(Scale, 1);
            }
        }
        
        //public PointF ToScreen(PointF logical)
        //{
        //    return new PointF(logical.X * Scale + CanvasOffset.X, logical.Y * Scale + CanvasOffset.Y);
        //}
        //public SizeF ToScreen(SizeF logicalSize)
        //{
        //    return new SizeF(logicalSize.Width * Scale, logicalSize.Height * Scale);
        //}
        //public PointF ToLogical(PointF screen)
        //{
        //    return new PointF((screen.X - CanvasOffset.X) / Scale, (screen.Y - CanvasOffset.Y) / Scale);
        //}
        //public SizeF ToLogical(SizeF screenSize)
        //{
        //    return new SizeF(screenSize.Width / Scale, screenSize.Height / Scale);
        //}
    }
}

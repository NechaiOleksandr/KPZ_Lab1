using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockDiagramEditor.Models;

namespace BlockDiagramEditor.Services
{
    public class BlockDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string Text { get; set; }
        public string FontFamily { get; set; }
        public float FontSize { get; set; }
        public string TextColor { get; set; }
        public string BorderColor { get; set; }
        public float BorderWidth { get; set; }
        public string FillColor { get; set; }

        public BlockDTO() { }

        public BlockDTO(Block block)
        {
            Id = block.Id;
            Type = block.Type;
            X = block.X;
            Y = block.Y;
            Width = block.Width;
            Height = block.Height;
            Text = block.Text;
            FontFamily = block.Font.FontFamily.Name;
            FontSize = block.Font.Size;
            TextColor = $"#{block.TextColor.Color.R:X2}{block.TextColor.Color.G:X2}{block.TextColor.Color.B:X2}";
            BorderColor = $"#{block.Border.Color.R:X2}{block.Border.Color.G:X2}{block.Border.Color.B:X2}";
            BorderWidth = block.Border.Width;
            FillColor = $"#{block.Brush.Color.R:X2}{block.Brush.Color.G:X2}{block.Brush.Color.B:X2}";
        }

        public Block ToBlock()
        {
            Block block;

            switch (Type)
            {
                case "TerminatorBlock":
                    block = new TerminatorBlock();
                    break;
                case "ParalelogramBlock":
                    block = new ParalelogramBlock();
                    break;
                case "RectangleBlock":
                    block = new RectangleBlock();
                    break;
                case "DiamondBlock":
                    block = new DiamondBlock();
                    break;
                case "HexagonBlock":
                    block = new HexagonBlock();
                    break;
                case "EllipseBlock":
                    block = new EllipseBlock();
                    break;
                case "TextBlock":
                    block = new TextBlock();
                    break;
                default:
                    throw new InvalidDataException($"Невідомий тип блоку: '{Type}'");
            }

            block.Id = Id;
            block.X = X;
            block.Y = Y;
            block.Width = Width;
            block.Height = Height;
            block.Text = Text;

            block.Font = new Font(FontFamily, FontSize);
            block.TextColor = new SolidBrush(ColorTranslator.FromHtml(TextColor));
            block.Border = new Pen(ColorTranslator.FromHtml(BorderColor), BorderWidth);
            block.Brush = new SolidBrush(ColorTranslator.FromHtml(FillColor));

            return block;
        }
    }
}
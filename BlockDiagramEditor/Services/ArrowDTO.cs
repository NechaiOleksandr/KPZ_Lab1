using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockDiagramEditor.Models;
using BlockDiagramEditor.Models.Arrows;
// using static System.Net.Mime.MediaTypeNames; // Цей using, ймовірно, не потрібен

namespace BlockDiagramEditor.Services
{
    public class ArrowDTO
    {
        public class BracingDTO
        {
            public int BlockId { get; set; }
            public int Side { get; set; }
        }

        public string Type { get; set; }
        public List<PointF> Points { get; set; }
        public string Color { get; set; }
        public float Width { get; set; }
        public List<BracingDTO> Bracing { get; set; }

        public ArrowDTO() { }

        public ArrowDTO(Arrow arrow)
        {
            Type = arrow.Type;
            Points = arrow.Points;
            Color = $"#{arrow.Pen.Color.R:X2}{arrow.Pen.Color.G:X2}{arrow.Pen.Color.B:X2}";
            Width = arrow.Pen.Width;
            Bracing = new List<BracingDTO>
            {
                new BracingDTO { BlockId = arrow.Bracing[0].Block.Id, Side = arrow.Bracing[0].Side },
                new BracingDTO { BlockId = arrow.Bracing[1].Block.Id, Side = arrow.Bracing[1].Side }
            };
        }

        public Arrow ToArrow(List<Block> blocks)
        {
            Arrow arrow;

            switch (Type)
            {
                case "ClassicArrow":
                    arrow = new ClassicArrow();
                    break;
                case "EmptyTrArrow":
                    arrow = new EmptyTrArrow();
                    break;
                case "FilledTrArrow":
                    arrow = new FilledTrArrow();
                    break;
                case "LineArrow":
                    arrow = new LineArrow();
                    break;
                case "TwoHeadedArrow":
                    arrow = new TwoHeadedArrow();
                    break;
                default:
                    throw new InvalidDataException($"Невідомий тип стрілки: '{Type}'");
            }

            arrow.Points = Points;
            arrow.Pen = new Pen(ColorTranslator.FromHtml(Color), Width);

            var startBlock = blocks.FirstOrDefault(b => b.Id == Bracing[0].BlockId);
            var endBlock = blocks.FirstOrDefault(b => b.Id == Bracing[1].BlockId);

            if (startBlock == null)
            {
                throw new InvalidDataException($"Стрілка посилається на неіснуючий блок з Id: {Bracing[0].BlockId}");
            }
            if (endBlock == null)
            {
                throw new InvalidDataException($"Стрілка посилається на неіснуючий блок з Id: {Bracing[1].BlockId}");
            }

            arrow.Bracing = new List<(Block Block, int Side)>
            {
                (startBlock, Bracing[0].Side),
                (endBlock, Bracing[1].Side),
            };

            return arrow;
        }
    }
}
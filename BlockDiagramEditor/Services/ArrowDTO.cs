using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockDiagramEditor.Models;
using BlockDiagramEditor.Models.Arrows;

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

            Bracing = new List<BracingDTO>();

            for (int i = 0; i < 2; i++)
            {
                if (arrow.Bracing != null && i < arrow.Bracing.Count && arrow.Bracing[i].Block != null)
                {
                    Bracing.Add(new BracingDTO
                    {
                        BlockId = arrow.Bracing[i].Block.Id,
                        Side = arrow.Bracing[i].Side
                    });
                }
                else
                {
                    Bracing.Add(new BracingDTO
                    {
                        BlockId = 0,
                        Side = 0
                    });
                }
            }
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

            var bracingList = new List<(Block Block, int Side)>();

            foreach (var b in Bracing)
            {
                if (b.BlockId == 0)
                {
                    bracingList.Add((null, 0));
                }
                else
                {
                    var block = blocks.FirstOrDefault(x => x.Id == b.BlockId);
                    if (block == null)
                    {
                        throw new InvalidDataException($"Стрілка посилається на неіснуючий блок з Id: {b.BlockId}");
                    }
                    bracingList.Add((block, b.Side));
                }
            }

            arrow.Bracing = bracingList;
            return arrow;
        }
    }
}
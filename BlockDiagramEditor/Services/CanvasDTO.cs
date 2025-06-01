using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDiagramEditor.Services
{
    public class CanvasDTO
    {
        public List<BlockDTO> Blocks { get; set; }
        public List<ArrowDTO> Arrows { get; set; }
    }
}

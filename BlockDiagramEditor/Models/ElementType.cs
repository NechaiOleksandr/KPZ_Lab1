using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockDiagramEditor.Models
{
    public enum ElementType
    {
        None,
        BlockTerminator,
        BlockParalelogram,
        BlockRectangle,
        BlockDiamond,
        BlockHexagon,
        BlockEllipse,
        BlockText,
        ArrowClassic,
        ArrowEmptyTr,
        ArrowFilledTr,
        ArrowLine,
        ArrowTwoHeaded
    }
}
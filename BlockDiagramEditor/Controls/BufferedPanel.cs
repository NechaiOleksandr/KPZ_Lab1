using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlockDiagramEditor.Controls
{
    public class BufferedPanel : Panel
    {
        public BufferedPanel()
        {
            DoubleBuffered = true;
        }
    }
}
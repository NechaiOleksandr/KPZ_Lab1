using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockDiagramEditor.Models;
using BlockDiagramEditor.Models.Arrows;

namespace BlockDiagramEditor.Services
{
    public class ArrowManager
    {
        public List<Arrow> Arrows { get; private set; } = new List<Arrow>();
        public Arrow SelectedArrow { get; set; }
        public Arrow LastSelectedArrow { get; set; }
        public CoordinateTransformer Tr { get; set; }
        public ArrowManager(CoordinateTransformer transformer)
        {
            Tr = transformer;
        }

        public void SelectArrow(int x, int y)
        {
            if (LastSelectedArrow != null && !LastSelectedArrow.Contains(Tr.STCX(x), Tr.STCY(y)))
            {
                LastSelectedArrow.IsSelected = false;
            }
            SelectedArrow = Arrows.LastOrDefault(arrow => arrow.Contains(Tr.STCX(x), Tr.STCY(y)));
            if (SelectedArrow != null)
            {
                SelectedArrow.IsSelected = true;
                LastSelectedArrow = SelectedArrow;
                Arrows.Remove(SelectedArrow);
                Arrows.Add(SelectedArrow);
            }
        }

        public void DeleteArrow(Control canvas)
        {
            Arrows.RemoveAll(arrow => arrow.IsSelected == true);
            SelectedArrow = null;
        }

        public void MoveArrow(float x, float y, PointF offset)
        {
            if (SelectedArrow != null)
            {
                float sx = SelectedArrow.StartX;
                float sy = SelectedArrow.StartY;

                SelectedArrow.StartX = (x - offset.X) - (x - offset.X) % 10;
                SelectedArrow.StartY = (y - offset.Y) - (y - offset.Y) % 10;
                SelectedArrow.EndX = SelectedArrow.StartX + (SelectedArrow.EndX - sx);
                SelectedArrow.EndY = SelectedArrow.StartY + (SelectedArrow.EndY - sy);
            }
        }

        public void AddArrow(int model, int x, int y)
        {
            float X = (Tr.STCX(x) - 50) - (Tr.STCX(x) - 50) % 10;
            float Y = (Tr.STCY(y) - 50) - (Tr.STCY(y) - 50) % 10;
            Arrow newArrow = null;
            switch (model)
            {
                case 1: newArrow = new Arrow(X, Y); break;
            }
            if (newArrow != null)
            {
                Arrows.Add(newArrow);
            }
        }
        public void ResizeSelectedArrow(int handle, float canvasX, float canvasY)
        {
            switch (handle)
            {
                case 0:
                    SelectedArrow.StartX = canvasX - canvasX % 10;
                    SelectedArrow.StartY = canvasY - canvasY % 10;
                    break;
                case 1:
                    SelectedArrow.EndX = canvasX - canvasX % 10;
                    SelectedArrow.EndY = canvasY - canvasY % 10;
                    break;
            }
        }
    }
}

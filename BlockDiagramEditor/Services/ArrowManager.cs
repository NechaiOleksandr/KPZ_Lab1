using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
                PointF oldStart = SelectedArrow.Points[0];
                float dx = ((x - offset.X) - ((x - offset.X) % 5)) - oldStart.X;
                float dy = ((y - offset.Y) - ((y - offset.Y) % 5)) - oldStart.Y;

                for (int i = 0; i < SelectedArrow.Points.Count; i++)
                {
                    PointF p = SelectedArrow.Points[i];
                    SelectedArrow.Points[i] = new PointF(p.X + dx, p.Y + dy);
                }
            }
        }

        public void AddArrow(int model, int x, int y)
        {
            float X = (Tr.STCX(x) - 50) - (Tr.STCX(x) - 50) % 5;
            float Y = (Tr.STCY(y) - 50) - (Tr.STCY(y) - 50) % 5;
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
            SelectedArrow.Points[handle] = new PointF(canvasX - canvasX % 5, canvasY - canvasY % 5);
        }

        public void AddPointToSelectedArrow(int handle, float canvasX, float canvasY)
        {
            SelectedArrow.Points.Insert(handle + 1, new PointF(canvasX - canvasX % 5, canvasY - canvasY % 5));
        }

        public void Connect(List<Block> blocks, int handle)
        {
            if (handle == 0 || handle == SelectedArrow.Points.Count - 1)
            {

                int arrowSide = handle == 0 ? 0 : 1;
                SelectedArrow.Bracing[arrowSide] = (null, 0);

                foreach (var block in blocks)
                {
                    if (block.Contains(SelectedArrow.Points[handle].X, SelectedArrow.Points[handle].Y))
                    {
                        if (SelectedArrow.Points[handle].X == block.X + block.Width / 2)
                        {
                            if (SelectedArrow.Points[handle].Y == block.Y)
                            {
                                SelectedArrow.Bracing[arrowSide] = (block, 1);
                                break;
                            }
                            else if (SelectedArrow.Points[handle].Y == block.Y + block.Height)
                            {
                                SelectedArrow.Bracing[arrowSide] = (block, 3);
                                break;
                            }
                        }
                        else if (SelectedArrow.Points[handle].Y == block.Y + block.Height / 2)
                        {
                            if (SelectedArrow.Points[handle].X == block.X)
                            {
                                SelectedArrow.Bracing[arrowSide] = (block, 4);
                                break;
                            }
                            else if (SelectedArrow.Points[handle].X == block.X + block.Width)
                            {
                                SelectedArrow.Bracing[arrowSide] = (block, 2);
                                break;
                            }
                        }
                    }
                }
            }
            else if (handle == -1)
            {
                SelectedArrow.Bracing[0] = (null, 0);
                SelectedArrow.Bracing[1] = (null, 0);
            }
        }

        public void ResizeArrowsByBracing()
        {
            foreach (var arrow in Arrows)
            {
                if (arrow.Bracing[0] != (null, 0))
                {
                    if (arrow.Bracing[0].Side == 1)
                    {
                        arrow.Points[0] = new PointF(
                            arrow.Bracing[0].Block.X + arrow.Bracing[0].Block.Width / 2,
                            arrow.Bracing[0].Block.Y);
                    }
                    else if (arrow.Bracing[0].Side == 2)
                    {
                        arrow.Points[0] = new PointF(
                            arrow.Bracing[0].Block.X + arrow.Bracing[0].Block.Width,
                            arrow.Bracing[0].Block.Y + arrow.Bracing[0].Block.Height / 2);
                    }
                    else if (arrow.Bracing[0].Side == 3)
                    {
                        arrow.Points[0] = new PointF(
                            arrow.Bracing[0].Block.X + arrow.Bracing[0].Block.Width / 2,
                            arrow.Bracing[0].Block.Y + arrow.Bracing[0].Block.Height);
                    }
                    else if (arrow.Bracing[0].Side == 4)
                    {
                        arrow.Points[0] = new PointF(
                            arrow.Bracing[0].Block.X,
                            arrow.Bracing[0].Block.Y + arrow.Bracing[0].Block.Height / 2);
                    }
                }
                if (arrow.Bracing[1] != (null, 0))
                {
                    if (arrow.Bracing[1].Side == 1)
                    {
                        arrow.Points[arrow.Points.Count - 1] = new PointF(
                            arrow.Bracing[1].Block.X + arrow.Bracing[1].Block.Width / 2,
                            arrow.Bracing[1].Block.Y);
                    }
                    else if (arrow.Bracing[1].Side == 2)
                    {
                        arrow.Points[arrow.Points.Count - 1] = new PointF(
                            arrow.Bracing[1].Block.X + arrow.Bracing[1].Block.Width,
                            arrow.Bracing[1].Block.Y + arrow.Bracing[1].Block.Height / 2);
                    }
                    else if (arrow.Bracing[1].Side == 3)
                    {
                        arrow.Points[arrow.Points.Count - 1] = new PointF(
                            arrow.Bracing[1].Block.X + arrow.Bracing[1].Block.Width / 2,
                            arrow.Bracing[1].Block.Y + arrow.Bracing[1].Block.Height);
                    }
                    else if (arrow.Bracing[1].Side == 4)
                    {
                        arrow.Points[arrow.Points.Count - 1] = new PointF(
                            arrow.Bracing[1].Block.X,
                            arrow.Bracing[1].Block.Y + arrow.Bracing[1].Block.Height / 2);
                    }
                }
            }
        }
    }
}

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
        public List<Arrow> Arrows { get; private set; }
        public Arrow SelectedArrow { get; set; }
        public Arrow LastSelectedArrow { get; set; }
        public CoordinateTransformer Tr { get; set; }
        public ArrowManager(CoordinateTransformer transformer)
        {
            Tr = transformer;
            Arrows = new List<Arrow>();
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
                case 1: newArrow = new ClassicArrow(X, Y); break;
                case 2: newArrow = new EmptyTrArrow(X, Y); break;
                case 3: newArrow = new FilledTrArrow(X, Y); break;
                case 4: newArrow = new LineArrow(X, Y); break;
                    case 5: newArrow = new TwoHeadedArrow(X, Y); break;
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
            if (SelectedArrow == null) return;

            if (handle == 0 || (SelectedArrow.Points.Any() && handle == SelectedArrow.Points.Count - 1))
            {
                int currentArrowSideIndex = (handle == 0) ? 0 : 1;
                SelectedArrow.Bracing[currentArrowSideIndex] = (null, 0);

                PointF pointToConnect = SelectedArrow.Points[handle];
                RectangleF Top, Right, Bottom, Left;

                foreach (var block in blocks)
                {
                    Top = new RectangleF(block.X + block.Width / 2 - 5, block.Y - 5, 11, 11);
                    Bottom = new RectangleF(block.X + block.Width / 2 - 5, block.Y + block.Height - 5, 11, 11);
                    if (block.Type != "ParalelogramBlock")
                    {
                        Left = new RectangleF(block.X - 5, block.Y + block.Height / 2 - 5, 11, 11);
                        Right = new RectangleF(block.X + block.Width - 5, block.Y + block.Height / 2 - 5, 11, 11);
                    }
                    else
                    {
                        Left = new RectangleF(block.X + block.Width / 16 - 5, block.Y + block.Height / 2 - 5, 11, 11);
                        Right = new RectangleF(block.X + block.Width - block.Width / 16 - 5, block.Y + block.Height / 2 - 5, 11, 11);
                    }

                    if (Top.Contains(pointToConnect))
                    {
                        SelectedArrow.Bracing[currentArrowSideIndex] = (block, 1);
                        break;
                    }
                    else if (Right.Contains(pointToConnect))
                    {
                        SelectedArrow.Bracing[currentArrowSideIndex] = (block, 2);
                        break;
                    }
                    else if (Bottom.Contains(pointToConnect))
                    {
                        SelectedArrow.Bracing[currentArrowSideIndex] = (block, 3);
                        break;
                    }
                    else if (Left.Contains(pointToConnect))
                    {
                        SelectedArrow.Bracing[currentArrowSideIndex] = (block, 4);
                        break;
                    }
                }
            }
            else if (handle == -1)
            {
                if (SelectedArrow.Bracing[0].Block != null)
                {
                    Block block = SelectedArrow.Bracing[0].Block;
                    int side = SelectedArrow.Bracing[0].Side;
                    PointF currentPoint = SelectedArrow.Points[0];
                    bool detach = false;

                    PointF expectedPoint = PointF.Empty;
                    switch (side)
                    {
                        case 1: expectedPoint = new PointF(block.X + block.Width / 2, block.Y); break;
                        case 2:
                            expectedPoint = (block.Type != "ParalelogramBlock") ?
                                        new PointF(block.X + block.Width, block.Y + block.Height / 2) :
                                        new PointF(block.X + block.Width - block.Width / 16, block.Y + block.Height / 2); break;
                        case 3: expectedPoint = new PointF(block.X + block.Width / 2, block.Y + block.Height); break;
                        case 4:
                            expectedPoint = (block.Type != "ParalelogramBlock") ?
                                        new PointF(block.X, block.Y + block.Height / 2) :
                                        new PointF(block.X + block.Width / 16, block.Y + block.Height / 2); break;
                    }

                    if (currentPoint != expectedPoint)
                    {
                        detach = true;
                    }

                    if (detach)
                    {
                        SelectedArrow.Bracing[0] = (null, 0);
                    }
                }

                if (SelectedArrow.Bracing[1].Block != null)
                {
                    Block block = SelectedArrow.Bracing[1].Block;
                    int side = SelectedArrow.Bracing[1].Side;
                    PointF currentPoint = SelectedArrow.Points[SelectedArrow.Points.Count - 1];
                    bool detach = false;

                    PointF expectedPoint = PointF.Empty;
                    switch (side)
                    {
                        case 1: expectedPoint = new PointF(block.X + block.Width / 2, block.Y); break;
                        case 2:
                            expectedPoint = (block.Type != "ParalelogramBlock") ?
                                        new PointF(block.X + block.Width, block.Y + block.Height / 2) :
                                        new PointF(block.X + block.Width - block.Width / 16, block.Y + block.Height / 2); break;
                        case 3: expectedPoint = new PointF(block.X + block.Width / 2, block.Y + block.Height); break;
                        case 4:
                            expectedPoint = (block.Type != "ParalelogramBlock") ?
                                        new PointF(block.X, block.Y + block.Height / 2) :
                                        new PointF(block.X + block.Width / 16, block.Y + block.Height / 2); break;
                    }

                    if (currentPoint != expectedPoint)
                    {
                        detach = true;
                    }

                    if (detach)
                    {
                        SelectedArrow.Bracing[1] = (null, 0);
                    }
                }
            }
        }

        public void ResizeArrowsByBracing()
        {
            foreach (var arrow in Arrows)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (arrow.Bracing[i] == (null, 0)) continue;

                    int pointIndex = i == 0 ? 0 : arrow.Points.Count - 1;
                    PointF newPoint;
                    switch (arrow.Bracing[i].Side)
                    {
                        case 1:
                            newPoint = new PointF(
                                arrow.Bracing[i].Block.X + arrow.Bracing[i].Block.Width / 2,
                                arrow.Bracing[i].Block.Y);
                            break;
                        case 2:
                            if (arrow.Bracing[i].Block.Type != "ParalelogramBlock")
                            {
                                newPoint = new PointF(
                                    arrow.Bracing[i].Block.X + arrow.Bracing[i].Block.Width,
                                    arrow.Bracing[i].Block.Y + arrow.Bracing[i].Block.Height / 2);
                            }
                            else
                            {
                                newPoint = new PointF(
                                    arrow.Bracing[i].Block.X + arrow.Bracing[i].Block.Width - arrow.Bracing[i].Block.Width / 16,
                                    arrow.Bracing[i].Block.Y + arrow.Bracing[i].Block.Height / 2);
                            }
                            break;
                        case 3:
                            newPoint = new PointF(
                                arrow.Bracing[i].Block.X + arrow.Bracing[i].Block.Width / 2,
                                arrow.Bracing[i].Block.Y + arrow.Bracing[i].Block.Height);
                            break;
                        case 4:
                            if (arrow.Bracing[i].Block.Type != "ParalelogramBlock")
                            {
                                newPoint = new PointF(
                                arrow.Bracing[i].Block.X,
                                arrow.Bracing[i].Block.Y + arrow.Bracing[i].Block.Height / 2);
                            } else
                            {
                                newPoint = new PointF(
                                    arrow.Bracing[i].Block.X + arrow.Bracing[i].Block.Width / 16,
                                    arrow.Bracing[i].Block.Y + arrow.Bracing[i].Block.Height / 2);
                            }
                            break;
                        default:
                            continue;
                    }
                    arrow.Points[pointIndex] = newPoint;
                }
            }
        }

    }
}

#region Using directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
#endregion

namespace RectangleBinPack
{
    public class SkylineBinPack : BinPack1
    {
        /// Instantiates a bin of size (0,0). Call Init to create a new bin.
        public SkylineBinPack() : base()
        {
        }
        /// Instantiates a bin of the given size.
        public SkylineBinPack(int binWidth, int binHeight)
            : base(binWidth, binHeight)
        {
        }
        /// (Re)initializes the packer to an empty bin of width x height units. Call whenever
        /// you need to restart with a new bin.
        public override void Init(int width, int height)
        {
            base.Init(width, height);

            disjointRects.Clear();

            skyLine.Clear();
            SkylineNode node;
            node.x = 0;
            node.y = 0;
            node.width = BinWidth;
            skyLine.Add(node);

            if (UseWasteMap)
            {
                wasteMap.Init(width, height);
                wasteMap.FreeRectangles.Clear();
            }
        }
        /// Defines the different heuristic rules that can be used to decide how to make the rectangle placements.
        public enum LevelChoiceHeuristic
        {
            LevelBottomLeft,
            LevelMinWasteFit
        };

        public class Option : GenericOption
        {
            public LevelChoiceHeuristic Method { get; set; }
        }

        /// Inserts the given list of rectangles in an offline/batch mode, possibly rotated.
        /// @param rects The list of rectangles to insert. This vector will be destroyed in the process.
        /// @param dst [out] This list will contain the packed rectangles. The indices will not correspond to that of rects.
        /// @param method The rectangle placement rule to use when packing.
        public void Insert(List<RectSize> rects, ref List<Rect> dst, LevelChoiceHeuristic method)
        {
            dst.Clear();

            while (rects.Count > 0)
            {
                Rect bestNode = new Rect();
                int bestScore1 = int.MaxValue;
                int bestScore2 = int.MaxValue;
                int bestSkylineIndex = -1;
                int bestRectIndex = -1;
                for (int i = 0; i < rects.Count; ++i)
                {
                    Rect newNode = new Rect();
                    int score1 = 0;
                    int score2 = 0;
                    int index = 0;
                    switch (method)
                    {
                        case LevelChoiceHeuristic.LevelBottomLeft:
                            newNode = FindPositionForNewNodeBottomLeft(rects[i].Width, rects[i].Height, ref score1, ref score2, ref index);
                            Debug.Assert(disjointRects.Disjoint(newNode));
                            break;
                        case LevelChoiceHeuristic.LevelMinWasteFit:
                            newNode = FindPositionForNewNodeMinWaste(rects[i].Width, rects[i].Height, ref score2, ref score1, ref index);
                            Debug.Assert(disjointRects.Disjoint(newNode));
                            break;
                        default:
                            Debug.Assert(false);
                            break;
                    }

                    if (newNode.Height != 0)
                    {
                        if (score1 < bestScore1 || (score1 == bestScore1 && score2 < bestScore2))
                        {
                            bestNode = newNode;
                            bestScore1 = score1;
                            bestScore2 = score2;
                            bestSkylineIndex = index;
                            bestRectIndex = i;
                        }
                    }
                }

                if (bestRectIndex == -1)
                    return;

                // Perform the actual packing.
                Debug.Assert(disjointRects.Disjoint(bestNode));
                disjointRects.Add(bestNode);
                AddSkylineLevel(bestSkylineIndex, ref bestNode);
                IncrementUsedArea( rects[bestRectIndex].Width * rects[bestRectIndex].Height );
                rects.RemoveAt(bestRectIndex);
                dst.Add(bestNode);
            }
        }

        /// Inserts a single rectangle into the bin, possibly rotated.
        public override Rect Insert(RectSize rectSize, GenericOption option)
        {
            int width = rectSize.Width;
            int height = rectSize.Height;
            // First try to pack this rectangle into the waste map, if it fits.
            Rect node = wasteMap.Insert(rectSize, new GuillotineBinPack.Option()
            {
                Merge = true,
                FreeRectChoice = GuillotineBinPack.FreeRectChoiceHeuristic.RectBestShortSideFit,
                GuillotineSplit = GuillotineBinPack.GuillotineSplitHeuristic.SplitMaximizeArea
            });
            Debug.Assert(disjointRects.Disjoint(node));

            if (node.Height != 0)
            {
                Rect newNode = new Rect();
                newNode.X = node.X;
                newNode.Y = node.Y;
                newNode.Width = node.Width;
                newNode.Height = node.Height;
                IncrementUsedArea( width * height );
                Debug.Assert(disjointRects.Disjoint(newNode));
                disjointRects.Add(newNode);
                return newNode;
            }

            Option opt = option as Option;
            switch (opt.Method)
            {
                case LevelChoiceHeuristic.LevelBottomLeft: return InsertBottomLeft(width, height);
                case LevelChoiceHeuristic.LevelMinWasteFit: return InsertMinWaste(width, height);
                default: Debug.Assert(false); return node;
            }
        }

        private DisjointRectCollection disjointRects = new DisjointRectCollection();

        /// Represents a single level (a horizontal line) of the skyline/horizon/envelope.
        struct SkylineNode
        {
            /// The starting x-coordinate (leftmost).
            public int x;
            /// The y-coordinate of the skyline level line.
            public int y;
            /// The line width. The ending coordinate (inclusive) will be x+width-1.
            public int width;
        };

        private readonly List<SkylineNode> skyLine = new List<SkylineNode>();

        /// If true, we use the GuillotineBinPack structure to recover wasted areas into a waste map.
        public bool UseWasteMap { get; set; } = true;
        private GuillotineBinPack wasteMap = new GuillotineBinPack();

        private Rect InsertBottomLeft(int width, int height)
        {
            int bestHeight = 0;
            int bestWidth = 0;
            int bestIndex = 0;
            Rect newNode = FindPositionForNewNodeBottomLeft(width, height, ref bestHeight, ref bestWidth, ref bestIndex);

            if (bestIndex != -1)
            {
                Debug.Assert(disjointRects.Disjoint(newNode));

                // Perform the actual packing.
                AddSkylineLevel(bestIndex, ref newNode);

                IncrementUsedArea( width * height ); 
                disjointRects.Add(newNode);
            }
            else
                newNode = new Rect();

            return newNode;
        }
        private Rect InsertMinWaste(int width, int height)
        {
            int bestHeight = 0;
            int bestWastedArea = 0;
            int bestIndex = 0;
            Rect newNode = FindPositionForNewNodeMinWaste(width, height, ref bestHeight, ref bestWastedArea, ref bestIndex);

            if (bestIndex != -1)
            {
                Debug.Assert(disjointRects.Disjoint(newNode));

                // Perform the actual packing.
                AddSkylineLevel(bestIndex, ref newNode);

                IncrementUsedArea( width * height );
                disjointRects.Add(newNode);
            }
            else
                newNode = new Rect();
            return newNode;
        }

        private Rect FindPositionForNewNodeMinWaste(int width, int height, ref int bestHeight, ref int bestWastedArea, ref int bestIndex)
        {
            bestHeight = int.MaxValue;
            bestWastedArea = int.MaxValue;
            bestIndex = -1;
            Rect newNode = new Rect();
            for (int i = 0; i < skyLine.Count; ++i)
            {
                int y = 0;
                int wastedArea = 0;

                if (RectangleFits(i, width, height, ref y, ref wastedArea))
                {
                    if (wastedArea < bestWastedArea || (wastedArea == bestWastedArea && y + height < bestHeight))
                    {
                        bestHeight = y + height;
                        bestWastedArea = wastedArea;
                        bestIndex = i;
                        newNode.X = skyLine[i].x;
                        newNode.Y = y;
                        newNode.Width = width;
                        newNode.Height = height;
                        Debug.Assert(disjointRects.Disjoint(newNode));
                    }
                }
                if (RectangleFits(i, height, width, ref y, ref wastedArea))
                {
                    if (wastedArea < bestWastedArea || (wastedArea == bestWastedArea && y + width < bestHeight))
                    {
                        bestHeight = y + width;
                        bestWastedArea = wastedArea;
                        bestIndex = i;
                        newNode.X = skyLine[i].x;
                        newNode.Y = y;
                        newNode.Width = height;
                        newNode.Height = width;
                        Debug.Assert(disjointRects.Disjoint(newNode));
                    }
                }
            }
            return newNode;
        }
        private Rect FindPositionForNewNodeBottomLeft(int width, int height, ref int bestHeight, ref int bestWidth, ref int bestIndex)
        {
            bestHeight = int.MaxValue;
            bestIndex = -1;
            // Used to break ties if there are nodes at the same level. Then pick the narrowest one.
            bestWidth = int.MaxValue;
            Rect newNode = new Rect();

            for (int i = 0; i < skyLine.Count; ++i)
            {
                int y = 0;
                if (RectangleFits(i, width, height, ref y))
                {
                    if (y + height < bestHeight || (y + height == bestHeight && skyLine[i].width < bestWidth))
                    {
                        bestHeight = y + height;
                        bestIndex = i;
                        bestWidth = skyLine[i].width;
                        newNode.X = skyLine[i].x;
                        newNode.Y = y;
                        newNode.Width = width;
                        newNode.Height = height;
                        Debug.Assert(disjointRects.Disjoint(newNode));
                    }
                }
                if (RectangleFits(i, height, width, ref y))
                {
                    if (y + width < bestHeight || (y + width == bestHeight && skyLine[i].width < bestWidth))
                    {
                        bestHeight = y + width;
                        bestIndex = i;
                        bestWidth = skyLine[i].width;
                        newNode.X = skyLine[i].x;
                        newNode.Y = y;
                        newNode.Width = height;
                        newNode.Height = width;
                        Debug.Assert(disjointRects.Disjoint(newNode));
                    }
                }
            }
            return newNode;
        }

        private bool RectangleFits(int skylineNodeIndex, int width, int height, ref int y)
        {
            int x = skyLine[skylineNodeIndex].x;
            if (x + width > BinWidth)
                return false;
            int widthLeft = width;
            int i = skylineNodeIndex;
            y = skyLine[skylineNodeIndex].y;
            while (widthLeft > 0)
            {
                y = Math.Max(y, skyLine[i].y);
                if (y + height > BinHeight)
                    return false;
                widthLeft -= skyLine[i].width;
                ++i;
                Debug.Assert(i < (int)skyLine.Count || widthLeft <= 0);
            }
            return true;
        }
        private bool RectangleFits(int skylineNodeIndex, int width, int height, ref int y, ref int wastedArea)
        {
            bool fits = RectangleFits(skylineNodeIndex, width, height, ref y);
            if (fits)
                wastedArea = ComputeWastedArea(skylineNodeIndex, width, height, y);
            return fits;
        }
        private int ComputeWastedArea(int skylineNodeIndex, int width, int height, int y)
        {
            int wastedArea = 0;
            int rectLeft = skyLine[skylineNodeIndex].x;
            int rectRight = rectLeft + width;
            for (; skylineNodeIndex < (int)skyLine.Count && skyLine[skylineNodeIndex].x < rectRight; ++skylineNodeIndex)
            {
                if (skyLine[skylineNodeIndex].x >= rectRight || skyLine[skylineNodeIndex].x + skyLine[skylineNodeIndex].width <= rectLeft)
                    break;

                int leftSide = skyLine[skylineNodeIndex].x;
                int rightSide = Math.Min(rectRight, leftSide + skyLine[skylineNodeIndex].width);
                Debug.Assert(y >= skyLine[skylineNodeIndex].y);
                wastedArea += (rightSide - leftSide) * (y - skyLine[skylineNodeIndex].y);
            }
            return wastedArea;
        }
        private void AddWasteMapArea(int skylineNodeIndex, int width, int height, int y)
        {
            // int wastedArea = 0; // unused
            int rectLeft = skyLine[skylineNodeIndex].x;
            int rectRight = rectLeft + width;
            for (; skylineNodeIndex < (int)skyLine.Count && skyLine[skylineNodeIndex].x < rectRight; ++skylineNodeIndex)
            {
                if (skyLine[skylineNodeIndex].x >= rectRight || skyLine[skylineNodeIndex].x + skyLine[skylineNodeIndex].width <= rectLeft)
                    break;

                int leftSide = skyLine[skylineNodeIndex].x;
                int rightSide = Math.Min(rectRight, leftSide + skyLine[skylineNodeIndex].width);
                Debug.Assert(y >= skyLine[skylineNodeIndex].y);

                Rect waste = new Rect();
                waste.X = leftSide;
                waste.Y = skyLine[skylineNodeIndex].y;
                waste.Width = rightSide - leftSide;
                waste.Height = y - skyLine[skylineNodeIndex].y;

                Debug.Assert(disjointRects.Disjoint(waste));
                wasteMap.FreeRectangles.Add(waste);
            }
        }

        private void AddSkylineLevel(int skylineNodeIndex, ref Rect rect)
        {
            // First track all wasted areas and mark them into the waste map if we're using one.
            if (UseWasteMap)
                AddWasteMapArea(skylineNodeIndex, rect.Width, rect.Height, rect.Y);

            SkylineNode newNode;
            newNode.x = rect.X;
            newNode.y = rect.Y + rect.Height;
            newNode.width = rect.Width;
            skyLine.Insert(skylineNodeIndex, newNode);

            Debug.Assert(newNode.x + newNode.width <= BinWidth);
            Debug.Assert(newNode.y <= BinHeight);

            for (int i = skylineNodeIndex + 1; i < skyLine.Count; ++i)
            {
                Debug.Assert(skyLine[i - 1].x <= skyLine[i].x);

                if (skyLine[i].x < skyLine[i - 1].x + skyLine[i - 1].width)
                {
                    int shrink = skyLine[i - 1].x + skyLine[i - 1].width - skyLine[i].x;

                    var skylineNodeNew = new SkylineNode()
                    {
                        x = skyLine[i].x + shrink,
                        y = skyLine[i].y,
                        width = skyLine[i].width - shrink
                    };

                    skyLine[i] = skylineNodeNew;

                    if (skyLine[i].width <= 0)
                    {
                        skyLine.RemoveAt(i);
                        --i;
                    }
                    else
                        break;
                }
                else
                    break;
            }
            MergeSkylines();
        }

        /// Merges all skyline nodes that are at the same level.
        private void MergeSkylines()
        {
            for (int i = 0; i < skyLine.Count - 1; ++i)
                if (skyLine[i].y == skyLine[i + 1].y)
                {
                    var skylineNewNode = new SkylineNode()
                    {
                        x = skyLine[i].x,
                        y = skyLine[i].y,
                        width = skyLine[i].width + skyLine[i + 1].width
                    };
                    skyLine[i] = skylineNewNode;
                    skyLine.RemoveAt(i + 1);
                    --i;
                }
        }
    }
}

#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace RectangleBinPack
{
    public class GuillotineBinPack : BinPack2
    {
        /// The initial bin size will be (0,0). Call Init to set the bin size.
        public GuillotineBinPack() : base()
        {
        }
        /// Initializes a new bin of the given size.
        public GuillotineBinPack(int width, int height) : base(width, height)
        {
        }
        /// (Re)initializes the packer to an empty bin of width x height units. Call whenever
        /// you need to restart with a new bin.
        public override void Init(int width, int height)
        {
            base.Init(width, height);
            disjointRects.Clear();

            // We start with a single big free rectangle that spans the whole bin.
            freeRectangles.Clear();
            freeRectangles.Add(new Rect() { X = 0, Y = 0, Width = width, Height = height });
        }

        /// Specifies the different choice heuristics that can be used when deciding which of the free subrectangles
        /// to place the to-be-packed rectangle into.
        public enum FreeRectChoiceHeuristic
        {
            RectBestAreaFit, ///< -BAF
			RectBestShortSideFit, ///< -BSSF
			RectBestLongSideFit, ///< -BLSF
			RectWorstAreaFit, ///< -WAF
			RectWorstShortSideFit, ///< -WSSF
			RectWorstLongSideFit ///< -WLSF
		};

        /// Specifies the different choice heuristics that can be used when the packer needs to decide whether to
        /// subdivide the remaining free space in horizontal or vertical direction.
        public enum GuillotineSplitHeuristic
        {
            SplitShorterLeftoverAxis, ///< -SLAS
			SplitLongerLeftoverAxis, ///< -LLAS
			SplitMinimizeArea, ///< -MINAS, Try to make a single big rectangle at the expense of making the other small.
			SplitMaximizeArea, ///< -MAXAS, Try to make both remaining rectangles as even-sized as possible.
			SplitShorterAxis, ///< -SAS
			SplitLongerAxis ///< -LAS
		};
        public class Option : GenericOption
        {
            public bool Merge { get; set; }
            public FreeRectChoiceHeuristic FreeRectChoice { get; set; }
            public GuillotineSplitHeuristic GuillotineSplit { get; set; }
        }

        /// Inserts a single rectangle into the bin. The packer might rotate the rectangle, in which case the returned
        /// struct will have the width and height values swapped.
        /// @param merge If true, performs free Rectangle Merge procedure after packing the new rectangle. This procedure
        ///		tries to defragment the list of disjoint free rectangles to improve packing performance, but also takes up 
        ///		some extra time.
        /// @param rectChoice The free rectangle choice heuristic rule to use.
        /// @param splitMethod The free rectangle split heuristic rule to use.
        public override Rect Insert(RectSize rectSize, GenericOption option)
        {
            var opt = option as Option;
            int width = rectSize.Width;
            int height = rectSize.Height;

            // Find where to put the new rectangle.
            int freeNodeIndex = 0;
            Rect newRect = FindPositionForNewNode(width, height, opt.FreeRectChoice, ref freeNodeIndex);

            // Abort if we didn't have enough space in the bin.
            if (newRect.Height == 0)
                return newRect;

            // Remove the space that was just consumed by the new rectangle.
            SplitFreeRectByHeuristic(freeRectangles[freeNodeIndex], newRect, opt.GuillotineSplit);
            freeRectangles.RemoveAt(freeNodeIndex);

            // Perform a Rectangle Merge step if desired.
            if (opt.Merge)
                MergeFreeList();

            // Remember the new used rectangle.
            UsedRectangles.Add(newRect);

            // Check that we're really producing correct packings here.
            disjointRects.Add(newRect);
            return newRect;
        }

        /// Inserts a list of rectangles into the bin.
        /// @param rects The list of rectangles to add. This list will be destroyed in the packing process.
        /// @param merge If true, performs Rectangle Merge operations during the packing process.
        /// @param rectChoice The free rectangle choice heuristic rule to use.
        /// @param splitMethod The free rectangle split heuristic rule to use.
        public void Insert(List<RectSize> rects, bool merge,
            FreeRectChoiceHeuristic rectChoice, GuillotineSplitHeuristic splitMethod)
        {
            // Remember variables about the best packing choice we have made so far during the iteration process.
            int bestFreeRect = 0;
            int bestRect = 0;
            bool bestFlipped = false;

            // Pack rectangles one at a time until we have cleared the rects array of all rectangles.
            // rects will get destroyed in the process.
            while (rects.Count > 0)
            {
                // Stores the penalty score of the best rectangle placement - bigger=worse, smaller=better.
                int bestScore = int.MaxValue;

                for (int i = 0; i < freeRectangles.Count; ++i)
                {
                    for (int j = 0; j < rects.Count; ++j)
                    {
                        // If this rectangle is a perfect match, we pick it instantly.
                        if (rects[j].Width == freeRectangles[i].Width && rects[j].Height == freeRectangles[i].Height)
                        {
                            bestFreeRect = i;
                            bestRect = j;
                            bestFlipped = false;
                            bestScore = int.MinValue;
                            i = freeRectangles.Count; // Force a jump out of the outer loop as well - we got an instant fit.
                            break;
                        }
                        // If flipping this rectangle is a perfect match, pick that then.
                        else if (rects[j].Height == freeRectangles[i].Width && rects[j].Width == freeRectangles[i].Height)
                        {
                            bestFreeRect = i;
                            bestRect = j;
                            bestFlipped = true;
                            bestScore = int.MinValue;
                            i = freeRectangles.Count; // Force a jump out of the outer loop as well - we got an instant fit.
                            break;
                        }
                        // Try if we can fit the rectangle upright.
                        else if (rects[j].Width <= freeRectangles[i].Width && rects[j].Height <= freeRectangles[i].Height)
                        {
                            int score = ScoreByHeuristic(rects[j].Width, rects[j].Height, freeRectangles[i], rectChoice);
                            if (score < bestScore)
                            {
                                bestFreeRect = i;
                                bestRect = j;
                                bestFlipped = false;
                                bestScore = score;
                            }
                        }
                        // If not, then perhaps flipping sideways will make it fit?
                        else if (rects[j].Height <= freeRectangles[i].Width && rects[j].Width <= freeRectangles[i].Height)
                        {
                            int score = ScoreByHeuristic(rects[j].Height, rects[j].Width, freeRectangles[i], rectChoice);
                            if (score < bestScore)
                            {
                                bestFreeRect = i;
                                bestRect = j;
                                bestFlipped = true;
                                bestScore = score;
                            }
                        }
                    }
                }

                // If we didn't manage to find any rectangle to pack, abort.
                if (bestScore == int.MaxValue)
                    return;

                // Otherwise, we're good to go and do the actual packing.
                Rect newNode = new Rect
                {
                    X = freeRectangles[bestFreeRect].X,
                    Y = freeRectangles[bestFreeRect].Y,
                    Width = rects[bestRect].Width,
                    Height = rects[bestRect].Height
                };

                if (bestFlipped)
                {
                    var temp = newNode.Width;
                    newNode.Width = newNode.Height;
                    newNode.Height = temp;
                }

                // Remove the free space we lost in the bin.
                SplitFreeRectByHeuristic(freeRectangles[bestFreeRect], newNode, splitMethod);
                freeRectangles.RemoveAt(bestFreeRect);

                // Remove the rectangle we just packed from the input list.
                rects.RemoveAt(bestRect);

                // Perform a Rectangle Merge step if desired.
                if (merge)
                    MergeFreeList();

                // Remember the new used rectangle.
                UsedRectangles.Add(newNode);

                // Check that we're really producing correct packings here.
                disjointRects.Add(newNode);
            }
        }

        // Implements GUILLOTINE-MAXFITTING, an experimental heuristic that's really cool but didn't quite work in practice.
        //	void InsertMaxFitting(std::vector<RectSize> &rects, std::vector<Rect> &dst, bool merge, 
        //		FreeRectChoiceHeuristic rectChoice, GuillotineSplitHeuristic splitMethod);

        /// Performs a Rectangle Merge operation. This procedure looks for adjacent free rectangles and merges them if they
        /// can be represented with a single rectangle. Takes up Theta(|freeRectangles|^2) time.
        internal void MergeFreeList()
        {
            DisjointRectCollection test = new DisjointRectCollection();
            foreach (var freeRect in freeRectangles)
                test.Add(freeRect);

            // Do a Theta(n^2) loop to see if any pair of free rectangles could me merged into one.
            // Note that we miss any opportunities to merge three rectangles into one. (should call this function again to detect that)
            for (int i = 0; i < freeRectangles.Count; ++i)
                for (int j = i + 1; j < freeRectangles.Count; ++j)
                {
                    if (freeRectangles[i].Width == freeRectangles[j].Width && freeRectangles[i].X == freeRectangles[j].X)
                    {
                        if (freeRectangles[i].Y == freeRectangles[j].Y + freeRectangles[j].Height)
                        {
                            var freeRectNew = new Rect()
                            {
                                X = freeRectangles[i].X,
                                Y = freeRectangles[i].Y - freeRectangles[j].Height,
                                Width = freeRectangles[i].Width,
                                Height = freeRectangles[i].Height + freeRectangles[j].Height
                            };
                            freeRectangles[i] = freeRectNew;
                            freeRectangles.RemoveAt(j);
                            --j;
                        }
                        else if (freeRectangles[i].Y + freeRectangles[i].Height == freeRectangles[j].Y)
                        {
                            var freeRectNew = new Rect()
                            {
                                X = freeRectangles[i].X,
                                Y = freeRectangles[i].Y,
                                Width = freeRectangles[i].Width,
                                Height = freeRectangles[i].Height + freeRectangles[j].Height
                            };
                            freeRectangles[i] = freeRectNew;
                            freeRectangles.RemoveAt(j);
                            --j;
                        }
                    }
                    else if (freeRectangles[i].Height == freeRectangles[j].Height && freeRectangles[i].Y == freeRectangles[j].Y)
                    {
                        if (freeRectangles[i].X == freeRectangles[j].X + freeRectangles[j].Width)
                        {
                            var freeRectNew = new Rect()
                            {
                                X = freeRectangles[i].X - freeRectangles[j].Width,
                                Y = freeRectangles[i].Y,
                                Width = freeRectangles[i].Width + freeRectangles[j].Width,
                                Height = freeRectangles[i].Height
                            };
                            freeRectangles[i] = freeRectNew;
                            freeRectangles.RemoveAt(j);
                            --j;
                        }
                        else if (freeRectangles[i].X + freeRectangles[i].Width == freeRectangles[j].X)
                        {
                            var freeRectNew = new Rect()
                            {
                                X = freeRectangles[i].X,
                                Y = freeRectangles[i].Y,
                                Width = freeRectangles[i].Width + freeRectangles[j].Width,
                                Height = freeRectangles[i].Height
                            };
                            freeRectangles[i] = freeRectNew;
                            freeRectangles.RemoveAt(j);
                            --j;
                        }
                    }
                }

            test.Clear();
            foreach (var freeRect in freeRectangles)
                test.Add(freeRect);
        }

        /// Stores a list of rectangles that represents the free area of the bin. This rectangles in this list are disjoint.
        private readonly List<Rect> freeRectangles = new List<Rect>();

        /// Used to track that the packer produces proper packings.
        private readonly DisjointRectCollection disjointRects = new DisjointRectCollection();

        /// Goes through the list of free rectangles and finds the best one to place a rectangle of given size into.
        /// Running time is Theta(|freeRectangles|).
        /// @param nodeIndex [out] The index of the free rectangle in the freeRectangles array into which the new
        ///		rect was placed.
        /// @return A Rect structure that represents the placement of the new rect into the best free rectangle.
        private Rect FindPositionForNewNode(int width, int height, FreeRectChoiceHeuristic rectChoice, ref int nodeIndex)
        {
            Rect bestNode = new Rect();
            int bestScore = int.MaxValue;

            /// Try each free rectangle to find the best one for placement.
            for (int i = 0; i < freeRectangles.Count; ++i)
            {
                // If this is a perfect fit upright, choose it immediately.
                if (width == freeRectangles[i].Width && height == freeRectangles[i].Height)
                {
                    bestNode.X = freeRectangles[i].X;
                    bestNode.Y = freeRectangles[i].Y;
                    bestNode.Width = width;
                    bestNode.Height = height;
                    nodeIndex = i;
                    disjointRects.Disjoint(bestNode);
                    break;
                }
                // If this is a perfect fit sideways, choose it.
                else if (height == freeRectangles[i].Width && width == freeRectangles[i].Height)
                {
                    bestNode.X = freeRectangles[i].X;
                    bestNode.Y = freeRectangles[i].Y;
                    bestNode.Width = height;
                    bestNode.Height = width;
                    nodeIndex = i;
                    disjointRects.Disjoint(bestNode);
                    break;
                }
                // Does the rectangle fit upright?
                else if (width <= freeRectangles[i].Width && height <= freeRectangles[i].Height)
                {
                    int score = ScoreByHeuristic(width, height, freeRectangles[i], rectChoice);

                    if (score < bestScore)
                    {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = width;
                        bestNode.Height = height;
                        bestScore = score;
                        nodeIndex = i;
                        disjointRects.Disjoint(bestNode);
                    }
                }
                // Does the rectangle fit sideways?
                else if (height <= freeRectangles[i].Width && width <= freeRectangles[i].Height)
                {
                    int score = ScoreByHeuristic(height, width, freeRectangles[i], rectChoice);

                    if (score < bestScore)
                    {
                        bestNode.X = freeRectangles[i].X;
                        bestNode.Y = freeRectangles[i].Y;
                        bestNode.Width = height;
                        bestNode.Height = width;
                        bestScore = score;
                        nodeIndex = i;
                        disjointRects.Disjoint(bestNode);
                    }
                }
            }
            return bestNode;
        }

        private static int ScoreByHeuristic(int width, int height, Rect freeRect, FreeRectChoiceHeuristic rectChoice)
        {
            switch (rectChoice)
            {
                case FreeRectChoiceHeuristic.RectBestAreaFit: return ScoreBestAreaFit(width, height, freeRect);
                case FreeRectChoiceHeuristic.RectBestShortSideFit: return ScoreBestShortSideFit(width, height, freeRect);
                case FreeRectChoiceHeuristic.RectBestLongSideFit: return ScoreBestLongSideFit(width, height, freeRect);
                case FreeRectChoiceHeuristic.RectWorstAreaFit: return ScoreWorstAreaFit(width, height, freeRect);
                case FreeRectChoiceHeuristic.RectWorstShortSideFit: return ScoreWorstShortSideFit(width, height, freeRect);
                case FreeRectChoiceHeuristic.RectWorstLongSideFit: return ScoreWorstLongSideFit(width, height, freeRect);
                default: return int.MaxValue;
            }
        }
        // The following functions compute (penalty) score values if a rect of the given size was placed into the 
        // given free rectangle. In these score values, smaller is better.
        private static int ScoreBestAreaFit(int width, int height, Rect freeRect)
             => freeRect.Width * freeRect.Height - width * height;
        private static int ScoreBestShortSideFit(int width, int height, Rect freeRect)
        {
            int leftoverHoriz = Math.Abs(freeRect.Width - width);
            int leftoverVert = Math.Abs(freeRect.Height - height);
            int leftover = Math.Min(leftoverHoriz, leftoverVert);
            return leftover;
        }
        private static int ScoreBestLongSideFit(int width, int height, Rect freeRect)
        {
            int leftoverHoriz = Math.Abs(freeRect.Width - width);
            int leftoverVert = Math.Abs(freeRect.Height - height);
            int leftover = Math.Max(leftoverHoriz, leftoverVert);
            return leftover;
        }
        private static int ScoreWorstAreaFit(int width, int height, Rect freeRect) => -ScoreBestAreaFit(width, height, freeRect);
        private static int ScoreWorstShortSideFit(int width, int height, Rect freeRect) => -ScoreBestShortSideFit(width, height, freeRect);
        private static int ScoreWorstLongSideFit(int width, int height, Rect freeRect) => -ScoreBestLongSideFit(width, height, freeRect);
        /// Splits the given L-shaped free rectangle into two new free rectangles after placedRect has been placed into it.
        /// Determines the split axis by using the given heuristic.
        private void SplitFreeRectByHeuristic(Rect freeRect, Rect placedRect, GuillotineSplitHeuristic method)
        {
            // Compute the lengths of the leftover area.
            int w = freeRect.Width - placedRect.Width;
            int h = freeRect.Height - placedRect.Height;

            // Placing placedRect into freeRect results in an L-shaped free area, which must be split into
            // two disjoint rectangles. This can be achieved with by splitting the L-shape using a single line.
            // We have two choices: horizontal or vertical.	

            // Use the given heuristic to decide which choice to make.

            bool splitHorizontal;
            switch (method)
            {
                case GuillotineSplitHeuristic.SplitShorterLeftoverAxis:
                    // Split along the shorter leftover axis.
                    splitHorizontal = (w <= h);
                    break;
                case GuillotineSplitHeuristic.SplitLongerLeftoverAxis:
                    // Split along the longer leftover axis.
                    splitHorizontal = (w > h);
                    break;
                case GuillotineSplitHeuristic.SplitMinimizeArea:
                    // Maximize the larger area == minimize the smaller area.
                    // Tries to make the single bigger rectangle.
                    splitHorizontal = (placedRect.Width * h > w * placedRect.Height);
                    break;
                case GuillotineSplitHeuristic.SplitMaximizeArea:
                    // Maximize the smaller area == minimize the larger area.
                    // Tries to make the rectangles more even-sized.
                    splitHorizontal = (placedRect.Width * h <= w * placedRect.Height);
                    break;
                case GuillotineSplitHeuristic.SplitShorterAxis:
                    // Split along the shorter total axis.
                    splitHorizontal = (freeRect.Width <= freeRect.Height);
                    break;
                case GuillotineSplitHeuristic.SplitLongerAxis:
                    // Split along the longer total axis.
                    splitHorizontal = (freeRect.Width > freeRect.Height);
                    break;
                default:
                    splitHorizontal = true;
                    break;
            }
            // Perform the actual split.
            SplitFreeRectAlongAxis(freeRect, placedRect, splitHorizontal);
        }

        /// Splits the given L-shaped free rectangle into two new free rectangles along the given fixed split axis.
        private void SplitFreeRectAlongAxis(Rect freeRect, Rect placedRect, bool splitHorizontal)
        {
            // Form the two new rectangles.
            Rect bottom = new Rect
            {
                X = freeRect.X,
                Y = freeRect.Y + placedRect.Height,
                Height = freeRect.Height - placedRect.Height
            };
            Rect right = new Rect
            {
                X = freeRect.X + placedRect.Width,
                Y = freeRect.Y,
                Width = freeRect.Width - placedRect.Width
            };
            if (splitHorizontal)
            {
                bottom.Width = freeRect.Width;
                right.Height = placedRect.Height;
            }
            else // Split vertically
            {
                bottom.Width = placedRect.Width;
                right.Height = freeRect.Height;
            }
            // Add the new rectangles into the free rectangle pool if they weren't degenerate.
            if (bottom.Width > 0 && bottom.Height > 0)
                freeRectangles.Add(bottom);
            if (right.Width > 0 && right.Height > 0)
                freeRectangles.Add(right);

            disjointRects.Disjoint(bottom);
            disjointRects.Disjoint(right);
        }

        internal List<Rect> FreeRectangles { get => freeRectangles; }
    }
}

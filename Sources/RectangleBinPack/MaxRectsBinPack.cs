#region Using directives
using System;
using System.Collections.Generic;
#endregion

namespace RectangleBinPack
{
    public class MaxRectsBinPack: BinPack2
    {
		/// Instantiates a bin of size (0,0). Call Init to create a new bin.
		public MaxRectsBinPack() : base()
		{
		}

		/// Instantiates a bin of the given size.
		/// @param allowFlip Specifies whether the packing algorithm is allowed to rotate the input rectangles by 90 degrees to consider a better placement.
		public MaxRectsBinPack(int width, int height) : base(width, height)
		{
		}

		/// (Re)initializes the packer to an empty bin of width x height units. Call whenever
		/// you need to restart with a new bin.
		public override void Init(int width, int height)
		{
			base.Init(width, height);
			BinAllowFlip = true;

			freeRectangles.Clear();
			freeRectangles.Add(new Rect { X = 0, Y = 0, Width = BinWidth, Height = BinHeight } );
		}

		/// Specifies the different heuristic rules that can be used when deciding where to place a new rectangle.
		public enum FreeRectChoiceHeuristic
		{
			RectBestShortSideFit, ///< -BSSF: Positions the rectangle against the short side of a free rectangle into which it fits the best.
			RectBestLongSideFit, ///< -BLSF: Positions the rectangle against the long side of a free rectangle into which it fits the best.
			RectBestAreaFit, ///< -BAF: Positions the rectangle into the smallest free rect into which it fits.
			RectBottomLeftRule, ///< -BL: Does the Tetris placement.
			RectContactPointRule ///< -CP: Choosest the placement where the rectangle touches other rects as much as possible.
		};

		public class Option : GenericOption
		{
			public FreeRectChoiceHeuristic Method { get; set; }
		}

		/// Inserts the given list of rectangles in an offline/batch mode, possibly rotated.
		/// @param rects The list of rectangles to insert. This vector will be destroyed in the process.
		/// @param dst [out] This list will contain the packed rectangles. The indices will not correspond to that of rects.
		/// @param method The rectangle placement rule to use when packing.
		public void Insert(List<RectSize> rects, List<Rect> dst, FreeRectChoiceHeuristic method)
		{
			dst.Clear();

			while (rects.Count > 0)
			{
				int bestScore1 = int.MaxValue;
				int bestScore2 = int.MaxValue;
				int bestRectIndex = -1;
				Rect bestNode = new Rect();

				for (int i = 0; i < rects.Count; ++i)
				{
					int score1 = 0;
					int score2 = 0;
					Rect newNode = ScoreRect(rects[i].Width, rects[i].Height, method, ref score1, ref score2);

					if (score1 < bestScore1 || (score1 == bestScore1 && score2 < bestScore2))
					{
						bestScore1 = score1;
						bestScore2 = score2;
						bestNode = newNode;
						bestRectIndex = i;
					}
				}

				if (bestRectIndex == -1)
					return;

				PlaceRect(bestNode);
				dst.Add(bestNode);
				rects.RemoveAt(bestRectIndex);
			}
		}

		/// Inserts a single rectangle into the bin, possibly rotated.
		public override Rect Insert(RectSize rect, GenericOption option)
		{
			Rect newNode = new Rect();
			// Unused in this function. We don't need to know the score after finding the position.
			int score1 = int.MaxValue;
			int score2 = int.MaxValue;

			int width = rect.Width, height = rect.Height;
			var optionMaxRectsBinPath = option as Option;
			switch (optionMaxRectsBinPath.Method)
			{
				case FreeRectChoiceHeuristic.RectBestShortSideFit: newNode = FindPositionForNewNodeBestShortSideFit(width, height, ref score1, ref score2); break;
				case FreeRectChoiceHeuristic.RectBottomLeftRule: newNode = FindPositionForNewNodeBottomLeft(width, height, ref score1, ref score2); break;
				case FreeRectChoiceHeuristic.RectContactPointRule: newNode = FindPositionForNewNodeContactPoint(width, height, ref score1); break;
				case FreeRectChoiceHeuristic.RectBestLongSideFit: newNode = FindPositionForNewNodeBestLongSideFit(width, height, ref score2, ref score1); break;
				case FreeRectChoiceHeuristic.RectBestAreaFit: newNode = FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2); break;
			}

			if (newNode.Height == 0)
				return newNode;

			int numRectanglesToProcess = freeRectangles.Count;
			for (int i = 0; i < numRectanglesToProcess; ++i)
			{
				if (SplitFreeNode(freeRectangles[i], ref newNode))
				{
					freeRectangles.RemoveAt(i);
					--i;
					--numRectanglesToProcess;
				}
			}
			PruneFreeList();

			UsedRectangles.Add(newNode);
			return newNode;
		}

		private bool BinAllowFlip { get; set; } = true;
		private List<Rect> freeRectangles = new List<Rect>();

		/// Computes the placement score for placing the given rectangle with the given method.
		/// @param score1 [out] The primary placement score will be outputted here.
		/// @param score2 [out] The secondary placement score will be outputted here. This isu sed to break ties.
		/// @return This struct identifies where the rectangle would be placed if it were placed.
		private Rect ScoreRect(int width, int height, FreeRectChoiceHeuristic method, ref int score1, ref int score2)
		{
			Rect newNode = new Rect();
			score1 = int.MaxValue;
			score2 = int.MaxValue;
			switch (method)
			{
				case FreeRectChoiceHeuristic.RectBestShortSideFit: newNode = FindPositionForNewNodeBestShortSideFit(width, height, ref score1, ref score2); break;
				case FreeRectChoiceHeuristic.RectBottomLeftRule: newNode = FindPositionForNewNodeBottomLeft(width, height, ref score1, ref score2); break;
				case FreeRectChoiceHeuristic.RectContactPointRule:
					newNode = FindPositionForNewNodeContactPoint(width, height, ref score1);
					score1 = -score1; // Reverse since we are minimizing, but for contact point score bigger is better.
					break;
				case FreeRectChoiceHeuristic.RectBestLongSideFit: newNode = FindPositionForNewNodeBestLongSideFit(width, height, ref score2, ref score1); break;
				case FreeRectChoiceHeuristic.RectBestAreaFit: newNode = FindPositionForNewNodeBestAreaFit(width, height, ref score1, ref score2); break;
			}

			// Cannot fit the current rectangle.
			if (newNode.Height == 0)
			{
				score1 = int.MaxValue;
				score2 = int.MaxValue;
			}

			return newNode;
		}

		/// Places the given rectangle into the bin.
		private void PlaceRect(Rect node)
		{
			int numRectanglesToProcess = freeRectangles.Count;
			for (int i = 0; i < numRectanglesToProcess; ++i)
			{
				if (SplitFreeNode(freeRectangles[i], ref node))
				{
					freeRectangles.RemoveAt(i);
					--i;
					--numRectanglesToProcess;
				}
			}
			PruneFreeList();
			UsedRectangles.Add(node);
		}

		/// Computes the placement score for the -CP variant.
		private int ContactPointScoreNode(int x, int y, int width, int height)
		{
			int score = 0;

			if (x == 0 || x + width == BinWidth)
				score += height;
			if (y == 0 || y + height == BinHeight)
				score += width;

			for (int i = 0; i < UsedRectangles.Count; ++i)
			{
				if (UsedRectangles[i].X == x + width || UsedRectangles[i].X + UsedRectangles[i].Width == x)
					score += CommonIntervalLength(UsedRectangles[i].Y, UsedRectangles[i].Y + UsedRectangles[i].Height, y, y + height);
				if (UsedRectangles[i].Y == y + height || UsedRectangles[i].Y + UsedRectangles[i].Height == y)
					score += CommonIntervalLength(UsedRectangles[i].X, UsedRectangles[i].X + UsedRectangles[i].Width, x, x + width);
			}
			return score;
		}

		private int CommonIntervalLength(int i1start, int i1end, int i2start, int i2end)
		{
			if (i1end < i2start || i2end < i1start)
				return 0;
			return Math.Min(i1end, i2end) - Math.Max(i1start, i2start);
		}

		private Rect FindPositionForNewNodeBottomLeft(int width, int height, ref int bestY, ref int bestX)
		{
			Rect bestNode = new Rect();

			bestY = int.MaxValue;
			bestX = int.MaxValue;

			for (int i = 0; i < freeRectangles.Count; ++i)
			{
				// Try to place the rectangle in upright (non-flipped) orientation.
				if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height)
				{
					int topSideY = freeRectangles[i].Y + height;
					if (topSideY < bestY || (topSideY == bestY && freeRectangles[i].X < bestX))
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = width;
						bestNode.Height = height;
						bestY = topSideY;
						bestX = freeRectangles[i].X;
					}
				}
				if (BinAllowFlip && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width)
				{
					int topSideY = freeRectangles[i].Y + width;
					if (topSideY < bestY || (topSideY == bestY && freeRectangles[i].X< bestX))
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = height;
						bestNode.Height = width;
						bestY = topSideY;
						bestX = freeRectangles[i].X;
					}
				}
			}
			return bestNode;
		}
		private Rect FindPositionForNewNodeBestShortSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit)
		{
			Rect bestNode = new Rect();

			bestShortSideFit = int.MaxValue;
			bestLongSideFit = int.MaxValue;

			for (int i = 0; i < freeRectangles.Count; ++i)
			{
				// Try to place the rectangle in upright (non-flipped) orientation.
				if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height)
				{
					int leftoverHoriz = Math.Abs(freeRectangles[i].Width - width);
					int leftoverVert = Math.Abs(freeRectangles[i].Height - height);
					int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
					int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

					if (shortSideFit < bestShortSideFit || (shortSideFit == bestShortSideFit && longSideFit < bestLongSideFit))
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = width;
						bestNode.Height = height;
						bestShortSideFit = shortSideFit;
						bestLongSideFit = longSideFit;
					}
				}

				if (BinAllowFlip && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width)
				{
					int flippedLeftoverHoriz = Math.Abs(freeRectangles[i].Width - height);
					int flippedLeftoverVert = Math.Abs(freeRectangles[i].Height - width);
					int flippedShortSideFit = Math.Min(flippedLeftoverHoriz, flippedLeftoverVert);
					int flippedLongSideFit = Math.Max(flippedLeftoverHoriz, flippedLeftoverVert);

					if (flippedShortSideFit < bestShortSideFit || (flippedShortSideFit == bestShortSideFit && flippedLongSideFit < bestLongSideFit))
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = height;
						bestNode.Height = width;
						bestShortSideFit = flippedShortSideFit;
						bestLongSideFit = flippedLongSideFit;
					}
				}
			}
			return bestNode;
		}
		private Rect FindPositionForNewNodeBestLongSideFit(int width, int height, ref int bestShortSideFit, ref int bestLongSideFit)
		{
			Rect bestNode = new Rect();

			bestShortSideFit = int.MaxValue;
			bestLongSideFit = int.MaxValue;

			for (int i = 0; i < freeRectangles.Count; ++i)
			{
				// Try to place the rectangle in upright (non-flipped) orientation.
				if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height)
				{
					int leftoverHoriz = Math.Abs(freeRectangles[i].Width - width);
					int leftoverVert = Math.Abs(freeRectangles[i].Height - height);
					int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
					int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

					if (longSideFit < bestLongSideFit || (longSideFit == bestLongSideFit && shortSideFit < bestShortSideFit))
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = width;
						bestNode.Height = height;
						bestShortSideFit = shortSideFit;
						bestLongSideFit = longSideFit;
					}
				}

				if (BinAllowFlip && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width)
				{
					int leftoverHoriz = Math.Abs(freeRectangles[i].Width - height);
					int leftoverVert = Math.Abs(freeRectangles[i].Height - width);
					int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);
					int longSideFit = Math.Max(leftoverHoriz, leftoverVert);

					if (longSideFit < bestLongSideFit || (longSideFit == bestLongSideFit && shortSideFit < bestShortSideFit))
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = height;
						bestNode.Height = width;
						bestShortSideFit = shortSideFit;
						bestLongSideFit = longSideFit;
					}
				}
			}
			return bestNode;
		}
		private Rect FindPositionForNewNodeBestAreaFit(int width, int height, ref int bestAreaFit, ref int bestShortSideFit)
		{
			Rect bestNode = new Rect();

			bestAreaFit = int.MaxValue;
			bestShortSideFit = int.MaxValue;

			for (int i = 0; i < freeRectangles.Count; ++i)
			{
				int areaFit = freeRectangles[i].Width * freeRectangles[i].Height - width * height;

				// Try to place the rectangle in upright (non-flipped) orientation.
				if (freeRectangles[i].Width >= width
					&& freeRectangles[i].Height >= height)
				{
					int leftoverHoriz = Math.Abs(freeRectangles[i].Width - width);
					int leftoverVert = Math.Abs(freeRectangles[i].Height - height);
					int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);

					if (areaFit < bestAreaFit || (areaFit == bestAreaFit && shortSideFit < bestShortSideFit))
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = width;
						bestNode.Height = height;
						bestShortSideFit = shortSideFit;
						bestAreaFit = areaFit;
					}
				}

				if (BinAllowFlip
					&& freeRectangles[i].Width >= height
					&& freeRectangles[i].Height >= width)
				{
					int leftoverHoriz = Math.Abs(freeRectangles[i].Width - height);
					int leftoverVert = Math.Abs(freeRectangles[i].Height - width);
					int shortSideFit = Math.Min(leftoverHoriz, leftoverVert);

					if (areaFit < bestAreaFit || (areaFit == bestAreaFit && shortSideFit < bestShortSideFit))
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = height;
						bestNode.Height = width;
						bestShortSideFit = shortSideFit;
						bestAreaFit = areaFit;
					}
				}
			}
			return bestNode;
		}
		private Rect FindPositionForNewNodeContactPoint(int width, int height, ref int bestContactScore)
		{
			Rect bestNode = new Rect();

			bestContactScore = -1;

			for (int i = 0; i < freeRectangles.Count; ++i)
			{
				// Try to place the rectangle in upright (non-flipped) orientation.
				if (freeRectangles[i].Width >= width && freeRectangles[i].Height >= height)
				{
					int score = ContactPointScoreNode(freeRectangles[i].X, freeRectangles[i].Y, width, height);
					if (score > bestContactScore)
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = width;
						bestNode.Height = height;
						bestContactScore = score;
					}
				}
				if (BinAllowFlip && freeRectangles[i].Width >= height && freeRectangles[i].Height >= width)
				{
					int score = ContactPointScoreNode(freeRectangles[i].X, freeRectangles[i].Y, height, width);
					if (score > bestContactScore)
					{
						bestNode.X = freeRectangles[i].X;
						bestNode.Y = freeRectangles[i].Y;
						bestNode.Width = height;
						bestNode.Height = width;
						bestContactScore = score;
					}
				}
			}
			return bestNode;
		}

		/// @return True if the free node was split.
		private bool SplitFreeNode(Rect freeNode, ref Rect usedNode)
		{
			// Test with SAT if the rectangles even intersect.
			if (usedNode.X >= freeNode.X+ freeNode.Width || usedNode.X + usedNode.Width <= freeNode.X ||
				usedNode.Y >= freeNode.Y + freeNode.Height || usedNode.Y + usedNode.Height <= freeNode.Y)
				return false;

			if (usedNode.X < freeNode.X + freeNode.Width && usedNode.X + usedNode.Width > freeNode.X)
			{
				// New node at the top side of the used node.
				if (usedNode.Y > freeNode.Y && usedNode.Y < freeNode.Y + freeNode.Height)
				{
					Rect newNode = freeNode;
					newNode.Height = usedNode.Y - newNode.Y;
					freeRectangles.Add(newNode);
				}

				// New node at the bottom side of the used node.
				if (usedNode.Y + usedNode.Height < freeNode.Y + freeNode.Height)
				{
					Rect newNode = freeNode;
					newNode.Y = usedNode.Y + usedNode.Height;
					newNode.Height = freeNode.Y + freeNode.Height - (usedNode.Y + usedNode.Height);
					freeRectangles.Add(newNode);
				}
			}

			if (usedNode.Y < freeNode.Y + freeNode.Height && usedNode.Y + usedNode.Height > freeNode.Y)
			{
				// New node at the left side of the used node.
				if (usedNode.X > freeNode.X && usedNode.X < freeNode.X + freeNode.Width)
				{
					Rect newNode = freeNode;
					newNode.Width = usedNode.X - newNode.X;
					freeRectangles.Add(newNode);
				}
				// New node at the right side of the used node.
				if (usedNode.X + usedNode.Width < freeNode.X + freeNode.Width)
				{
					Rect newNode = freeNode;
					newNode.X = usedNode.X + usedNode.Width;
					newNode.Width = freeNode.X + freeNode.Width - (usedNode.X + usedNode.Width);
					freeRectangles.Add(newNode);
				}
			}
			return true;
		}

		/// Goes through the free rectangle list and removes any redundant entries.
		private void PruneFreeList()
		{
			/// Go through each pair and remove any rectangle that is redundant.
			for (int i = 0; i < freeRectangles.Count; ++i)
				for (int j = i + 1; j < freeRectangles.Count; ++j)
				{
					if (Rect.IsContainedIn(freeRectangles[i], freeRectangles[j]))
					{
						freeRectangles.RemoveAt(i);
						--i;
						break;
					}
					if (Rect.IsContainedIn(freeRectangles[j], freeRectangles[i]))
					{
						freeRectangles.RemoveAt(j);
						--j;
					}
				}
		}
	}
}

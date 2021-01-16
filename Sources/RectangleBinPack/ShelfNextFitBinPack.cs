#region Using directives
using System;
#endregion

namespace RectangleBinPack
{
    public class ShelfNextFitBinPack : BinPack1
    {
		public ShelfNextFitBinPack() : base()
		{
			currentX = 0; currentY = 0; shelfHeight = 0;
		}
		public ShelfNextFitBinPack(int width, int height) : base(width, height)
		{
		}
		public override void Init(int width, int height)
		{
			base.Init(width, height);
			currentX = 0; currentY = 0; shelfHeight = 0;
		}
		public override Rect Insert(RectSize rectSize, GenericOption option)
		{
			Rect rect = new Rect();
			// There are three cases:
			// 1. short edge <= long edge <= shelf height. Then store the long edge vertically.
			// 2. short edge <= shelf height <= long edge. Then store the short edge vertically.
			// 3. shelf height <= short edge <= long edge. Then store the short edge vertically.

			// If the long edge of the new rectangle fits vertically onto the current shelf,
			// flip it. If the short edge is larger than the current shelf height, store
			// the short edge vertically.
			int width = rectSize.Width;
			int height = rectSize.Height;
			if (((width > height && width < shelfHeight) ||
				(width < height && height > shelfHeight)))
			{
				Swap(ref width, ref height);
			}

			if (currentX + width > BinWidth)
			{
				currentX = 0;
				currentY += shelfHeight;
				shelfHeight = 0;

				// When starting a new shelf, store the new long edge of the new rectangle horizontally
				// to minimize the new shelf height.
				if (width < height)
				{
					Swap(ref width, ref height);
				}
			}

			// If the rectangle doesn't fit in this orientation, try flipping.
			if (width > BinWidth || currentY + height > BinHeight)
			{
				Swap(ref width, ref height);
			}

			// If flipping didn't help, return failure.
			if (width > BinWidth || currentY + height > BinHeight)
				return rect;

			rect.Width = width;
			rect.Height = height;
			rect.X = currentX;
			rect.Y = currentY;

			currentX += width;
			shelfHeight = Math.Max(shelfHeight, height);
			IncrementUsedArea( width * height );
			return rect;
		}

        #region Data members
		private int currentX;
		private int currentY;
		private int shelfHeight;
        #endregion
    }
}

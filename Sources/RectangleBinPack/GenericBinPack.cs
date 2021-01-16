using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleBinPack
{
    public abstract class GenericOption
    {
    }

    public class OptionNone : GenericOption
    { 
    }

    public abstract class GenericBinPack
    {
        public GenericBinPack() { BinWidth = 0; BinHeight = 0; }
        public GenericBinPack(int binWidth, int binHeight) { Init(binWidth, binHeight); }

        public virtual void Init(int binWidth, int binHeight) { BinWidth = binWidth; BinHeight = binHeight; }
        public abstract Rect Insert(RectSize rectSize, GenericOption option);
        
        public float Occupancy => (float)UsedSurfaceArea / (BinWidth * BinHeight);
        public float FreeSpaceLeft => 100.0f * (1.0f - Occupancy);

        protected abstract int UsedSurfaceArea { get;}
        protected int BinWidth { get; private set; }
        protected int BinHeight { get; private set; }

        protected static void Swap(ref int x, ref int y)
        {
            var temp = x;
            x = y;
            y = temp;
        }
    }

    public abstract class BinPack1 : GenericBinPack
    {
        public BinPack1():base() {}
        public BinPack1(int width, int height) : base(width, height) {}
        public override void Init(int binWidth, int binHeight) { base.Init(binWidth, binHeight); _usedSurfaceArea = 0; }
        protected void IncrementUsedArea(int incUsedArea) { _usedSurfaceArea += incUsedArea; }
        protected override int UsedSurfaceArea => _usedSurfaceArea;
        private int _usedSurfaceArea = 0;
    }

    public abstract class BinPack2 : GenericBinPack
    {
        public BinPack2():base() {}
        public BinPack2(int width, int height):base(width, height) {}
        public override void Init(int binWidth, int binHeight) { base.Init(binWidth, binHeight); UsedRectangles.Clear(); }
        protected override int UsedSurfaceArea
        {
            get
            {
                int usedSurfaceArea = 0;
                foreach (var rect in UsedRectangles)
                    usedSurfaceArea += rect.Width * rect.Height;
                return usedSurfaceArea;
            }
        }
        protected List<Rect> UsedRectangles { get; set; } = new List<Rect>();
    }
}

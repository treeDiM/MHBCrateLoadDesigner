using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RectangleBinPack;

namespace MHB.CrateLoadDesigner.Engine
{
    internal class BBox2D
    {
        public BBox2D() {}
        public BBox2D(IEnumerable<Rect> rects)
        {
            foreach (var rect in rects)
                Expand(rect);
        }
        public int XMin { get; set; } = int.MaxValue;
        public int XMax { get; set; } = int.MinValue;
        public int YMin { get; set; } = int.MaxValue;
        public int YMax { get; set; } = int.MinValue;
        public int Width => XMax - XMin;
        public int Height => YMax - YMin;
        public void Expand(Rect rect)
        {
            XMin = Math.Min(XMin, rect.X);
            XMax = Math.Max(XMax, rect.X + rect.Width);
            YMin = Math.Min(YMin, rect.Y);
            YMax = Math.Max(YMax, rect.Y + rect.Height);
        }
        public bool IsValid
        {
            get
            {
                try
                {
                    return XMin <= XMax && YMin <= YMax;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}

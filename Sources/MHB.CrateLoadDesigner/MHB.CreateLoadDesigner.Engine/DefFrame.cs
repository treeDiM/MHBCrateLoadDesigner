#region Using directives
using System;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class DefFrame
    {
        public uint ID { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int Number { get; set; }

        public double LongSide => Math.Max(Width, Height);
        public double ShortSide => Math.Min(Width, Height);
        public double Perimeter => 2 * (Width + Height);
        public double Area => Width * Height;
    }
}

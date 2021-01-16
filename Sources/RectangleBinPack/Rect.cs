#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace RectangleBinPack
{
    public struct RectSize
    {
        public RectSize(int width, int height) { Width = width; Height = height; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Area => Width * Height;

        public override int GetHashCode() => Width.GetHashCode() & Height.GetHashCode();
        public override bool Equals(object obj) { if (obj is RectSize o) return o.Width.Equals(Width) && o.Height.Equals(Height); else return false; }
        public static bool operator ==(RectSize left, RectSize right) => left.Equals(right);
        public static bool operator !=(RectSize left, RectSize right) => !(left == right);
        public override string ToString() => $"Dimensions = ({Width},{Height})";
    }

    public struct Rect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Area => Width * Height;

        public static bool IsContainedIn(Rect a, Rect b)
        {
            return a.X >= b.X && a.Y >= b.Y
                && a.X + a.Width <= b.X + b.Width
                && a.Y + a.Height <= b.Y + b.Height;
        }

        public override string ToString() => $"Position = ({X}, {Y}) Dim = ({Width}, {Height})";
    }
}

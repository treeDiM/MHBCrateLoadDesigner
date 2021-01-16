#region Using directives
using System.Collections.Generic;
#endregion

namespace RectangleBinPack
{
    internal class DisjointRectCollection
    {
        public List<Rect> rects = new List<Rect>();

        public bool Add(Rect r)
        {
            // Degenerate rectangles are ignored.
            if (r.Width == 0 || r.Height == 0) return true;
            if (!Disjoint(r)) return false;
            rects.Add(r);
            return true;
        }

        public void Clear()
        {
            rects.Clear();
        }

        public bool Disjoint(Rect r)
        {
            // Degenerate rectangles are ignored.
            if (r.Width == 0 || r.Height == 0) return true;

            foreach (var rect in rects)
                if (!Disjoint(rect, r))
                    return false;
            return true;
        }

        public static bool Disjoint(Rect a, Rect b)
        {
            if (a.X + a.Width <= b.X ||
                b.X + b.Width <= a.X ||
                a.Y + a.Height <= b.Y ||
                b.Y + b.Height <= a.Y)
                return true;
            return false;
        }
    }
}

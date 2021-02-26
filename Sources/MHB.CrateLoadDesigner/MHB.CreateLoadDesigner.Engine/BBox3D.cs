#region Using directives
using System;

using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    internal class BBox3D
    {
        public BBox3D() { }
        public double XMin { get; set; } = double.MaxValue;
        public double XMax { get; set; } = double.MinValue;
        public double YMin { get; set; } = double.MaxValue;
        public double YMax { get; set; } = double.MinValue;
        public double ZMin { get; set; } = double.MaxValue;
        public double ZMax { get; set; } = double.MinValue;
        public Vector3D PtMin => new Vector3D(XMin, YMin, ZMin);
        public Vector3D PtMax => new Vector3D(XMax, YMax, ZMax);
        public void Extend(Vector3D pt)
        {
            XMin = Math.Min(pt.X, XMin);
            XMax = Math.Max(pt.X, XMax);
            YMin = Math.Min(pt.Y, YMin);
            YMax = Math.Max(pt.Y, YMax);
            ZMin = Math.Min(pt.Z, ZMin);
            ZMax = Math.Max(pt.Z, ZMax);
        }
        public void Extend(BBox3D bbox)
        {
            Extend(bbox.PtMin);
            Extend(bbox.PtMax);
        }
        public Vector3D Dimensions => new Vector3D(XMax - XMin, YMax - YMin, ZMax - ZMin);
        public bool IsValid => XMin <= XMax && YMin <= YMax && ZMin <= ZMax;
    }
}

#region Using directives
using System;

using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class DefCrateGlass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double MaxLongSide { get; set; }
        public double MaxShortSide { get; set; }
        public Vector3D DimensionsOuter { get; set; }

        public bool DynResizing { get; set; } = false;
        public double? DynMaxLength { get; set; }
        public double? DynAdditionalLength { get; set; }

        public int[] MaxQuantity = new int[2];

        public bool CanFitGlass(DefGlass glass)
        {
            if (glass.ShortSide > MaxShortSide) return false;
            if (glass.LongSide > (DynMaxLength.HasValue ? DynMaxLength.Value : MaxLongSide)) return false;
            return true;
        }

        public InstCrateGlass Instantiate(DefGlass glass, uint index)
        {
            if (MaxLongSide >= glass.LongSide
                && MaxShortSide >= glass.ShortSide)
                return new InstCrateGlass(index, new Vector2D(MaxLongSide, MaxShortSide), DimensionsOuter, MaxQuantity[IndexMaxQuantity]);
            else if (DynMaxLength.HasValue && DynAdditionalLength.HasValue
                && DynMaxLength.Value >= glass.LongSide
                && MaxShortSide >= glass.ShortSide)
                return new InstCrateGlass(index, new Vector2D(glass.LongSide, MaxShortSide), new Vector3D(glass.LongSide + DynAdditionalLength.Value, DimensionsOuter.Y, DimensionsOuter.Z), MaxQuantity[IndexMaxQuantity]);
            else 
                return null;
        }

        private static int IndexMaxQuantity
        {
            get
            {
                switch (Project.PGlassType)
                {
                    case Project.GlassType.DOUBLEGLASSLAMINATED:
                    case Project.GlassType.DOUBLEGLASSTEMPERED:
                        return 0;
                    case Project.GlassType.TRIPLEGLASSLAMINATED:
                    case Project.GlassType.TRIPLEGLASSTEMPERED:
                        return 1;
                    default:
                        throw new Exception($"Invalid GlassType: {Project.PGlassType}");

                }
            }
        }

    }
}

#region Using directives
using System;

using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class DefCrateFrame
    {
        public enum EType { CRATE, SKID };

        public string Name { get; set; }
        public string Description { get; set; }
        public double MaxLongSide { get; set; }
        public double MaxShortSide { get; set; }
        public Vector3D DimensionsOuter { get; set; }

        public bool DynResizing { get; set; } = false;
        public double? DynMaxLength { get; set; }
        public double? DynAdditionalLength { get; set; }

        public EType CrateType { get; set; }
        public int[] MaxNumberOfLayers = new int[2];

        public bool CouldFitFrame(DefFrame frame)
        {
            if (frame.ShortSide > MaxShortSide) return false;
            if (frame.LongSide > (DynMaxLength.HasValue ? DynMaxLength.Value : MaxLongSide)) return false;
            return true;
        }
        public InstCrateFrame Instantiate(DefFrame frame, uint index)
        {
            if (MaxLongSide >= frame.LongSide && MaxShortSide >= frame.ShortSide)
                return new InstCrateFrame(index, new Vector2D(MaxLongSide, MaxShortSide), MaxNumberOfLayers[IndexMaxNumber], CrateType == EType.SKID) { OuterDimensions = DimensionsOuter };
            else if (DynMaxLength.HasValue && DynMaxLength.Value/* - DynAdditionalLength.Value*/ >= frame.LongSide && MaxShortSide >= frame.ShortSide)
                return new InstCrateFrame(index, new Vector2D(frame.LongSide, MaxShortSide), MaxNumberOfLayers[0], CrateType == EType.SKID) { OuterDimensions = new Vector3D(frame.LongSide + DynAdditionalLength.Value, DimensionsOuter.Y, DimensionsOuter.Z) };
            else
                return null;
        }

        private static int IndexMaxNumber
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

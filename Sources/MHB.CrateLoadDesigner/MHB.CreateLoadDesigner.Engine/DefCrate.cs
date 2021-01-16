#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class DefCrate
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
            if (frame.LongSide > (DynMaxLength.HasValue ? DynMaxLength.Value - DynAdditionalLength.Value : MaxLongSide)) return false;
            return true;
        }
        public InstCrateFrame Instantiate(DefFrame frame, uint index)
        {
            if (MaxLongSide >= frame.LongSide && MaxShortSide >= frame.ShortSide)
                return new InstCrateFrame(index, new Vector2D(MaxLongSide, MaxShortSide), MaxNumberOfLayers[0]);
            else if (DynMaxLength.HasValue && DynMaxLength.Value - DynAdditionalLength.Value >= frame.LongSide && MaxShortSide >= frame.ShortSide)
                return new InstCrateFrame(index, new Vector2D(frame.LongSide, MaxShortSide), MaxNumberOfLayers[0]);
            else
                return null;
        }
    }
}

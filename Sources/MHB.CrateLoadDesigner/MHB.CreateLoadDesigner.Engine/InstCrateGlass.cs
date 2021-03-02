#region Using directives
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class InstCrateGlass : InstCrate
    {
        internal InstCrateGlass(uint id, Vector2D maxUnitDimensions, Vector3D outerDimensions, int maxQuantity, double spacing, DefCrateGlass parent) : base(id)
        {
            MaxQuantity = maxQuantity;
            MaxUnitDimensions = maxUnitDimensions;
            OuterDimensions = outerDimensions;
            Spacing = spacing;
            Parent = parent;
        }
        public Dictionary<DefGlass, int> ContentDict
        {
            get
            {
                var listDefGlass = new List<DefGlass>();
                foreach (var gp in GlassPositions)
                    listDefGlass.Add(gp.Parent);
                var dict = listDefGlass
                    .GroupBy(gp => gp)
                    .Select(gp => new {
                        Glass = gp.Key,
                        Count = gp.Count()
                    });
                return dict.ToDictionary(g => g.Glass, g => g.Count);
            }
        }
        public bool PackGlass(DefGlass defGlass)
        {
            if (GlassPositions.Count >= MaxQuantity)
                return false;
            if (defGlass.LongSide > MaxUnitDimensions.X || defGlass.ShortSide > MaxUnitDimensions.Y)
                return false;

            GlassPositions.Add(
                new GlassPosition(defGlass, defGlass.Height > defGlass.Width)
                );
            return true;
        }
        public List<GlassPosition> GlassPositions { get; set; } = new List<GlassPosition>();
        public int MaxQuantity { get; set; }
        public Vector2D MaxUnitDimensions { get; set; }
        public double Spacing { get; set; }
        public DefCrateGlass Parent { get; private set; }
    }

    public class GlassPosition
    {
        public GlassPosition(DefGlass defGlass, bool rotated)
        {
            Parent = defGlass; Rotated = rotated; 
        }
        public DefGlass Parent { get; set; }
        public bool Rotated { get; set; }
    }
}

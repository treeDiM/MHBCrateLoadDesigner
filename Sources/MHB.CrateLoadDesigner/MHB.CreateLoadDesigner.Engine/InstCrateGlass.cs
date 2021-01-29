#region Using directives
using System.Collections.Generic;
using System.Linq;

using log4net;
using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class InstCrateGlass
    {
        internal InstCrateGlass(uint id, Vector2D maxUnitDimensions, Vector3D outerDimensions, int maxQuantity)
        {
            ID = id;
            MaxQuantity = maxQuantity;
            MaxUnitDimensions = maxUnitDimensions;
            OuterDimensions = outerDimensions;
        }

        public Dictionary<DefGlass, int> ContentDict
        {
            get
            {
                var listDefGlass = new List<DefGlass>();
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
            {
                _log.Info($"{GlassPositions.Count} -> Crate {ID} is full!");
                return false;
            }
            if (defGlass.LongSide > MaxUnitDimensions.X || defGlass.ShortSide > MaxUnitDimensions.Y)
                return false;

            GlassPositions.Add(
                new GlassPosition(defGlass, defGlass.Height > defGlass.Width)
                );
            return true;
        }

        public List<GlassPosition> GlassPositions { get; set; } = new List<GlassPosition>();
        public uint ID { get; set; }
        public int MaxQuantity { get; set; }
        public Vector2D MaxUnitDimensions { get; set; }
        public Vector3D OuterDimensions { get; set; }


        private static ILog _log = LogManager.GetLogger(typeof(InstCrateGlass));
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

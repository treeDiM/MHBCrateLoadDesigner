#region Using directives
using System;

using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class CratePosition : BasePosition
    {
        public CratePosition(Vector2D position, Axis orientation, InstCrate crate) : base(position, orientation) { Crate = crate; }
        public InstCrate Crate { get; }
        internal BBox3D BBox
        {
            get
            {
                var bbox = new BBox3D();
                bbox.Extend(PtMin);
                bbox.Extend(PtMax);
                return bbox;
            }
        }
        #region Helpers
        private Vector3D PtMin => new Vector3D(Position.X, Position.Y, 0.0);
        private Vector3D PtMax
        {
            get
            {
                Vector3D vPos = new Vector3D(Position.X, Position.Y, 0.0);
                switch (Orientation)
                {
                    case Axis.XP: return vPos + new Vector3D(Crate.OuterDimensions.X, Crate.OuterDimensions.Y, Crate.OuterDimensions.Z);
                    case Axis.YP: return vPos + new Vector3D(-Crate.OuterDimensions.Y, Crate.OuterDimensions.X, Crate.OuterDimensions.Z);
                    case Axis.XN: return vPos + new Vector3D(-Crate.OuterDimensions.X, -Crate.OuterDimensions.Y, Crate.OuterDimensions.Z);
                    case Axis.YN: return vPos + new Vector3D(Crate.OuterDimensions.Y, -Crate.OuterDimensions.X, Crate.OuterDimensions.Z);
                    default: throw new Exception("Invalid FormPosition.Axis");
                }
            }
        }
        #endregion
    }
}

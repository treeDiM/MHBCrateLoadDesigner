#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class CratePosition : BasePosition
    {
        public CratePosition(Vector2D position, Axis orientation, InstCrate crate) : base(position, orientation) { CrateList.Add( crate ); }
        public List<InstCrate> CrateList { get; } = new List<InstCrate>();
        public InstCrate Crate0 => CrateList[0];
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
        public bool AcceptCrateOnTop(InstCrate crate, double innerContainerHeight)
        {
            if (crate.OuterDimensions.X == Crate0.OuterDimensions.X
                && crate.OuterDimensions.Y == Crate0.OuterDimensions.Y
                && Height + crate.OuterDimensions.Z <= innerContainerHeight) 
            {
                CrateList.Add(crate);
                return true;
            }
            return false;
        }
        #region Helpers
        private double Height => CrateList.Sum(c => c.OuterDimensions.Z);
        private Vector3D PtMin => new Vector3D(Position.X, Position.Y, 0.0);
        private Vector3D PtMax
        {
            get
            {
                Vector3D vPos = new Vector3D(Position.X, Position.Y, 0.0);
                InstCrate crate = CrateList[CrateList.Count - 1];
                switch (Orientation)
                {
                    case Axis.XP: return vPos + new Vector3D(crate.OuterDimensions.X, crate.OuterDimensions.Y, crate.OuterDimensions.Z);
                    case Axis.YP: return vPos + new Vector3D(-crate.OuterDimensions.Y, crate.OuterDimensions.X, crate.OuterDimensions.Z);
                    case Axis.XN: return vPos + new Vector3D(-crate.OuterDimensions.X, -crate.OuterDimensions.Y, crate.OuterDimensions.Z);
                    case Axis.YN: return vPos + new Vector3D(crate.OuterDimensions.Y, -crate.OuterDimensions.X, crate.OuterDimensions.Z);
                    default: throw new Exception("Invalid FormPosition.Axis");
                }
            }
        }
        #endregion
    }
}

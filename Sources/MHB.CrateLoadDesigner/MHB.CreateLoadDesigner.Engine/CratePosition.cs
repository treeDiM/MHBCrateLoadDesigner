#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class CratePosition : BasePosition
    {
        public CratePosition(Vector2D position, Axis orientation, InstCrate crate) : base(position, orientation) { Crate = crate; }
        public InstCrate Crate { get; }
    }
}

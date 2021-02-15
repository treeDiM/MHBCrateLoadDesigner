#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class InstCrate
    {
        public InstCrate(uint id) { ID = id; }
        public uint ID { get; }
        public virtual Vector3D OuterDimensions { get; set; }
        public double Length => OuterDimensions.X;
        public double Width => OuterDimensions.Y;
    }
}

#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class FramePosition : BasePosition
    {
        public FramePosition(DefFrame parent, Vector2D pos, Axis orientation)
            : base(pos, orientation)
        {
            Parent = parent;
        }
        public DefFrame Parent { get; }
    }
}

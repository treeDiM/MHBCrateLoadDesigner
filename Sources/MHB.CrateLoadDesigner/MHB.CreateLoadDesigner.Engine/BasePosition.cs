#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class BasePosition
    {
        public BasePosition(Vector2D position, Axis orientation)
        {
            Position = position;
            Orientation = orientation;
        }
        public Vector2D Position { get; set; }
        public Axis Orientation { get; set; }
        public enum Axis { XP, YP, XN, YN };
    }
}

#region Using directives
using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class DefContainer
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double OpeningWidth { get; set; }
        public double OpeningHeight { get; set; }
        public double RoofOpeningLength { get; set; }
        public double RoofOpeningWidth { get; set; }
        public double Payload { get; set; }
        public double EmptyWeight { get; set; }
        public string Remark { get; set; }
        public Vector3D DimensionsInner { get; set; }
    }
}

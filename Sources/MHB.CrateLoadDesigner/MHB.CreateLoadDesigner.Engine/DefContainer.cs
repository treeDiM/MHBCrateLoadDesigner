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

        public bool CanFitCrate(Vector3D dimensions)
        {
            if (dimensions.X < DimensionsInner.X && dimensions.Y < DimensionsInner.Y && dimensions.Z < DimensionsInner.Z)
                return true;
            if (dimensions.X < RoofOpeningLength && dimensions.Y < RoofOpeningWidth)
                return true;
            return false;
        }
        public InstContainer Instantiate(uint id) => new InstContainer(id, this);
    }
}

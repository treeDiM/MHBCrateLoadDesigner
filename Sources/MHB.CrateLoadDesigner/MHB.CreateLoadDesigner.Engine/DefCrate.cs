#region Using directives
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class DefCrate
    {
        public enum EType { CRATE, SKID};

        public string Brand { get; set; }
        public string Description { get; set; }
        public Vector3D DimensionsOuter { get; set; }
        public Vector3D DimensionsInner { get; set; }
        public double Cost { get; set; }
        public EType CrateType { get; set; }

        public static List<DefCrate> LoadFromFile(string filePath)
        {
            var list = new List<DefCrate>();
            return list;
        }
    }
}

#region Using directives
using System.Collections.Generic;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class InstCrateFrame
    {
        public List<Layer> Layers { get; set; }
    }

    public class Layer
    {
        public InstCrateFrame ParentCrate { get; set; }
    }
}

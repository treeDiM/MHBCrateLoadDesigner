using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sharp3D.Math.Core;


namespace MHB.CrateLoadDesigner.Engine
{
    public class FramePosition
    {
        public enum Axis { XP, YP, XN, YN };

        public FramePosition(DefFrame parent, Vector2D pos, Axis orientation) { Parent = parent; Position = pos; Orientation = orientation; }
        public DefFrame Parent { get; }
        public Vector2D Position { get; set; }
        public Axis Orientation { get; set; } 
    }
}

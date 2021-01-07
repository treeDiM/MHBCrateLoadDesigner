#region Using directives
using System;
using System.Collections.Generic;

using Sharp3D.Math.Core;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class Project
    {
        public void GenerateSolution()
        {
            BuildNewCrateFrame(new Vector2D()) ;
            BuildNewCrateGlass(new Vector2D());
            BuildNewContainer(new Vector3D());
        }
        private InstCrateFrame BuildNewCrateFrame(Vector2D dimensions)
        {
            var crate = new InstCrateFrame() { };
            ListCrateFrame.Add(crate);
            return crate;
        }
        private InstCrateGlass BuildNewCrateGlass(Vector2D dimensions)
        {
            var crate = new InstCrateGlass() { };
            ListCrateGlass.Add(crate);
            return crate;
        }
        private InstContainer BuildNewContainer(Vector3D dimensions)
        {
            var container = new InstContainer() { };
            ListContainers.Add(container);
            return container;
        }
        public void Save(string filePath)
        {            
        }
        public void Load(string filePath)
        { 
        }
        public void Export(string filePath)
        { 
        }

        private List<DefCrate> ListDefCrates { get; set; } = new List<DefCrate>();
        private List<DefFrame> ListDefFrames { get; set; } = new List<DefFrame>();
        private List<DefContainer> ListDefContainers { get; set; } = new List<DefContainer>();

        private List<InstContainer> ListContainers { get; set; } = new List<InstContainer>();
        private List<InstCrateFrame> ListCrateFrame { get; set; } = new List<InstCrateFrame>();
        private List<InstCrateGlass> ListCrateGlass { get; set; } = new List<InstCrateGlass>();
    }
}

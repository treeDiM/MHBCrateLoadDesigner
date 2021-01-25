#region Using directives
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;

using Sharp3D.Math.Core;

using MHB.CrateLoadDesigner.Engine.Properties;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class Project
    {
        public void GenerateSolution()
        {
            // clear ListCrateFrame
            ListCrateFrame.Clear();

            // ### Frames ###
            // sort frames
            switch (SortingMethod)
            {
                case ESortingMethod.SORTLONGSHORT: ListDefFrames.OrderByDescending(f => f.LongSide)/*.ThenByDescending(f => f.ShortSide)*/; break;
                case ESortingMethod.SORTAREA: ListDefFrames.OrderByDescending(f => f.Area); break;
                case ESortingMethod.SORTPERIMETER: ListDefFrames.OrderByDescending(f => f.Perimeter); break;
                default: break;
            }

            // move frames that would not fit the first crate to the top
            DefCrate crate0 = ListDefCrates[0];
            ListDefFrames.OrderByDescending(f => crate0.CouldFitFrame(f) ? 0 : 1);

            // pack frames
            foreach (var f in ListDefFrames)
            {
                for (int i = 0; i < f.Number; ++i)
                {
                    // test in crates
                    bool packed = false;
                    foreach (var c in ListCrateFrame)
                    {
                        if (c.PackFrame(f, PackingMethod))
                        {
                            packed = true;
                            break;
                        }
                    }
                    if (!packed)
                    {
                        InstCrateFrame crate = BuildNewCrateFrame(f);
                        crate.PackFrame(f, PackingMethod);
                    }
                }
            }
            foreach (var crate in ListCrateFrame)
                crate.SortLayers();
            // ###

            // ### Glasses ###
            // sort glasses

            // pack glasses
            BuildNewCrateGlass(new Vector2D());

            // containers
            BuildNewContainer(new Vector3D());
        }
        private InstCrateFrame BuildNewCrateFrame(DefFrame frame)
        {
            InstCrateFrame crate = null;
            foreach (var defCrate in ListDefCrates)
            {
                if (defCrate.CouldFitFrame(frame))
                {
                    crate = defCrate.Instantiate(frame, (uint)ListCrateFrame.Count);
                    break;
                }
            }
            if (null == crate)
                throw new System.Exception($"Failed to build crate for frame {frame.Brand} with dimensions ({frame.LongSide}, {frame.ShortSide})");
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
            if (File.Exists(filePath))
                throw new FileNotFoundException(filePath);


        }
        public static Project LoadNewProject(string filePath)
        {
            var proj = new Project();
            // load crates
            string filePathCrates = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Crates.xml");
            using (var crateFileReader = new CrateFileReader())
            {
                if (!crateFileReader.LoadFile(filePathCrates, proj.ListDefCrates, proj.ListDefCrates, proj.ListDefContainers))
                    return null;
            }
            // load excel input file
            using (var fileReader = new InputFileReader())
            {
                if (!fileReader.LoadFile(filePath, proj.Name, proj.ListDefFrames, proj.ListDefGlass))
                    return null;
            }
            return proj;
        }

        public void Export(string filePath)
        { 
        }
        public enum GlassType { DOUBLEGLASSTEMPERED, DOUBLEGLASSLAMINATED, TRIPLEGLASSTEMPERED, TRIPLEGLASSLAMINATED };
        public static GlassType PGlassType { get; set; }
        public static double FrameThickness
        {
            get
            {
                switch (PGlassType)
                {
                    case GlassType.DOUBLEGLASSTEMPERED:
                    case GlassType.DOUBLEGLASSLAMINATED: return 88.0;
                    case GlassType.TRIPLEGLASSTEMPERED:
                    case GlassType.TRIPLEGLASSLAMINATED:  return 108.0;
                    default: throw new System.Exception($"Invalid GlassType: {PGlassType}");
                }
            } 
        }
        public static double GlassThickness
        {
            get
            {
                switch (PGlassType)
                {
                    case GlassType.DOUBLEGLASSTEMPERED: return 28.0;
                    case GlassType.DOUBLEGLASSLAMINATED: return 32.0;
                    case GlassType.TRIPLEGLASSTEMPERED: return 48.0; 
                    case GlassType.TRIPLEGLASSLAMINATED: return 48.8;
                    default: throw new System.Exception($"Invalid GlassType: {PGlassType}");
                }
            }
        }
        public static double FrameSpacing => 0.0;//Settings.Default.FrameSpacing;
        public static double FrameMargin => Settings.Default.FrameMargin;

        #region Data members
        public string Name { get; set; } = string.Empty;

        public List<DefFrame> ListDefFrames { get; set; } = new List<DefFrame>();
        public List<DefGlass> ListDefGlass { get; set; } = new List<DefGlass>();

        public List<DefCrate> ListDefCrates { get; set; } = new List<DefCrate>();
        private List<DefContainer> ListDefContainers { get; set; } = new List<DefContainer>();

        private List<InstContainer> ListContainers { get; set; } = new List<InstContainer>();
        public List<InstCrateFrame> ListCrateFrame { get; set; } = new List<InstCrateFrame>();
        public List<InstCrateGlass> ListCrateGlass { get; set; } = new List<InstCrateGlass>();

        public enum EPackingMethod { FIRSTFIT, BESTFIT };
        public enum ESortingMethod { SORTLONGSHORT, SORTAREA, SORTPERIMETER };

        public EPackingMethod PackingMethod { get; set; } = EPackingMethod.FIRSTFIT;
        public ESortingMethod SortingMethod { get; set; } = ESortingMethod.SORTLONGSHORT;
        #endregion
    }
}

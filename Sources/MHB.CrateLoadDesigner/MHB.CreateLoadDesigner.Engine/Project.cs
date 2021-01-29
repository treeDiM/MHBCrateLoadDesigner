#region Using directives
using System;
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

        public bool CanGenerateSolution(ref string message)
        {
            foreach (var defFrame in ListDefFrames)
            {
                bool packed = false;
                foreach (var defCrate in ListDefCratesFrame)
                {
                    if (defCrate.CouldFitFrame(defFrame))
                    {
                        packed = true;
                        break;
                    }
                }
                if (!packed)
                {
                    message = $"Frame {defFrame.Brand} ({defFrame.Width}x{defFrame.Height}) can not be packed with available crates.";
                    return false;
                }
            }

            foreach (var defGlass in ListDefGlass)
            {
                bool packed = false;
                foreach (var defCrate in ListDefCratesGlass)
                {
                    if (defCrate.CouldFitGlass(defGlass))
                    {
                        packed = true;
                        return false;
                    }
                }
                if (!packed)
                {
                    message = $"Glass {defGlass.Brand} ({defGlass.Width}x{defGlass.Height}) can not be packed with available crates.";
                    return false;

                }
            }
            return true;
        }
        public void GenerateSolution()
        {
            // clear ListCrateFrame
            ListCrateFrame.Clear();
            ListCrateGlass.Clear();

            // ### Frames ###
            // sort frames
            switch (SortingMethod)
            {
                case ESortingMethod.SORTLONGSHORT: ListDefFrames.OrderByDescending(f => f.LongSide).ThenByDescending(f => f.ShortSide); break;
                case ESortingMethod.SORTAREA: ListDefFrames.OrderByDescending(f => f.Area); break;
                case ESortingMethod.SORTPERIMETER: ListDefFrames.OrderByDescending(f => f.Perimeter); break;
                default: break;
            }

            // move frames that would not fit the first crate to the top
            DefCrateFrame crate0 = ListDefCratesFrame[0];
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
                        if (!crate.PackFrame(f, PackingMethod))
                            throw new Exception($"Failed to pack {f.Brand}");
                    }
                }
            }
            foreach (var crate in ListCrateFrame)
                crate.SortLayers();
            // ###

            // ### Glasses ###
            // sort glasses
            IEnumerable<DefGlass> listDefGlass = ListDefGlass.OrderByDescending(g => g.LongSide).ThenByDescending(g => g.ShortSide);

            // pack glasses
            foreach (var g in listDefGlass)
            {
                for (int i = 0; i < g.Number; ++i)
                {
                    bool packed = false;
                    foreach (var c in ListCrateGlass)
                    {
                        if (c.PackGlass(g))
                        {
                            packed = true;
                            break;
                        }
                    }
                    if (!packed)
                    {
                        InstCrateGlass cg = BuildNewCrateGlass(g);
                        if (!cg.PackGlass(g))
                            throw new Exception($"Failed to pack {g.Brand}");
                    }
                }
            }
        }
        private InstCrateFrame BuildNewCrateFrame(DefFrame frame)
        {
            InstCrateFrame crate = null;
            foreach (var defCrate in ListDefCratesFrame)
            {
                if (defCrate.CouldFitFrame(frame))
                {
                    crate = defCrate.Instantiate(frame, (uint)ListCrateFrame.Count);
                    break;
                }
            }
            if (null == crate)
                throw new Exception($"Failed to build crate for frame {frame.Brand} with dimensions ({frame.LongSide}, {frame.ShortSide})");
            ListCrateFrame.Add(crate);
            return crate;
        }
        private InstCrateGlass BuildNewCrateGlass(DefGlass glass)
        {
            InstCrateGlass crate = null;
            foreach (var defCrate in ListDefCratesGlass)
            {
                if (defCrate.CouldFitGlass(glass))
                {
                    crate = defCrate.Instantiate(glass, (uint)(ListCrateFrame.Count + ListCrateGlass.Count));
                    break;
                }
            }
            if (null == crate)
                throw new Exception($"Failed to build crate for frame {glass.Brand} with dimensions ({glass.LongSide}, {glass.ShortSide})");
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
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);


        }
        public static Project LoadNewProject(string filePath)
        {
            var proj = new Project();
            // load crates
            string filePathCrates = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Crates.xml");
            using (var crateFileReader = new CrateFileReader())
            {
                if (!crateFileReader.LoadFile(filePathCrates, proj.ListDefCratesFrame, proj.ListDefCratesGlass, proj.ListDefContainers))
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

        public List<DefCrateFrame> ListDefCratesFrame { get; set; } = new List<DefCrateFrame>();
        public List<DefCrateGlass> ListDefCratesGlass { get; set; } = new List<DefCrateGlass>();
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

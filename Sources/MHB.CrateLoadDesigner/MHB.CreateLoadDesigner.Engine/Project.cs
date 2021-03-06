﻿#region Using directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using Sharp3D.Math.Core;

using MHB.CrateLoadDesigner.Engine.Properties;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class Project
    {
        #region Events 
        public delegate void DelegateSolutionUpdated(Project proj);
        public event DelegateSolutionUpdated SolutionUpdated;
        #endregion

        #region Validity checking
        public bool IsValid(out string reasonInvalid)
        {
            reasonInvalid = string.Empty;
            if (ListDefCratesFrame.Count == 0)
            { reasonInvalid = "No crates for frames were loaded."; return false; }
            else if (ListDefCratesGlass.Count == 0)
            { reasonInvalid = "No crates for glass were loaded."; return false; }
            else if (ListDefContainers.Count == 0)
            { reasonInvalid = "No containers were loaded."; return false; }
            else if (ListDefFrames.Count + ListDefGlass.Count == 0)
            { reasonInvalid = "No items to load."; return false; }
            else if (!CanGenerateSolution(ref reasonInvalid))
            { return false; }
            else
                return true;
        }
        private bool CanGenerateSolution(ref string message)
        {
            foreach (var defFrame in ListDefFrames)
            {
                bool packed = false;
                foreach (var defCrate in ListDefCratesFrame)
                {
                    if (defCrate.CanFitFrame(defFrame))
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
                    if (defCrate.CanFitGlass(defGlass))
                    {
                        packed = true;
                        break;
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
        public bool CanFitFrame(double width, double height)
        {
            foreach (var defCrate in ListDefCratesFrame)
            {
                if (defCrate.CanFitFrame(width, height))
                    return true;
            }
            return false;
        }
        public bool CanFitGlass(double width, double height)
        {
            foreach (var defCrate in ListDefCratesGlass)
            {
                if (defCrate.CanFitGlass(width, height))
                    return true;
            }
            return false;
        }

        public void InsertFrame(string brand, string description, double width, double height, int number)
        {
            uint maxId = (from f in ListDefFrames select f.ID).Max();
            ListDefFrames.Add(new DefFrame()
                {
                ID = maxId+1,
                Brand = brand,
                Description = description,
                Width = width,
                Height = height,
                Number = number
                }
            );
            GenerateSolution();
        }
        public void RemoveFrame(int index)
        {
            ListDefFrames.RemoveAt(index);
            GenerateSolution();
        }
        public void InsertGlass(string brand, double width, double height, int number)
        {
            ListDefGlass.Add(new DefGlass()
            {
                Brand = brand,
                Width = width,
                Height = height,
                Number = number
            }
            );
            GenerateSolution();
        }
        public void RemoveGlass(int index)
        {
            ListDefGlass.RemoveAt(index);
            GenerateSolution();
        }
        #endregion
        #region Generate solution
        public void GenerateSolution()
        {
            // clear ListCrateFrame
            ListCrateFrame.Clear();
            ListCrateGlass.Clear();
            ListContainers.Clear();

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
            ListDefFrames = ListDefFrames.OrderByDescending(f => crate0.CanFitFrame(f) ? 0 : 1).ToList();

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
            // clear and rebuild glass crates
            foreach (var c in ListCrateGlass)
                c.GlassPositions.Clear();
            ListCrateGlass.Reverse();

            var listDefGlassAsc = ListDefGlass.OrderBy(g => g.LongSide).ThenBy(g => g.ShortSide);
            foreach (var g in listDefGlassAsc)
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
                    // if we successfully packed in previous step
                    // there is no reason why a glass should not be packed by now
                    if (!packed)
                        throw new Exception($"Failed to pack {g.Brand} while repacking");
                }
            }
            // reorder crate content
            foreach (var c in ListCrateGlass)
                c.ReorderContent();
            // ###

            // ### Crates -> containers
            List<InstCrate> listCrates = new List<InstCrate>();
            listCrates.AddRange(ListCrateFrame);
            listCrates.AddRange(ListCrateGlass);

            // split crates between those that exceed 40HC height and those who don't
            DefContainer container40HC = GetContainerByName("40HC");
            if (null == container40HC) throw new Exception("Container 40HC could not be found in container list.");
            double extremeHeight = container40HC.DimensionsInner.Z;

            PackListOfCrates(listCrates.Where(c => c.OuterDimensions.Z <= extremeHeight).ToList(), "40HC");
            PackListOfCrates(listCrates.Where(c => c.OuterDimensions.Z > extremeHeight).ToList(), "listCratesExtreme");

            // replace "40HC" with "20Box" when possible
            DownSizeContainer("40HC", "20Box");
            // replace "40OT" with "20OT" when possible
            DownSizeContainer("40OT", "20OT");
            // ### 

            SolutionUpdated?.Invoke(this);
        }
        private void PackListOfCrates(List<InstCrate> listCrates, string containerName)
        {
            foreach (var crate in listCrates)
            {
                bool packed = false;
                foreach (var container in ListContainers)
                {
                    if (container.PackCrate(crate))
                    {
                        packed = true;
                        break;
                    }
                }
                if (!packed)
                {
                    InstContainer cont = BuildNewContainer(containerName, crate.OuterDimensions);
                    if (!cont.PackCrate(crate))
                        throw new Exception($"Failed to pack crate {crate.ID}");
                }
            }
        }
        private void DownSizeContainer(string nameInit, string nameReplacement)
        {
            var listContainer = ListContainers.Where(c => c.ParentDef.Name == nameInit);
            var defContainerReplacement = GetContainerByName(nameReplacement);
            foreach (var container in listContainer)
            {
                if (defContainerReplacement.CanFitCrate(container.LoadBBox.Dimensions))
                    container.ParentDef = defContainerReplacement;
            }
        }

        #region Crate/container instantiation
        private DefContainer GetContainerByName(string name) => ListDefContainers.Single(c => c.Name == name);

        private InstCrateFrame BuildNewCrateFrame(DefFrame frame)
        {
            InstCrateFrame crate = null;
            foreach (var defCrate in ListDefCratesFrame)
            {
                if (defCrate.CanFitFrame(frame))
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
                if (defCrate.CanFitGlass(glass))
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
        private InstContainer BuildNewContainer(string containerName, Vector3D dimensions)
        {
            var defContainer = GetContainerByName(containerName);
            if (!defContainer.CanFitCrate(dimensions))
                throw new Exception($"Failed to build container for crate {dimensions}");
            InstContainer container = defContainer.Instantiate((uint)ListContainers.Count);
            ListContainers.Add(container);
            return container;
        }
        #endregion
        #endregion
        #region Instantiate / Save / Load
        public static Project Instantiate()
        {
            Project proj = new Project();
            proj.LoadCrates();
            return proj;
        }
        public void Save(string filePath)
        {
        }
        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);

            // To read the file, create a FileStream.  
            FileStream fStream = new FileStream(filePath, FileMode.Open);
            // Construct an instance of the XmlSerializer with the type  of object that is being deserialized.  
            //XmlSerializer listCrateFrameSerializer = new XmlSerializer(typeof(ProjectRoot));
        }
        #endregion
        #region Public properties
        public int NoCrates => ListCrateFrame.Count + ListCrateGlass.Count;
        #endregion
        #region Input data loading
        private bool LoadCrates()
        {
            // load crates
            using (var crateFileReader = new CrateFileReader())
            {
                if (!crateFileReader.LoadFile(Settings.Default.CratesFilePath, ListDefCratesFrame, ListDefCratesGlass, ListDefContainers))
                    return false;
            }
            return true;
        }
        public bool LoadInputFileExcel(string filePath)
        {
            // load excel input file
            using (var fileReader = new InputFileReader())
            {
                string projName = string.Empty;
                if (!fileReader.LoadFile(filePath, ref projName, ListDefFrames, ListDefGlass))
                    return false;
                Name = projName;
            }
            return true;
        }
        #endregion
        #region Static data members
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
                    default: throw new Exception($"Invalid GlassType: {PGlassType}");
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
                    default: throw new Exception($"Invalid GlassType: {PGlassType}");
                }
            }
        }
        public static double FrameSpacing => Settings.Default.FrameSpacing;
        public static double FrameMargin => Settings.Default.FrameMargin;
        #endregion
        #region Data members
        public string Name { get; set; } = string.Empty;

        public List<DefFrame> ListDefFrames { get; set; } = new List<DefFrame>();
        public List<DefGlass> ListDefGlass { get; set; } = new List<DefGlass>();

        public List<DefCrateFrame> ListDefCratesFrame { get; set; } = new List<DefCrateFrame>();
        public List<DefCrateGlass> ListDefCratesGlass { get; set; } = new List<DefCrateGlass>();
        public List<DefContainer> ListDefContainers { get; set; } = new List<DefContainer>();

        public List<InstContainer> ListContainers { get; set; } = new List<InstContainer>();
        public List<InstCrateFrame> ListCrateFrame { get; set; } = new List<InstCrateFrame>();
        public List<InstCrateGlass> ListCrateGlass { get; set; } = new List<InstCrateGlass>();

        public enum EPackingMethod { FIRSTFIT, BESTFIT };
        public enum ESortingMethod { SORTLONGSHORT, SORTAREA, SORTPERIMETER };

        public EPackingMethod PackingMethod { get; set; } = EPackingMethod.FIRSTFIT;
        public ESortingMethod SortingMethod { get; set; } = ESortingMethod.SORTLONGSHORT;
        #endregion
    }
}

#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

using Sharp3D.Math.Core;
using RectangleBinPack;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class InstCrateFrame
    {
        internal InstCrateFrame(uint id, Vector2D maxUnitDimensions, int noLayers)
        {
            ID = id;
            MaxUnitDimensions = maxUnitDimensions;
            // add empty layers
            Layers = new List<Layer>();
            for (int i = 0; i < noLayers; ++i)
                Layers.Add(new Layer() { ParentCrate = this });
        }
        public uint ID { get; }
        public Vector2D MaxUnitDimensions { get; set; }
        public Vector3D OuterDimensions { get; set; }
        public List<Layer> Layers { get; }
 
        public bool PackFrame(DefFrame defFrame, Project.EPackingMethod packingMethod)
        {
            switch (packingMethod)
            {
                case Project.EPackingMethod.FIRSTFIT:
                    foreach (var layer in Layers)
                    {
                        double efficiency = 0.0;
                        if (layer.CanPack(defFrame, ref efficiency))
                        {
                            layer.Pack(defFrame);
                            return true;
                        }
                    }
                    break;
                case Project.EPackingMethod.BESTFIT:
                    {
                        var results = new Dictionary<int, double>();
                        // test with all layers 
                        foreach (var layer in Layers)
                        {
                            int index = 0;
                            double efficiency = 0.0;
                            if (layer.CanPack(defFrame, ref efficiency))
                            {
                                results[index] = efficiency;
                            }
                            ++index;
                        }
                        if (results.Keys.Count > 0)
                        {
                            int indexMax = results.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
                            var bestLayer = Layers[indexMax];
                            bestLayer.Pack(defFrame);
                            return true;
                        }
                    }
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            // failed to pack frame in this crate
            return false;
        }

        public void SortLayers() { Layers.OrderBy(l => l.Weight); }
        public double Weight => Layers.Select(l => l.Weight).Sum();
        public int NoFrames => Layers.Select(l => l.Count).Sum();
    }

    public class Layer : List<FramePosition>
    {
        #region Constructor
        public Layer() {}
        #endregion

        #region 
        public InstCrateFrame ParentCrate { get; set; }
        public string LastAlgorithmUsed { get; set; }
        public double Weight => this.Select(f => f.Parent.Perimeter).Sum();
        public bool IsEmpty => Count == 0;
        private List<RectSize> RectSizes(DefFrame additionalFrame)
        {
            List<RectSize> rectSizes = new List<RectSize>();
            // current frame(s)
            foreach (var fp in this)
                rectSizes.Add(new RectSize((int)fp.Parent.LongSide, (int)fp.Parent.ShortSide));
            // insert new frame
            rectSizes.Add(new RectSize((int)additionalFrame.LongSide, (int)additionalFrame.ShortSide));
                return rectSizes;
        }
        #endregion

        #region Packing methods
        public bool CanPack(DefFrame defFrame, ref double efficiency)
        {
            var rects = new List<Rect>();
            string algorithm = string.Empty;
            return BinPacker.Pack((int)ParentCrate.MaxUnitDimensions.X, (int)ParentCrate.MaxUnitDimensions.Y, RectSizes(defFrame), ref rects, ref efficiency, ref algorithm);
        }
        public void Pack(DefFrame defFrame)
        {
            var rects = new List<Rect>();
            string algorithm = string.Empty;
            double efficiency = 0.0;
            if (BinPacker.Pack((int)ParentCrate.MaxUnitDimensions.X, (int)ParentCrate.MaxUnitDimensions.Y, RectSizes(defFrame), ref rects, ref efficiency, ref algorithm))
            {
                List<DefFrame> frames = this.Select(item => item.Parent).ToList();
                frames.Add(defFrame);
                Clear();

                LastAlgorithmUsed = algorithm;
                int index = 0;
                foreach (var rect in rects)
                {
                    DefFrame f = frames[index++];
                    FramePosition fp = null;
                    if (rect.Width == (int)f.Width && rect.Height == (int)f.Height)
                    {
                        fp = new FramePosition(f, new Vector2D(rect.X, rect.Y), FramePosition.Axis.XP);
                    }
                    else if (rect.Width == (int)f.Height && rect.Height == (int)f.Width)
                    {
                        fp = new FramePosition(f, new Vector2D(rect.X + rect.Height, rect.Y), FramePosition.Axis.XP);
                    }
                    else
                        throw new Exception($"Pack failed for ({rect.Width}, {rect.Height})");

                    Add(fp);
                }
            }
        }
        #endregion

        #region Helpers
        #endregion
    }
}

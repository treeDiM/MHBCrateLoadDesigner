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
        internal InstCrateFrame(uint id, Vector2D maxUnitDimensions, int noLayers, bool isSkid = false)
        {
            ID = id;
            MaxUnitDimensions = maxUnitDimensions;
            // add empty layers
            Layers = new List<Layer>();
            for (int i = 0; i < noLayers; ++i)
                Layers.Add(new Layer() { ParentCrate = this });
            // is skid?
            IsSkid = isSkid;
        }
        public bool IsSkid { get; private set; } = false;
        public uint ID { get; }
        public Vector2D MaxUnitDimensions { get; set; }
        public Vector3D OuterDimensions { get; set; }
        public List<Layer> Layers { get; private set; }
        public Dictionary<DefFrame, int> ContentDict
        {
            get
            {
                var listDefFrame = new List<DefFrame>();
                foreach (var layer in Layers)
                {
                    foreach (var fp in layer)
                    {
                        listDefFrame.Add(fp.Parent);
                    }
                }
                var dict = listDefFrame
                    .GroupBy(f => f)
                    .Select(f => new {
                        Frame = f.Key,
                        Count = f.Count()
                    });
                return dict.ToDictionary(g => g.Frame, g => g.Count);
            }
        }
 
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

        public void SortLayers()
        {
            Layers = Layers.OrderByDescending(l => l.Weight).ToList();
        }
        public double Weight => Layers.Select(l => l.Weight).Sum();
        public int NoFrames => Layers.Select(l => l.Count).Sum();
        public double LayerZ(int index)
        {
            double thickness = Project.FrameThickness;
            double h1 = 80.0, h2 = 32.0;
            if (IsSkid) { h1 = 0; h2 = 0; }
            return index * thickness + ((index+2)/3) * h1 + index * h2 - ((index+2)/3) * h2;
        }
    }

    public class Layer : List<FramePosition>
    {
        #region Constructor
        public Layer() {}
        #endregion

        #region Public properties
        public InstCrateFrame ParentCrate { get; set; }
        public string LastAlgorithmUsed { get; set; }
        public double Weight => this.Select(f => f.Parent.Perimeter).Sum();
        public bool IsEmpty => Count == 0;

        #endregion

        #region Packing methods
        private int BinWidth => (int)(ParentCrate.MaxUnitDimensions.X + Project.FrameSpacing);
        private int BinHeight => (int)(ParentCrate.MaxUnitDimensions.Y + Project.FrameSpacing); 

        public bool CanPack(DefFrame defFrame, ref double efficiency)
        {
            if (Count == 1 && ParentCrate.IsSkid)
                return false;
            var rects = new List<Rect>();
            string algorithm = string.Empty;
            return BinPacker.Pack(BinWidth, BinHeight, RectSizes(defFrame), ref rects, ref efficiency, ref algorithm);
        }
        public void Pack(DefFrame defFrame)
        {
            var rects = new List<Rect>();
            string algorithm = string.Empty;
            double spacing = Project.FrameSpacing;
            double halfSpacing = 0.5 * spacing;
            double efficiency = 0.0;

            Rect rectLayer = new Rect()
            {
                X = 0,
                Y = 0,
                Width = (int)(ParentCrate.MaxUnitDimensions.X + spacing),
                Height = (int)(ParentCrate.MaxUnitDimensions.Y + spacing) 
            };

            if (BinPacker.Pack(BinWidth, BinHeight, RectSizes(defFrame), ref rects, ref efficiency, ref algorithm))
            {
                List<DefFrame> frames = this.Select(item => item.Parent).ToList();
                frames.Add(defFrame);
                Clear();

                BBox2D bbox = new BBox2D(rects);
                double offsetX = (ParentCrate.OuterDimensions.X - bbox.Width)/2 + halfSpacing;
                double offsetY = (ParentCrate.OuterDimensions.Y - bbox.Height)/2 + halfSpacing;

                LastAlgorithmUsed = algorithm;
                int index = 0;
                foreach (var rect in rects)
                {
                    if (!Rect.IsContainedIn(rect, rectLayer))
                        throw new Exception($"{rect} not contained in {rectLayer}");

                    DefFrame f = frames[index++];
                    FramePosition fp = null;

                    if (rect.Width == (int)(f.Width + spacing) && rect.Height == (int)(f.Height + spacing))
                    {
                        fp = new FramePosition(f, new Vector2D(rect.X + offsetX, rect.Y + offsetY), FramePosition.Axis.XP);
                    }
                    else if (rect.Width == (int)(f.Height + spacing) && rect.Height == (int)(f.Width + spacing))
                    {
                        fp = new FramePosition(f, new Vector2D(rect.X + f.Height + offsetX, rect.Y + offsetY), FramePosition.Axis.YP);
                    }
                    else
                        throw new Exception($"Pack failed for ({rect.Width}, {rect.Height})");

                    Add(fp);
                }
            }
        }
        private List<RectSize> RectSizes(DefFrame additionalFrame)
        {
            List<RectSize> rectSizes = new List<RectSize>();

            double spacing = Project.FrameSpacing;
            // current frame(s)
            foreach (var fp in this)
                rectSizes.Add(new RectSize((int)(fp.Parent.LongSide + spacing), (int)(fp.Parent.ShortSide + spacing)));
            // insert new frame
            rectSizes.Add(new RectSize((int)(additionalFrame.LongSide + spacing), (int)(additionalFrame.ShortSide + spacing)));
                return rectSizes;
        }

        public Dictionary<DefFrame, int> ContentDict
        {
            get
            {
                var listDefFrame = new List<DefFrame>();
                foreach (var fp in this)
                    listDefFrame.Add(fp.Parent);
                var dict = listDefFrame
                    .GroupBy(gp => gp)
                    .Select(gp => new {
                        Glass = gp.Key,
                        Count = gp.Count()
                    });
                return dict.ToDictionary(g => g.Glass, g => g.Count);
            }
        }
        #endregion
    }
}

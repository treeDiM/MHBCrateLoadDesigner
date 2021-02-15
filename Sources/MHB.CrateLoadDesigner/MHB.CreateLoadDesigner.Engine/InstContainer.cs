#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;

using Sharp3D.Math.Core;

using RectangleBinPack;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    public class InstContainer
    {
        internal InstContainer(uint id, DefContainer defContainer)
        {
            ID = id;
            ParentDef = defContainer;
        }
        public uint ID { get; }
        public Vector3D InnerDimensions => ParentDef.DimensionsInner;
        public bool HasOpenTop => ParentDef.RoofOpeningLength > 0 && ParentDef.RoofOpeningWidth > 0;
        private DefContainer ParentDef { get; set; }
        private string LastAlgorithmUsed { get; set; }
        public bool PackCrate(InstCrate crate)
        {
            var rects = new List<Rect>();
            string algorithm = string.Empty;
            double efficiency = 0.0;

            Rect rectContainer = new Rect()
            {
                X = 0,
                Y = 0,
                Width = (int)ParentDef.DimensionsInner.X,
                Height = (int)ParentDef.DimensionsInner.Y
            };

            if (BinPacker.Pack(BinWidth, BinHeight, RectSizes(crate), ref rects, ref efficiency, ref algorithm))
            {
                var crates = CratePositions.Select(item => item.Crate).ToList();
                crates.Add(crate);
                CratePositions.Clear();

                LastAlgorithmUsed = algorithm;
                int index = 0;
                foreach (var rect in rects)
                {
                    if (!Rect.IsContainedIn(rect, rectContainer))
                        throw new Exception($"{rect} not contained in {rectContainer}");

                    InstCrate c = crates[index++];
                    CratePosition cp = null;

                    if (rect.Width == (int)c.Length && rect.Height == (int)c.Width)
                    {
                        cp = new CratePosition(new Vector2D(rect.X, rect.Y), BasePosition.Axis.XP, c);
                    }
                    else if (rect.Width == (int)c.Width && rect.Height == (int)c.Length)
                    {
                        cp = new CratePosition(new Vector2D(rect.X + c.Width, rect.Y), BasePosition.Axis.YP, c);
                    }
                    else
                        throw new Exception($"Pack failed for crate ({rect.Width}, {rect.Height})");
                    CratePositions.Add(cp);
                }
                return true;
            }
            return false;
        }
        private List<RectSize> RectSizes(InstCrate crate)
        {
            var rectSizes = new List<RectSize>();
            // current crate(s)
            foreach (var cp in CratePositions)
                rectSizes.Add(new RectSize((int)cp.Crate.OuterDimensions.X, (int)cp.Crate.OuterDimensions.Y));
            // insert new crate
            rectSizes.Add(new RectSize((int)crate.OuterDimensions.X, (int)crate.OuterDimensions.Y));

            return rectSizes;
        }
        private int BinWidth => (int)InnerDimensions.X;
        private int BinHeight => (int)InnerDimensions.Y;
        public Vector3D Dimensions => ParentDef.DimensionsInner;
        public List<CratePosition> CratePositions { get; set; } = new List<CratePosition>();
    }
}

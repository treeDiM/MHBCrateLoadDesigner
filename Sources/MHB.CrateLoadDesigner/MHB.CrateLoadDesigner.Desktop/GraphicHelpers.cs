#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using MHB.CrateLoadDesigner.Engine;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    internal class GraphicHelpers
    {
        public static List<Box> LayerToBoxes(Layer layer, double z, ref uint pickId)
        {
            var boxes = new List<Box>();
            double thickness = Project.FrameThickness;
            foreach (var fp in layer)
            {
                Vector3D position = new Vector3D(fp.Position.X, fp.Position.Y, z);
                var box = new Box(pickId++, fp.Parent.Width, fp.Parent.Height, thickness)
                {
                    BoxPosition = new BoxPosition(position, LengthAxis(fp.Orientation), WidthAxis(fp.Orientation))
                };
                box.SetAllFacesColor(Color.LightBlue);
                box.SetFaceColor(HalfAxis.HAxis.AXIS_Z_N, Color.LightGray);
                box.SetFaceColor(HalfAxis.HAxis.AXIS_Z_P, Color.LightGray);
                boxes.Add(box);
            }
            return boxes;
        }
        public static List<Box> CrateToBoxes(InstCrateFrame crate)
        {
            var boxes = new List<Box>();
            uint pickId = 0;
            int layerIndex = 0;
            foreach (var layer in crate.Layers)
            {
                if (layer.Count > 0)
                    boxes.AddRange(LayerToBoxes(layer, crate.LayerZ(layerIndex++), ref pickId));
            }
            return boxes;
        }
        public static List<Box> CrateToBoxes(InstCrateGlass crate)
        {
            var boxes = new List<Box>();
            uint pickId = 0;
            double initialY = 100.0;
            double spacing = 40.0;
            
            foreach (var p in crate.GlassPositions)
            {
                var box = new Box(pickId++, p.Parent.Width, p.Parent.Height, Project.GlassThickness)
                {
                    BoxPosition = new BoxPosition(
                        new Vector3D(
                            p.Rotated ? p.Parent.Height : 0.0,
                            initialY + pickId * (Project.GlassThickness + spacing),
                            0.0),
                        p.Rotated ? HalfAxis.HAxis.AXIS_Z_P : HalfAxis.HAxis.AXIS_X_P,
                        p.Rotated ? HalfAxis.HAxis.AXIS_X_N: HalfAxis.HAxis.AXIS_Z_P)
                };
                box.SetAllFacesColor(Color.LightBlue);
                boxes.Add(box);
            }
            return boxes;
        }

        private static HalfAxis.HAxis LengthAxis(FramePosition.Axis axis)
        {
            switch (axis)
            {
                case FramePosition.Axis.XP: return HalfAxis.HAxis.AXIS_X_P;
                case FramePosition.Axis.YP: return HalfAxis.HAxis.AXIS_Y_P;
                case FramePosition.Axis.XN: return HalfAxis.HAxis.AXIS_X_N;
                case FramePosition.Axis.YN: return HalfAxis.HAxis.AXIS_Y_N;
                default: throw new Exception("Invalid FormPosition.Axis");
            }

        }
        private static HalfAxis.HAxis WidthAxis(FramePosition.Axis axis)
        {
            switch (axis)
            {
                case FramePosition.Axis.XP: return HalfAxis.HAxis.AXIS_Y_P;
                case FramePosition.Axis.YP: return HalfAxis.HAxis.AXIS_X_N;
                case FramePosition.Axis.XN: return HalfAxis.HAxis.AXIS_Y_N;
                case FramePosition.Axis.YN: return HalfAxis.HAxis.AXIS_X_P;
                default: throw new Exception("Invalid FormPosition.Axis");
            }

        }
    }
}

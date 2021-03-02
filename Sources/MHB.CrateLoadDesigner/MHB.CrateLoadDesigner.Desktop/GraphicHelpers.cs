#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

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
            
            foreach (var p in crate.GlassPositions)
            {
                // compute X position so that glass appears centered
                double xPos = 0.5 * ( crate.OuterDimensions.X - (p.Rotated ? p.Parent.Height : p.Parent.Width) );
                var box = new Box(pickId++, p.Parent.Width, p.Parent.Height, Project.GlassThickness)
                {
                    BoxPosition = new BoxPosition(
                        new Vector3D(
                            xPos + (p.Rotated ? p.Parent.Height : 0.0),
                            initialY + pickId * (Project.GlassThickness + crate.Spacing),
                            0.0),
                        p.Rotated ? HalfAxis.HAxis.AXIS_Z_P : HalfAxis.HAxis.AXIS_X_P,
                        p.Rotated ? HalfAxis.HAxis.AXIS_X_N: HalfAxis.HAxis.AXIS_Z_P)
                };
                box.SetAllFacesColor(Color.LightBlue);
                boxes.Add(box);
            }
            return boxes;
        }
        public static List<BoxExplicitDir> CrateToBoxesExplicitDir(InstCrateGlass crate, double angle)
        {
            var boxes = new List<BoxExplicitDir>();
            uint pickId = 0;

            foreach (var p in crate.GlassPositions)
            {
                double xPos = 0.0, yPos = 0.0;
                Vector3D xAxis = Vector3D.XAxis;
                Vector3D yAxis = Vector3D.Zero;

                double angleRad = angle * Math.PI / 180.0;
                double yStep = (Project.GlassThickness + crate.Spacing) / Math.Cos(angleRad);

                if (pickId % 2 == 0)
                {
                    int row = ((int)pickId) / 2;
                    xPos = 0.5 * (crate.OuterDimensions.X - p.Parent.ShortSide);
                    yPos = 0.5 * crate.OuterDimensions.Y - ( p.Parent.LongSide * Math.Sin(angleRad) + row * yStep);
                    xAxis = Vector3D.XAxis;
                    yAxis = new Vector3D(0.0, Math.Sin(angleRad), Math.Cos(angleRad));
                }
                else
                {
                    int row = ((int)pickId)/ 2 - 1;
                    xPos = 0.5 * (crate.OuterDimensions.X + p.Parent.ShortSide);
                    yPos = 0.5 * crate.OuterDimensions.Y + p.Parent.LongSide * Math.Sin(angleRad) + row * yStep;
                    xAxis = -Vector3D.XAxis;
                    yAxis = new Vector3D(0.0, -Math.Sin(angleRad), Math.Cos(angleRad));
                }

                boxes.Add( new BoxExplicitDir(pickId++,
                    p.Parent.ShortSide, p.Parent.LongSide, Project.GlassThickness,
                    new Vector3D(xPos, yPos, 0.0),
                    xAxis, yAxis, Color.LightBlue
                    ));
            }
            return boxes;
        }
        public static List<Box> ContainerToBoxes(InstContainer container)
        {
            var boxes = new List<Box>();
            uint pickId = 0;
            foreach (var cp in container.CratePositions)
            {
                var box = new Box(pickId++, cp.Crate.OuterDimensions.X, cp.Crate.OuterDimensions.Y, cp.Crate.OuterDimensions.Z)
                {
                    BoxPosition = new BoxPosition(new Vector3D(cp.Position.X, cp.Position.Y, 0.0), LengthAxis(cp.Orientation), WidthAxis(cp.Orientation))
                };
                box.SetAllFacesColor(Color.Beige);
                boxes.Add(box);
            }
            return boxes;
        }

        private static HalfAxis.HAxis LengthAxis(FramePosition.Axis axis)
        {
            switch (axis)
            {
                case BasePosition.Axis.XP: return HalfAxis.HAxis.AXIS_X_P;
                case BasePosition.Axis.YP: return HalfAxis.HAxis.AXIS_Y_P;
                case BasePosition.Axis.XN: return HalfAxis.HAxis.AXIS_X_N;
                case BasePosition.Axis.YN: return HalfAxis.HAxis.AXIS_Y_N;
                default: throw new Exception("Invalid FormPosition.Axis");
            }

        }
        private static HalfAxis.HAxis WidthAxis(FramePosition.Axis axis)
        {
            switch (axis)
            {
                case BasePosition.Axis.XP: return HalfAxis.HAxis.AXIS_Y_P;
                case BasePosition.Axis.YP: return HalfAxis.HAxis.AXIS_X_N;
                case BasePosition.Axis.XN: return HalfAxis.HAxis.AXIS_Y_N;
                case BasePosition.Axis.YN: return HalfAxis.HAxis.AXIS_X_P;
                default: throw new Exception("Invalid FormPosition.Axis");
            }
        }
    }
}

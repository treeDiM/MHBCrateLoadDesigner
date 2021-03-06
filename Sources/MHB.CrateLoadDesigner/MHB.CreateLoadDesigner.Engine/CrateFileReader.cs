﻿#region Using directives
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System;

using Sharp3D.Math.Core;

using MHB.CrateLoadDesigner.Engine.XML;
#endregion

namespace MHB.CrateLoadDesigner.Engine
{
    internal class CrateFileReader : IDisposable
    {
        public bool LoadFile(string filePath, List<DefCrateFrame> listFrameCrates, List<DefCrateGlass> listGlassCrates, List<DefContainer> listContainers)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);
            // To read the file, create a FileStream.  
            FileStream fStream = new FileStream(filePath, FileMode.Open);
            // Construct an instance of the XmlSerializer with the type  of object that is being deserialized.  
            XmlSerializer listCrateFrameSerializer = new XmlSerializer(typeof(Root));
            // Call the Deserialize method and cast to the object type.  
            var root = (Root)listCrateFrameSerializer.Deserialize(fStream);

            foreach (var crateFrame in root.ListCrateFrame)
            {
                listFrameCrates.Add(new DefCrateFrame()
                {
                    Name = crateFrame.crateName,
                    CrateType = crateFrame.crateType == enuCrateTypeFrame.SKID ? DefCrateFrame.EType.SKID : DefCrateFrame.EType.CRATE,
                    MaxLongSide = crateFrame.maxLongSide,
                    MaxShortSide = crateFrame.maxShortSide,
                    DimensionsOuter = new Vector3D(crateFrame.crateLength, crateFrame.crateWidth, crateFrame.crateHeight),
                    MaxNumberOfLayers = new int[] { crateFrame.maxQuantityCP80, crateFrame.maxQuantityCP100 },
                    DynResizing = crateFrame.dynMaxLengthSpecified,
                    DynMaxLength = crateFrame.dynAdditionalLengthSpecified ? crateFrame.dynMaxLength : (double?)null,
                    DynAdditionalLength = crateFrame.dynMaxLengthSpecified ? crateFrame.dynAdditionalLength : (double?)null
                }
                );
            }
            foreach (var crateGlass in root.ListCrateGlass)
            {
                listGlassCrates.Add(new DefCrateGlass()
                {
                    Name = crateGlass.crateName,
                    Description = crateGlass.crateDescription,
                    MaxLongSide = crateGlass.maxLongSide,
                    MaxShortSide = crateGlass.maxShortSide,
                    DimensionsOuter = new Vector3D(crateGlass.crateLength, crateGlass.crateWidth, crateGlass.crateHeight),
                    MaxQuantity = new int[] { crateGlass.maxQuantityDoubleGlass, crateGlass.maxQuantityTripleGlass },
                    DynResizing = crateGlass.dynMaxLengthSpecified,
                    DynMaxLength = crateGlass.dynMaxLengthSpecified ? crateGlass.dynMaxLength : (double?)null,
                    DynAdditionalLength = crateGlass.dynMaxLengthSpecified ? crateGlass.dynAdditionalLength : (double?)null,
                    Spacing = crateGlass.spacing,
                    CrateType = crateGlass.crateType == enuCrateTypeGlass.AFRAME ? DefCrateGlass.EType.AFRAME : DefCrateGlass.EType.VERTICAL
                }
                );
            }
            foreach (var container in root.ListContainer)
            {
                listContainers.Add(new DefContainer()
                {
                    Name = container.containerName,
                    Description = container.containerDescription,
                    Remark = container.remark,
                    DimensionsInner = new Vector3D(container.insideLength, container.insideWidth, container.insideHeight),
                    OpeningWidth = container.openingWidth,
                    OpeningHeight = container.openingHeight,
                    RoofOpeningLength = container.roofOpeningLength,
                    RoofOpeningWidth = container.roofOpeningWidth,
                    Payload = container.payload,
                    EmptyWeight = container.emptyWeight
                }
                    );
            }
            return listFrameCrates.Count > 0 && listGlassCrates.Count > 0 && listContainers.Count > 0;
        }

        public void Dispose()
        {
        }
    }
}

#region Using directives
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
        public bool LoadFile(string filePath, List<DefCrate> listFrameCrates, List<DefCrate> listGlassCrates, List<DefContainer> listContainers)
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
                listFrameCrates.Add(new DefCrate()
                {
                    Name = crateFrame.crateName,
                    CrateType = crateFrame.crateType == enuCrateType.SKID ? DefCrate.EType.SKID : DefCrate.EType.CRATE,
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
                listGlassCrates.Add(new DefCrate()
                {
                    Name = crateGlass.crateName,
                    MaxLongSide = crateGlass.maxLongSide,
                    MaxShortSide = crateGlass.maxShortSide,
                    DimensionsOuter = new Vector3D(crateGlass.crateLength, crateGlass.crateWidth, crateGlass.crateHeight),
                    MaxNumberOfLayers = new int[] { crateGlass.maxQuantityDoubleGlass, crateGlass.maxQuantityTripleGlass },
                    DynResizing = crateGlass.dynMaxLengthSpecified,
                    DynMaxLength = crateGlass.dynMaxLengthSpecified ? crateGlass.dynMaxLength : (double?)null,
                    DynAdditionalLength = crateGlass.dynMaxLengthSpecified ? crateGlass.dynAdditionalLength : (double?)null
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
                    DimensionsInner = new Vector3D(container.insideLenght, container.insideWidth, container.insideHeight),
                    OpeningWidth = container.openingWidth,
                    OpeningHeight = container.openingHeight,
                    RoofOpeningLength = container.roofOpeningLenght,
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

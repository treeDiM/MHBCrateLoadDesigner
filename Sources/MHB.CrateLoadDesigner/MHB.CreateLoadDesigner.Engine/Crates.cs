﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 
namespace MHB.CrateLoadDesigner.Engine.XML {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://MHBNamespace")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://MHBNamespace", IsNullable=false)]
    public partial class Root {
        
        private RootCrateFrame[] listCrateFrameField;
        
        private RootCrateGlass[] listCrateGlassField;
        
        private RootContainer[] listContainerField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("CrateFrame", IsNullable=false)]
        public RootCrateFrame[] ListCrateFrame {
            get {
                return this.listCrateFrameField;
            }
            set {
                this.listCrateFrameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("CrateGlass", IsNullable=false)]
        public RootCrateGlass[] ListCrateGlass {
            get {
                return this.listCrateGlassField;
            }
            set {
                this.listCrateGlassField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Container", IsNullable=false)]
        public RootContainer[] ListContainer {
            get {
                return this.listContainerField;
            }
            set {
                this.listContainerField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://MHBNamespace")]
    public partial class RootCrateFrame {
        
        private string crateNameField;
        
        private string crateDescriptionField;
        
        private enuCrateType crateTypeField;
        
        private double maxLongSideField;
        
        private double maxShortSideField;
        
        private double crateLengthField;
        
        private double crateWidthField;
        
        private double crateHeightField;
        
        private int maxQuantityCP80Field;
        
        private int maxQuantityCP100Field;
        
        private double dynMaxLengthField;
        
        private bool dynMaxLengthFieldSpecified;
        
        private double dynAdditionalLengthField;
        
        private bool dynAdditionalLengthFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string crateName {
            get {
                return this.crateNameField;
            }
            set {
                this.crateNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string crateDescription {
            get {
                return this.crateDescriptionField;
            }
            set {
                this.crateDescriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public enuCrateType crateType {
            get {
                return this.crateTypeField;
            }
            set {
                this.crateTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double maxLongSide {
            get {
                return this.maxLongSideField;
            }
            set {
                this.maxLongSideField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double maxShortSide {
            get {
                return this.maxShortSideField;
            }
            set {
                this.maxShortSideField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double crateLength {
            get {
                return this.crateLengthField;
            }
            set {
                this.crateLengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double crateWidth {
            get {
                return this.crateWidthField;
            }
            set {
                this.crateWidthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double crateHeight {
            get {
                return this.crateHeightField;
            }
            set {
                this.crateHeightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int maxQuantityCP80 {
            get {
                return this.maxQuantityCP80Field;
            }
            set {
                this.maxQuantityCP80Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int maxQuantityCP100 {
            get {
                return this.maxQuantityCP100Field;
            }
            set {
                this.maxQuantityCP100Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double dynMaxLength {
            get {
                return this.dynMaxLengthField;
            }
            set {
                this.dynMaxLengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dynMaxLengthSpecified {
            get {
                return this.dynMaxLengthFieldSpecified;
            }
            set {
                this.dynMaxLengthFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double dynAdditionalLength {
            get {
                return this.dynAdditionalLengthField;
            }
            set {
                this.dynAdditionalLengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dynAdditionalLengthSpecified {
            get {
                return this.dynAdditionalLengthFieldSpecified;
            }
            set {
                this.dynAdditionalLengthFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://MHBNamespace")]
    public enum enuCrateType {
        
        /// <remarks/>
        CRATE,
        
        /// <remarks/>
        SKID,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://MHBNamespace")]
    public partial class RootCrateGlass {
        
        private string crateNameField;
        
        private string crateDescriptionField;
        
        private double maxLongSideField;
        
        private double maxShortSideField;
        
        private double crateLengthField;
        
        private double crateWidthField;
        
        private double crateHeightField;
        
        private int maxQuantityDoubleGlassField;
        
        private int maxQuantityTripleGlassField;
        
        private double dynMaxLengthField;
        
        private bool dynMaxLengthFieldSpecified;
        
        private double dynAdditionalLengthField;
        
        private bool dynAdditionalLengthFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string crateName {
            get {
                return this.crateNameField;
            }
            set {
                this.crateNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string crateDescription {
            get {
                return this.crateDescriptionField;
            }
            set {
                this.crateDescriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double maxLongSide {
            get {
                return this.maxLongSideField;
            }
            set {
                this.maxLongSideField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double maxShortSide {
            get {
                return this.maxShortSideField;
            }
            set {
                this.maxShortSideField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double crateLength {
            get {
                return this.crateLengthField;
            }
            set {
                this.crateLengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double crateWidth {
            get {
                return this.crateWidthField;
            }
            set {
                this.crateWidthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double crateHeight {
            get {
                return this.crateHeightField;
            }
            set {
                this.crateHeightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int maxQuantityDoubleGlass {
            get {
                return this.maxQuantityDoubleGlassField;
            }
            set {
                this.maxQuantityDoubleGlassField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int maxQuantityTripleGlass {
            get {
                return this.maxQuantityTripleGlassField;
            }
            set {
                this.maxQuantityTripleGlassField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double dynMaxLength {
            get {
                return this.dynMaxLengthField;
            }
            set {
                this.dynMaxLengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dynMaxLengthSpecified {
            get {
                return this.dynMaxLengthFieldSpecified;
            }
            set {
                this.dynMaxLengthFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double dynAdditionalLength {
            get {
                return this.dynAdditionalLengthField;
            }
            set {
                this.dynAdditionalLengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dynAdditionalLengthSpecified {
            get {
                return this.dynAdditionalLengthFieldSpecified;
            }
            set {
                this.dynAdditionalLengthFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://MHBNamespace")]
    public partial class RootContainer {
        
        private string containerNameField;
        
        private string containerDescriptionField;
        
        private double insideLenghtField;
        
        private double insideWidthField;
        
        private double insideHeightField;
        
        private double openingWidthField;
        
        private double openingHeightField;
        
        private double roofOpeningLenghtField;
        
        private double roofOpeningWidthField;
        
        private double payloadField;
        
        private double emptyWeightField;
        
        private string remarkField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string containerName {
            get {
                return this.containerNameField;
            }
            set {
                this.containerNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string containerDescription {
            get {
                return this.containerDescriptionField;
            }
            set {
                this.containerDescriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double insideLenght {
            get {
                return this.insideLenghtField;
            }
            set {
                this.insideLenghtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double insideWidth {
            get {
                return this.insideWidthField;
            }
            set {
                this.insideWidthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double insideHeight {
            get {
                return this.insideHeightField;
            }
            set {
                this.insideHeightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double openingWidth {
            get {
                return this.openingWidthField;
            }
            set {
                this.openingWidthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double openingHeight {
            get {
                return this.openingHeightField;
            }
            set {
                this.openingHeightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double roofOpeningLenght {
            get {
                return this.roofOpeningLenghtField;
            }
            set {
                this.roofOpeningLenghtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double roofOpeningWidth {
            get {
                return this.roofOpeningWidthField;
            }
            set {
                this.roofOpeningWidthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double payload {
            get {
                return this.payloadField;
            }
            set {
                this.payloadField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double emptyWeight {
            get {
                return this.emptyWeightField;
            }
            set {
                this.emptyWeightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string remark {
            get {
                return this.remarkField;
            }
            set {
                this.remarkField = value;
            }
        }
    }
}

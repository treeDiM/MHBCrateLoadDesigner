#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;

using MHB.CrateLoadDesigner.Engine;

using MHB.CrateLoadDesigner.Desktop.Properties;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class FormAddNewGlass : Form
    {
        #region Constructor
        public FormAddNewGlass()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateStatus(this, e);
        }
        #endregion

        #region Public properties
        public Project CurrentProject { get; set; }
        public string Brand { get => tbBrand.Text; set => tbBrand.Text = value; }
        public int Number => (int)nudNumber.Value;
        public double DimWidth => uCtrlDimensions.ValueX;
        public double DimHeight => uCtrlDimensions.ValueY;
        #endregion

        #region Status
        private void UpdateStatus(object sender, EventArgs e)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(Brand))
                message = Resources.IDS_INVALIDBRAND;
            else if (CurrentProject.ListDefFrames.Exists(f => string.Equals(f.Brand, Brand)))
                message = Resources.IDS_BRANDALREADYEXISTS;
            else if (DimWidth == 0 || DimHeight == 0)
                message = Resources.IDS_DIMENSIONSHOULDEXCEEDZERO;
            else if (!CurrentProject.CanFitGlass(DimWidth, DimHeight))
                message = Resources.IDS_DIMENSIONSEXCEEDSMAXVALUE;

            bnOk.Enabled = string.IsNullOrEmpty(message);
            statusLabel.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            statusLabel.Text = string.IsNullOrEmpty(message) ? Resources.IDS_READY : message;
        }
        #endregion

    }
}

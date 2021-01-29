#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;

using WeifenLuo.WinFormsUI.Docking;
using log4net;

using treeDiM.StackBuilder.Graphics;

using MHB.CrateLoadDesigner.Engine;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class DockContentCratesFrame : DockContent
    {
        #region Constructor
        public DockContentCratesFrame()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // initialize
            try
            {
                Project?.GenerateSolution();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FillLBoxCrates();
        }
        #endregion

        #region List box
        private void FillLBoxCrates()
        {
            // loop on crates
            foreach (var crate in Project.ListCrateFrame)
            {
                lbCrates.Items.Add(crate);
            }
            // select first item
            if (lbCrates.Items.Count > 0)
                lbCrates.SelectedIndex = 0;
        }
        #endregion

        #region Drawing
        private void DrawCrate()
        {
            // sanity check
            if (null == SelectedCrate) return;
            // generate image
            try
            {

                pbCrate.Image = LayeredCrateToImage.Draw(
                    GraphicHelpers.CrateToBoxes(SelectedCrate),
                    SelectedCrate.OuterDimensions, Color.White,
                    false, true,
                    pbCrate.Size
                    );
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Private properties
        private InstCrateFrame SelectedCrate => lbCrates.SelectedItem as InstCrateFrame;
        #endregion

        #region Event handlers
        private void OnSelectedCrateChanged(object sender, EventArgs e)
        {
            DrawCrate();
        }
        private void OnPbCrateResized(object sender, EventArgs e)
        {
            DrawCrate();
        }
        #endregion

        #region Data members
        public Project Project { get; set; }
        protected ILog _log = LogManager.GetLogger(typeof(DockContentCratesFrame));
        #endregion
    }
}

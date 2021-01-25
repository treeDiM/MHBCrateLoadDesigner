#region Using directives
using System;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using log4net;

using treeDiM.StackBuilder.Graphics;

using MHB.CrateLoadDesigner.Engine;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class DockContentCrates : DockContent
    {
        #region Constructor
        public DockContentCrates()
        {
            InitializeComponent();
        }
        #endregion
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

        private void FillLBoxCrates()
        {
            //
            foreach (var crate in Project.ListCrateFrame)
            {
                lbCrates.Items.Add(crate);
            }
            // select first item
            if (lbCrates.Items.Count > 0)
                lbCrates.SelectedIndex = 0;
        }

        private void DrawCrate()
        {
            // sanity check
            if (null == SelectedCrate) return;
            try
            {
                _log.Info($"({pbCrate.Size.Width}, {pbCrate.Size.Height})");
                pbCrate.Image = LayeredCrateToImage.Draw(
                    GraphicHelpers.CrateToBoxes(SelectedCrate),
                    SelectedCrate.OuterDimensions,
                    false,
                    pbCrate.Size
                    );
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        #region Private properties
        private InstCrateFrame SelectedCrate
        {
            get
            {
                if (lbCrates.SelectedIndex == -1) return null;
                return lbCrates.SelectedItem as InstCrateFrame;
            }
        }
        #endregion

        #region Data members
        public Project Project { get; set; }
        protected ILog _log = LogManager.GetLogger(typeof(DockContentCrates));
        #endregion

        #region Event handlers
        private void OnSelectedCrateChanged(object sender, EventArgs e)
        {
            DrawCrate();
        }
        #endregion

        private void OnPbCrateResized(object sender, EventArgs e)
        {
            DrawCrate();
        }
    }
}

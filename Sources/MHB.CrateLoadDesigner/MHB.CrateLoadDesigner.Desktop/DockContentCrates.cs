#region Using directives
using System;
using WeifenLuo.WinFormsUI.Docking;

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
            Project?.GenerateSolution();

            FillListBox();
        }
        private void FillListBox()
        {
            foreach (var crate in Project.ListCrateFrame)
            {
                lbCrates.Items.Add($"Crate {crate.ID} (Frames = {crate.NoFrames})");
            }
        }
        #region Data members
        public Project Project { get; set; }
        #endregion
    }
}

#region Using directives
using WeifenLuo.WinFormsUI.Docking;

using MHB.CrateLoadDesigner.Engine;
using System;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class DockContentCrates : DockContent
    {
        public DockContentCrates()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Project?.GenerateSolution();
        }
        public Project Project { get; set; }
    }
}

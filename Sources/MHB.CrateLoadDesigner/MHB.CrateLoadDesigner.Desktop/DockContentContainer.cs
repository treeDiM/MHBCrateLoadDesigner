#region Using directives
using System;

using WeifenLuo.WinFormsUI.Docking;
using log4net;

using MHB.CrateLoadDesigner.Engine;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class DockContentContainer : DockContent
    {
        #region Constructor
        public DockContentContainer()
        {
            InitializeComponent();
        }
        #endregion

        #region Form overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                FillContainerList();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Fill container list
        private void FillContainerList()
        { 
        }
        #endregion

        #region Data members
        public Project Project { get; set; }
        protected static ILog _log = LogManager.GetLogger(typeof(DockContentContainer)); 
        #endregion
    }
}

#region Using directives
using System;
using System.Drawing;

using WeifenLuo.WinFormsUI.Docking;
using log4net;

using treeDiM.StackBuilder.Graphics;

using MHB.CrateLoadDesigner.Engine;
using System.ComponentModel;
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
                FillLBoxContainers();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Main?.RemoveForm(this);
        }
        #endregion

        #region Fill container list
        private void FillLBoxContainers()
        {
            // loop on containers
            foreach (var container in Project.ListContainers)
            {
                lbContainers.Items.Add(container);
            }
            // select first item
            if (lbContainers.Items.Count > 0)
                lbContainers.SelectedIndex = 0;
        }
        #endregion

        #region DrawContainer
        private void DrawContainer()
        {
            // sanity check
            if (null == SelectedContainer) return;
            // generate image
            try
            {
                pbContainer.Image = LayeredCrateToImage.Draw(
                    GraphicHelpers.ContainerToBoxes(SelectedContainer),
                    SelectedContainer.Dimensions, Color.White,
                    false, true, pbContainer.Size
                    );
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Event handlers
        private void OnSelectedContainerChanged(object sender, EventArgs e)
        {
            DrawContainer();
            FillGridContainer();
            InstContainer container = SelectedContainer;
            if (null != container)
            {
                lbContainerName.Text = $"{container.ID}";
                lbContainerType.Text = $"{container.ParentDef.Name}";
                lbDimensions.Text = $"{container.InnerDimensions.X}x{container.InnerDimensions.Y}x{container.InnerDimensions.Z}";                
            }
        }
        private void OnPbContainerResized(object sender, EventArgs e)
        {
            DrawContainer();
        }

        private void FillGridContainer()
        { 
        }
        #endregion

        #region Private properties
        private InstContainer SelectedContainer => lbContainers.SelectedItem as InstContainer;
        #endregion

        #region Data members
        public Project Project { get; set; }
        public FormMain Main { get; set; }
        protected static ILog _log = LogManager.GetLogger(typeof(DockContentContainer));
        #endregion


    }
}

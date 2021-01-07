#region Using directives
using System;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using log4net;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class DockContentLogConsole : DockContent
    {
        #region Constructor
        public DockContentLogConsole()
        {
            InitializeComponent();
        }
        #endregion
        #region Set rich text box to RichTextBoxAppender
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            log4net.Appender.RichTextBoxAppender.SetRichTextBox(richTextBoxLog, "RichTextBoxAppender");
        }
        #endregion
        #region Public properties
        public RichTextBox RichTextBox => richTextBoxLog;
        #endregion
        #region DockContent menu items event handlers
        private void OnMenuItemDockable(object sender, EventArgs e)
        {
            try
            {
                ShowHint = DockState.DockBottom;
                if (DockableToolStripMenuItem.Checked)
                    DockState = ShowHint;
                else
                    DockState = DockState.Float;
            }
            catch (InvalidOperationException ex)
            {
                Log.Error(ex.Message);
            }
        }
        private void OnMenuItemAutoHide(object sender, EventArgs e)
        {
            try
            {
                if (AutoHideToolStripMenuItem.Checked)
                {
                    switch (DockState)
                    {
                        case DockState.DockBottom: DockState = DockState.DockBottomAutoHide; break;
                        case DockState.DockTop: DockState = DockState.DockTopAutoHide; break;
                        case DockState.DockLeft: DockState = DockState.DockLeftAutoHide; break;
                        case DockState.DockRight: DockState = DockState.DockRightAutoHide; break;
                        case DockState.Unknown: break;
                        case DockState.Float: break;
                        case DockState.DockTopAutoHide: break;
                        case DockState.DockLeftAutoHide: break;
                        case DockState.DockBottomAutoHide: break;
                        case DockState.DockRightAutoHide: break;
                        case DockState.Document: break;
                        case DockState.Hidden: break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                }
                else
                {
                    switch (DockState)
                    {
                        case DockState.DockBottomAutoHide: DockState = DockState.DockBottom; break;
                        case DockState.DockTopAutoHide: DockState = DockState.DockTop; break;
                        case DockState.DockLeftAutoHide: DockState = DockState.DockLeft; break;
                        case DockState.DockRightAutoHide: DockState = DockState.DockRight; break;
                        case DockState.Unknown: break;
                        case DockState.Float: break;
                        case DockState.Document: break;
                        case DockState.DockTop: break;
                        case DockState.DockLeft: break;
                        case DockState.DockBottom: break;
                        case DockState.DockRight: break;
                        case DockState.Hidden: break;
                        default: throw new ArgumentOutOfRangeException();
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Log.Error(ex.Message);
            }
        }
        private void OnMenuItemHide(object sender, EventArgs e)
        {
            Hide();
        }
        #endregion
        #region Data members
        protected static ILog Log = LogManager.GetLogger(typeof(DockContentLogConsole));
        #endregion
    }
}

#region Using directives
using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using WeifenLuo.WinFormsUI.Docking;
using log4net;

using MHB.CrateLoadDesigner.Desktop.Properties;
using MHB.CrateLoadDesigner.Engine;
using MHB.CrateLoadDesigner.Exporters;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            // load content
            _deserializeDockContent = new DeserializeDockContent(ReloadContent);

            DoSplash();

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            // Set DockPanel properties
            var theme = new VS2015BlueTheme();
            dockPanel.Theme = theme;

            dockPanel.ActiveAutoHideContent = null;
            dockPanel.Parent = this;

            dockPanel.SuspendLayout(true);
            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, _deserializeDockContent);
            dockPanel.ResumeLayout(true, true);


            ShowLogConsole();
        }
        private void DoSplash()
        {
            using (FormSplashScreen sp = new FormSplashScreen(this))
            {
                sp.TimerInterval = 1000;
                sp.ShowDialog();
            }
        }
        private void ShowLogConsole()
        {
            // show or hide log console ?
            if (AssemblyConf == "debug" || Settings.Default.ShowLogConsole)
            {
                if (null == FindDocument("Log console"))
                {
                    _logConsole = new DockContentLogConsole()
                    {
                        TabText = "Log console",
                        Text = "Log console"
                    };
                    _logConsole.Show(dockPanel, DockState.DockBottom);
                }
                else
                    _logConsole.IsHidden = false;
            }
        }

        private IDockContent ReloadContent(string persistString)
        {
            switch (persistString)
            {
                case "frmDocument":
                    return null;
                case "frmLogConsole":
                    _logConsole = new DockContentLogConsole();
                    return _logConsole;
                default:
                    return null;
            }
        }
        #region Helpers
        public string AssemblyConf
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyConfigurationAttribute confAttribute = (AssemblyConfigurationAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (!string.IsNullOrEmpty(confAttribute.Configuration))
                        return confAttribute.Configuration.ToLower();
                }
                return "release";
            }
        }
        private IDockContent FindDocument(string text)
        {
            foreach (IDockContent content in dockPanel.Contents)
            {
                if (content.DockHandler.TabText == text)
                    return content;
            }
            return null;
        }
        #endregion

        #region Event handlers
        private void OnAbout(object sender, EventArgs e)
        {
            var form = new FormAboutBox();
            form.ShowDialog();
        }
        private void OnExit(object sender, EventArgs e)
        {
            Close();
        }
        private void OnFileNew(object sender, EventArgs e)
        {
            var form = new FormNewProject();
            if (DialogResult.OK == form.ShowDialog())
            {
                project = form.Proj;
                project?.GenerateSolution();
                OnShowCrates(sender, e);
            }
            Text = $"MHB Crate load designer - {project?.Name}";
        }

        private void OnShowCrates(object sender, EventArgs e)
        {
            var formCratesFrame = new DockContentCratesFrame() { Project = project };
            formCratesFrame.Show(dockPanel, DockState.Document);
            var formCratesGlass = new DockContentCratesGlass() { Project = project };
            formCratesGlass.Show(dockPanel, DockState.Document);
        }
        private void OnFileOpen(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                project.Load(openFileDialog.FileName);
            }
            UpdateCaption();
        }
        private void OnFileSave(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFileDialog.ShowDialog())
            {
                project.Save(saveFileDialog.FileName);
            }
        }
        private void OnGenerateTableOfContents(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.OK == outputFileDialog.ShowDialog())
                {
                    using (ExporterTableOfContents exporter = new ExporterTableOfContents())
                    {
                        exporter.Export(project, outputFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Caption
        private void UpdateCaption()
        { 
            Text = project == null? "MHB crate load designer" : $"MHB crate load designer - {project?.Name}";
        }
        #endregion

        #region Menu helpers
        private void UpdateMenu()
        { 
        
        }
        #endregion

        #region Private members
        private DockContentLogConsole _logConsole;
        private DeserializeDockContent _deserializeDockContent;
        private Project project = new Project();
        private ILog _log = LogManager.GetLogger(typeof(FormMain));

        #endregion


    }
}

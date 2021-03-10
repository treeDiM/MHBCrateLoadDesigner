#region Using directives
using System;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

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

            UpdateCaption();
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
                CloseAllForms(sender, e);

                project = form.Proj;
                project?.GenerateSolution();
                OnShowForms(sender, e);
            }
            UpdateCaption();
        }

        private void OnShowForms(object sender, EventArgs e)
        {
            var formInputs = new DockContentInputs() { Project = project, Main = this };
            formInputs.Show(dockPanel, DockState.Document);
            Forms.Add(formInputs);
            if (project.ListCrateFrame.Count > 0)
            {
                var formCratesFrame = new DockContentCratesFrame() { Project = project, Main = this };
                formCratesFrame.Show(dockPanel, DockState.Document);
                Forms.Add(formCratesFrame);
            }
            if (project.ListCrateGlass.Count > 0)
            {
                var formCratesGlass = new DockContentCratesGlass() { Project = project, Main = this };
                formCratesGlass.Show(dockPanel, DockState.Document);
                Forms.Add(formCratesGlass);
            }
            if (project.ListContainers.Count > 0)
            {
                var formContainer = new DockContentContainer() { Project = project, Main = this };
                formContainer.Show(dockPanel, DockState.Document);
                Forms.Add(formContainer);
            }
        }
        private void CloseAllForms(object sender, EventArgs e)
        {
            while (Forms.Count > 0)
                Forms[0].Close();
            project = null;
        }
        
        public void RemoveForm(DockContent child)
        {
            Forms.Remove(child);
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
        private void ShowFormInputs(object sender, EventArgs e) => OpenForm(typeof(DockContentInputs));
        private void ShowFormFrameCrates(object sender, EventArgs e) => OpenForm(typeof(DockContentCratesFrame));
        private void ShowFormGlassCrates(object sender, EventArgs e) => OpenForm(typeof(DockContentCratesGlass));
        private void ShowFormContainers(object sender, EventArgs e) => OpenForm(typeof(DockContentContainer));

        private void OpenForm(Type t)
        {
            bool activated = false;
            foreach (var dockContent in Forms)
            {
                if (dockContent.GetType() == t)
                {
                    dockContent.Activate();
                    activated = true;
                    break;
                }
            }
            if (!activated)
            {
                DockContent form = null;
                if (t == typeof(DockContentInputs))
                    form = new DockContentInputs() { Project = project, Main = this };
                else if (t == typeof(DockContentCratesFrame))
                    form = new DockContentCratesFrame() { Project = project, Main = this };
                else if (t == typeof(DockContentCratesGlass))
                    form = new DockContentCratesGlass() { Project = project, Main = this };
                else if (t == typeof(DockContentContainer))
                    form = new DockContentContainer() { Project = project, Main = this };
                else
                    throw new Exception("Unexpected form type!");
                form.Show(dockPanel, DockState.Document);
                Forms.Add(form);
            }
        }
        #endregion

        #region Caption
        private void UpdateCaption()
        {
            toolStripMIInputs.Enabled = project != null;
            toolStripMIFrameCrates.Enabled = project != null;
            toolStripMIGlassCrates.Enabled = project != null;
            toolStripMIContainers.Enabled = project != null;
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
        private Project project;
        private List<DockContent> Forms = new List<DockContent>();
        private ILog _log = LogManager.GetLogger(typeof(FormMain));

        #endregion
    }
}

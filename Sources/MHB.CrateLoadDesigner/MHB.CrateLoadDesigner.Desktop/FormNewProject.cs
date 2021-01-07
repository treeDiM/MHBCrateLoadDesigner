#region Using directives
using System;
using System.Windows.Forms;
using System.IO;

using log4net;

using MHB.CrateLoadDesigner.Desktop.Properties;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class FormNewProject : Form
    {
        public FormNewProject()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void OnExploreInputFolder(object sender, EventArgs e)
        {
            try
            {
                inputFileDialog.InitialDirectory = Settings.Default.InputFolder;
                if (DialogResult.OK == inputFileDialog.ShowDialog())
                {
                    InputFilePath = inputFileDialog.FileName;

                    Settings.Default.InputFolder = Path.GetDirectoryName(InputFilePath);
                    Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        private void OnInputChanged(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(InputFilePath))
                    LoadInputFile(InputFilePath);
                else
                    SetStatusLabel(Resources.IDS_VALIDFILEPATHNEEDED);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        private void LoadInputFile(string filePath)
        {            
        }

        private string InputFilePath
        {
            get => tbInputFilePath.Text;
            set => tbInputFilePath.Text = value;
        }
        private void SetStatusLabel(string message)
        {
            statusLabel.Text = message;
        }

        protected ILog _log = LogManager.GetLogger(typeof(FormNewProject));
    }
}

#region Using directives
using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

using log4net;
using SourceGrid;

using MHB.CrateLoadDesigner.Engine;
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

             

            OnInputFilePathChanged(this, e);
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
                _log.Error(ex.ToString());
            }
        }

        private void OnInputFilePathChanged(object sender, EventArgs e)
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
                _log.Error(ex.ToString());
            }
        }
        private void OnProjectNameChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ProjectName.Trim()))
                    SetStatusLabel(Resources.IDS_VALIDPROJECTNAME);

            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        private void LoadInputFile(string filePath)
        {
            if (null == (Proj = Project.LoadNewProject(filePath)))
                return;
            ProjectName = Proj.Name;
            FillGridFrames();
            FillGridGlass();
        }

        private void FillGridFrames()
        {
            string[] captions = {
                Resources.IDS_BRAND,
                Resources.IDS_NUMBER,
                Resources.IDS_WIDTH,
                Resources.IDS_HEIGHT,
                Resources.IDS_DESCRIPTION
            };
            GridInitialize(gridFrames, captions);
            int iIndex = 0;
            foreach (var defFrame in Proj.ListDefFrames)
            {
                gridFrames.Rows.Insert(++iIndex);
                int iCol = 0;
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell(defFrame.Brand);
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell(defFrame.Number);
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{defFrame.Width:0.##}");
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{defFrame.Height:0.##}");
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell(defFrame.Description);
            }
            GridFinalize(gridFrames);
        }
        private void FillGridGlass()
        {
            string[] captions = {
                Resources.IDS_BRAND,
                Resources.IDS_NUMBER,
                Resources.IDS_WIDTH,
                Resources.IDS_HEIGHT
            };
            GridInitialize(gridGlass, captions);
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            int iIndex = 0;
            foreach (var defGlass in Proj.ListDefGlass)
            {
                gridGlass.Rows.Insert(++iIndex);
                int iCol = 0;
                gridGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell(defGlass.Brand) { View = viewNormal };
                gridGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell(defGlass.Number) { View = viewNormal };
                gridGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{defGlass.Width:0.#}") { View = viewNormal };
                gridGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{defGlass.Height:0.#}") { View = viewNormal };
            }
            GridFinalize(gridGlass);
        }
        private void FillGridCrateFrames()
        {
            string[] captions = { 
                Resources.IDS_BRAND,
            };
        }
        private void FillGridCrateGlass()
        { 
        }
        private void FillGridContainers()
        { 
        }
        private void GridInitialize(Grid grid, string[] captions)
        {
            // remove all existing rows
            grid.Rows.Clear();
            // *** IViews 
            // captionHeader
            SourceGrid.Cells.Views.RowHeader captionHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader veHeaderCaption = new DevAge.Drawing.VisualElements.RowHeader()
            {
                BackColor = Color.SteelBlue,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            captionHeader.Background = veHeaderCaption;
            captionHeader.ForeColor = Color.Black;
            captionHeader.Font = new Font("Arial", 10, FontStyle.Bold);
            captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            // viewColumnHeader
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader()
            {
                BackColor = Color.LightGray,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.Black;
            viewColumnHeader.Font = new Font("Arial", 10, FontStyle.Regular);
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
            // viewNormal
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            // ***
            // set first row
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = captions.Length;
            grid.FixedRows = 1;
            grid.Rows.Insert(0);
            // header
            int iCol = 0;
            SourceGrid.Cells.ColumnHeader columnHeader;
            // listed captions
            foreach (string s in captions)
            {
                columnHeader = new SourceGrid.Cells.ColumnHeader(s)
                {
                    AutomaticSortEnabled = false,
                    View = viewColumnHeader
                };
                grid[0, iCol++] = columnHeader;
            }
        }
        private void GridFinalize(Grid grid)
        {
            grid.AutoStretchColumnsToFitWidth = true;
            grid.AutoSizeCells();
            grid.Columns.StretchToFit();
        }

        private string InputFilePath
        {
            get => tbInputFilePath.Text;
            set => tbInputFilePath.Text = value;
        }
        private string ProjectName
        {
            get => tbProjectName.Text;
            set => tbProjectName.Text = value;
        }
        private void SetStatusLabel(string message)
        {
            statusLabel.Text = message;
        }

        public Project Proj { get; set; }
        protected ILog _log = LogManager.GetLogger(typeof(FormNewProject));
    }
}

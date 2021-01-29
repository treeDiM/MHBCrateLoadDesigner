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
                {
                    LoadInputFile(InputFilePath);
                    ProjectName = Path.GetFileNameWithoutExtension(InputFilePath);
                }
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
                else if (string.IsNullOrEmpty(ProjectNumber.Trim()))
                    SetStatusLabel(Resources.IDS_VALIDPROJECTNUMBER);
                else
                    SetStatusLabel();

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
            FillGridCrateFrames();
            FillGridCrateGlass();
        }

        #region Grids
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
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            int iIndex = 0;
            foreach (var defFrame in Proj.ListDefFrames)
            {
                gridFrames.Rows.Insert(++iIndex);
                int iCol = 0;
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell(defFrame.Brand) { View = viewNormal };
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell(defFrame.Number) { View = viewNormal };
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{defFrame.Width:0.##}") { View = viewNormal };
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{defFrame.Height:0.##}") { View = viewNormal };
                gridFrames[iIndex, iCol++] = new SourceGrid.Cells.Cell(defFrame.Description) { View = viewNormal };
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
                Resources.IDS_DESCRIPTION,
                Resources.IDS_MAXLONGSIDE,
                Resources.IDS_MAXSHORTSIDE,
                Resources.IDS_DIMENSIONSOUTER,
                Resources.IDS_MAXDYNLENGTH,
                Resources.IDS_ADDITIONALLENGTH
            };
            GridInitialize(gridCratesFrame, captions);
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            int iIndex = 0;
            foreach (var crate in Proj.ListDefCratesFrame)
            {
                gridCratesFrame.Rows.Insert(++iIndex);
                int iCol = 0;
                gridCratesFrame[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.Name) { View = viewNormal };
                gridCratesFrame[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.Description) { View = viewNormal };
                gridCratesFrame[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.MaxLongSide) { View = viewNormal };
                gridCratesFrame[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.MaxShortSide) { View = viewNormal };
                gridCratesFrame[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{crate.DimensionsOuter.X}x{crate.DimensionsOuter.Y}x{crate.DimensionsOuter.Z}") { View = viewNormal };
                gridCratesFrame[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.DynMaxLength.HasValue ? $"{crate.DynMaxLength}" : "") { View = viewNormal };
                gridCratesFrame[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.DynAdditionalLength.HasValue ? $"{crate.DynAdditionalLength}" : "") { View = viewNormal };
            }
            GridFinalize(gridCratesFrame);
        }
        private void FillGridCrateGlass()
        {
            string[] captions = {
                Resources.IDS_NAME,
                Resources.IDS_DESCRIPTION,
                Resources.IDS_MAXLONGSIDE,
                Resources.IDS_MAXSHORTSIDE,
                Resources.IDS_DIMENSIONSOUTER,
                Resources.IDS_MAXDYNLENGTH,
                Resources.IDS_ADDITIONALLENGTH
            };
            GridInitialize(gridCratesGlass, captions);
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            int iIndex = 0;
            foreach (var crate in Proj.ListDefCratesGlass)
            {
                gridCratesGlass.Rows.Insert(++iIndex);
                int iCol = 0;
                gridCratesGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.Name) { View = viewNormal };
                gridCratesGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.Description) { View = viewNormal };
                gridCratesGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.MaxLongSide) { View = viewNormal };
                gridCratesGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.MaxShortSide) { View = viewNormal };
                gridCratesGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{crate.DimensionsOuter.X}x{crate.DimensionsOuter.Y}x{crate.DimensionsOuter.Z}") { View = viewNormal };
                gridCratesGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.DynMaxLength.HasValue ? $"{crate.DynMaxLength}" : "") { View = viewNormal };
                gridCratesGlass[iIndex, iCol++] = new SourceGrid.Cells.Cell(crate.DynAdditionalLength.HasValue ? $"{crate.DynAdditionalLength}" : "") { View = viewNormal };
            }
            GridFinalize(gridCratesGlass);
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
        #endregion

        #region Private properties
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
        private string ProjectNumber
        {
            get => tbProjectNumber.Text;
            set => tbProjectNumber.Text = value;
        }
        #endregion

        private void SetStatusLabel(string message = "")
        {
            if (string.IsNullOrEmpty(message))
            {
                bnOK.Enabled = true;
                message = $"Ready";
            }
            else
                bnOK.Enabled = false;


            statusLabel.Text = message;
        }

        public Project Proj { get; set; }
        protected ILog _log = LogManager.GetLogger(typeof(FormNewProject));
    }
}

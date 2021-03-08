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
        #region Constructor
        public FormNewProject()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbGlassType.SelectedIndex = 0;

            Proj = Project.Instantiate();

            FillGridCrateFrames();
            FillGridCrateGlass();
            FillGridContainers();

            OnInputFilePathChanged(this, e);
        }
        #endregion
        #region Event handlers
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
                    ProjectName = Proj.Name;

                    Proj.IsValid(out string reasonInvalid);
                    SetStatusLabel(reasonInvalid);
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
        #endregion
        #region Load input file
        private void LoadInputFile(string filePath)
        {
            if (!Proj.LoadInputFileExcel(filePath))
                return;
            ProjectName = Proj.Name;
            FillGridFrames();
            FillGridGlass();
        }
        #endregion
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
            string[] captions =
            {
                Resources.IDS_NAME,
                Resources.IDS_DESCRIPTION,
                Resources.IDS_DIMENSIONSINNER,
                Resources.IDS_OPENING,
                Resources.IDS_ROOFOPENING,
                Resources.IDS_PAYLOAD,
                Resources.IDS_REMARK
            };
            GridInitialize(gridContainers, captions);
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            int iIndex = 0;
            foreach (var container in Proj.ListDefContainers)
            {
                gridContainers.Rows.Insert(++iIndex);
                int iCol = 0;
                gridContainers[iIndex, iCol++] = new SourceGrid.Cells.Cell(container.Name) { View = viewNormal };
                gridContainers[iIndex, iCol++] = new SourceGrid.Cells.Cell(container.Description) { View = viewNormal };
                gridContainers[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{container.DimensionsInner.X}x{container.DimensionsInner.Y}x{container.DimensionsInner.Z}") { View = viewNormal };
                gridContainers[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{container.OpeningWidth}x{container.OpeningHeight}") { View = viewNormal };
                gridContainers[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{container.RoofOpeningLength}x{container.RoofOpeningWidth}") { View = viewNormal };
                gridContainers[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{container.Payload}") { View = viewNormal };
                gridContainers[iIndex, iCol++] = new SourceGrid.Cells.Cell(container.Remark) { View = viewNormal };
            }
            GridFinalize(gridContainers);
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
        private void OnAddFrame(object sender, EventArgs e)
        {

        }

        private void OnAddGlass(object sender, EventArgs e)
        {
            var form = new FormAddNewGlass() { CurrentProject = Proj };
            if (DialogResult.OK == form.ShowDialog())
            { 
            }
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
        private Project.GlassType GlassType => (Project.GlassType)cbGlassType.SelectedIndex;

        private void OnGlassTypeChanged(object sender, EventArgs e)
        {
            Project.PGlassType = GlassType;
        }
        #endregion
        #region Status label
        private void SetStatusLabel(string message = "")
        {
            if (string.IsNullOrEmpty(message))
            {
                statusLabel.ForeColor = Color.Black;
                bnOK.Enabled = true;
                message = $"Ready";
            }
            else
            {
                statusLabel.ForeColor = Color.Red;
                bnOK.Enabled = false;
            }
            statusLabel.Text = message;
        }
        #endregion
        #region Data members
        public Project Proj { get; set; }
        protected ILog _log = LogManager.GetLogger(typeof(FormNewProject));
        #endregion
    }
}

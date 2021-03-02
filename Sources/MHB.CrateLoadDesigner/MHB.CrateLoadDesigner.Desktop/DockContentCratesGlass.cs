#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;
using log4net;
using SourceGrid;

using treeDiM.StackBuilder.Graphics;

using MHB.CrateLoadDesigner.Engine;
using MHB.CrateLoadDesigner.Desktop.Properties;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class DockContentCratesGlass : DockContent
    {
        #region Constructor
        public DockContentCratesGlass()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FillLBoxCrates();
        }
        private void FillLBoxCrates()
        {
            // loop on crates
            foreach (var crate in Project.ListCrateGlass)
            {
                lbCrates.Items.Add(crate);
            }
            // select first item
            if (lbCrates.Items.Count > 0)
                lbCrates.SelectedIndex = 0;
        }
        #endregion
        #region Drawing
        private void DrawCrate()
        {
            // sanity check
            if (null == SelectedCrate) return;
            // generate image
            try
            {
                switch (SelectedCrate.Parent.CrateType)
                {
                    case DefCrateGlass.EType.VERTICAL:
                        pbCrate.Image = LayeredCrateToImage.Draw(
                            GraphicHelpers.CrateToBoxes(SelectedCrate),
                            SelectedCrate.OuterDimensions, Color.White,
                            false, true,
                            pbCrate.Size
                            );
                        break;
                    case DefCrateGlass.EType.AFRAME:
                        pbCrate.Image = NonLayeredCrateToImage.Draw(
                            GraphicHelpers.CrateToBoxesExplicitDir(SelectedCrate, 10.0),
                            SelectedCrate.OuterDimensions, Color.White,
                            false, true,
                            pbCrate.Size
                            );
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Private properties
        private InstCrateGlass SelectedCrate => lbCrates.SelectedItem as InstCrateGlass;
        #endregion

        #region Event handlers
        private void OnSelectedCrateChanged(object sender, EventArgs e)
        {
            DrawCrate();
            FillGridGlass();
            InstCrateGlass crate = SelectedCrate;
            if (null != crate)
            {
                lbCrateName.Text = $"#{crate.ID}";
                lbCrateDimsOuterValue.Text = $"{crate.OuterDimensions.X} x {crate.OuterDimensions.Y} x {crate.OuterDimensions.Z}";
                lbCrateDimsInnerValue.Text = $"{crate.MaxUnitDimensions.X} x {crate.MaxUnitDimensions.Y}";
            }
        }
        private void OnPbCrateResized(object sender, EventArgs e)
        {
            DrawCrate();
        }
        private void FillGridGlass()
        {
            string[] captions =
            {
                Resources.IDS_BRAND,
                Resources.IDS_DESCRIPTION,
                Resources.IDS_DIMENSIONS,
                Resources.IDS_NUMBER
            };
            GridInitialize(gridCrate, captions);
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            int iIndex = 0;
            foreach (var g in SelectedCrate.ContentDict)
            {
                gridCrate.Rows.Insert(++iIndex);
                int iCol = 0;
                gridCrate[iIndex, iCol++] = new SourceGrid.Cells.Cell(g.Key.Brand) { View = viewNormal };
                gridCrate[iIndex, iCol++] = new SourceGrid.Cells.Cell("") { View = viewNormal };
                gridCrate[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{g.Key.Width} x {g.Key.Height}") { View = viewNormal };
                gridCrate[iIndex, iCol++] = new SourceGrid.Cells.Cell($"{g.Value}") { View = viewNormal }; 
            }
            GridFinalize(gridCrate);
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

        #region Data members
        public Project Project { get; set; }
        protected ILog _log = LogManager.GetLogger(typeof(DockContentCratesGlass));
        #endregion


    }
}

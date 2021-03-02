#region Using directives
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text;

using WeifenLuo.WinFormsUI.Docking;
using log4net;
using SourceGrid;

using treeDiM.StackBuilder.Graphics;

using MHB.CrateLoadDesigner.Engine;
using MHB.CrateLoadDesigner.Desktop.Properties;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class DockContentCratesFrame : DockContent
    {
        #region Constructor
        public DockContentCratesFrame()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // initialize
            try
            {
                Project?.GenerateSolution();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FillLBoxCrates();
        }
        #endregion

        #region List box
        private void FillLBoxCrates()
        {
            // loop on crates
            foreach (var crate in Project.ListCrateFrame)
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
                if (SelectedCrate.IsSkid)
                    pbCrate.Image = NonLayeredCrateToImage.Draw(
                        GraphicHelpers.CrateToBoxesExplicitDir(SelectedCrate, 30),
                        SelectedCrate.OuterDimensions, Color.White,
                        false, true,
                        pbCrate.Size
                        );
                else
                    pbCrate.Image = LayeredCrateToImage.Draw(
                        GraphicHelpers.CrateToBoxes(SelectedCrate),
                        SelectedCrate.OuterDimensions, Color.White,
                        false, true,
                        pbCrate.Size
                        );
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion
        #region Grid layers
        private void FillGridLayers()
        {
            string[] captions =
            {
                Resources.IDS_NUMBER,
                Resources.IDS_IMAGE,
                Resources.IDS_CUMULATEDPERIMETER,
                Resources.IDS_COUNT,
                Resources.IDS_CONTENT
            };
            GridInitialize(gridLayers, captions);
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            int iIndex = 0;
            foreach (var layer in SelectedCrate.Layers)
            {
                if (layer.IsEmpty) continue;
                // index
                gridLayers.Rows.Insert(++iIndex);
                int iCol = 0;
                gridLayers[iIndex, iCol++] = new SourceGrid.Cells.Cell(iIndex) { View = viewNormal };
                // image
                uint pickId = 0;
                var boxes = GraphicHelpers.LayerToBoxes(layer, 0, ref pickId);
                Bitmap layerImage = BoxLayerToImage.Draw(boxes, layer.ParentCrate.MaxUnitDimensions, new Size(150, 100), BoxLayerToImage.EGraphMode.GRAPH_3D);
                gridLayers[iIndex, iCol++] = new SourceGrid.Cells.Image(layerImage) { View = viewNormal };
                // cumulated perimeter
                gridLayers[iIndex, iCol++] = new SourceGrid.Cells.Cell(layer.Weight) { View = viewNormal };
                // count
                gridLayers[iIndex, iCol++] = new SourceGrid.Cells.Cell(layer.Count) { View = viewNormal };
                // list of items
                var sb = new StringBuilder();
                foreach (var item in layer.ContentDict)
                    sb.AppendLine($"{item.Key.Brand} (* {item.Value})");
                gridLayers[iIndex, iCol++] =  new SourceGrid.Cells.Cell(sb.ToString()) { View = viewNormal };

            }
            GridFinalize(gridLayers);
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
        private InstCrateFrame SelectedCrate => lbCrates.SelectedItem as InstCrateFrame;
        #endregion

        #region Event handlers
        private void OnSelectedCrateChanged(object sender, EventArgs e)
        {
            DrawCrate();
            FillGridLayers();
            InstCrateFrame crate = SelectedCrate;
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
        #endregion

        #region Data members
        public Project Project { get; set; }
        protected ILog _log = LogManager.GetLogger(typeof(DockContentCratesFrame));
        #endregion
    }
}

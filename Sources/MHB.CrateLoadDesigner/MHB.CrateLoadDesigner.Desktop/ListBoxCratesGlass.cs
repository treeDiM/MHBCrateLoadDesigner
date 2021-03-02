#region Using directives
using System.Drawing;
using System.Windows.Forms;

using treeDiM.StackBuilder.Graphics;

using MHB.CrateLoadDesigner.Engine;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class ListBoxCratesGlass : ListBox
    {
        #region Constructor
        public ListBoxCratesGlass()
        {
            InitializeComponent();
        }
        #endregion

        #region Override ListBox
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (!DesignMode && Items.Count > 0 && e.Index != -1)
            {
                var imageSize = new Size(e.Bounds.Width, e.Bounds.Height);
                bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                var crate = Items[e.Index] as InstCrateGlass;

                switch (crate.Parent.CrateType)
                {
                    case DefCrateGlass.EType.VERTICAL:
                        e.Graphics.DrawImage(
                            LayeredCrateToImage.Draw(
                                GraphicHelpers.CrateToBoxes(crate),
                                crate.OuterDimensions, Color.White,
                                selected, false,
                                imageSize),
                            e.Bounds.Left,
                            e.Bounds.Top);
                        break;
                    case DefCrateGlass.EType.AFRAME:
                        e.Graphics.DrawImage(
                            NonLayeredCrateToImage.Draw(
                                GraphicHelpers.CrateToBoxesExplicitDir(crate, 10.0),
                                crate.OuterDimensions, Color.White,
                                selected, false,
                                imageSize),
                            e.Bounds.Left,
                            e.Bounds.Top);
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
    }
}

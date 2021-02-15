#region Using directives
using System.Drawing;
using System.Windows.Forms;

using treeDiM.StackBuilder.Graphics;

using MHB.CrateLoadDesigner.Engine;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class ListBoxContainers : ListBox
    {
        #region Constructor
        public ListBoxContainers()
        {
            DoubleBuffered = true;
            DrawMode = DrawMode.OwnerDrawFixed;
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
                var container = Items[e.Index] as InstContainer;
                e.Graphics.DrawImage(
                    LayeredCrateToImage.Draw(
                        GraphicHelpers.ContainerToBoxes(container),
                        container.Dimensions, Color.White,
                        selected, false,
                        imageSize
                        ),
                    e.Bounds.Left,
                    e.Bounds.Top);
            }
        }
    }
    #endregion
}


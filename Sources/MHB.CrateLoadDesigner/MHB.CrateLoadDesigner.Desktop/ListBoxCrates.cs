#region Using directives
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;

using MHB.CrateLoadDesigner.Engine;
#endregion

namespace MHB.CrateLoadDesigner.Desktop
{
    public partial class ListBoxCrates : ListBox
    {
        public ListBoxCrates() : base()
        {
            DoubleBuffered = true;
            DrawMode = DrawMode.OwnerDrawFixed;
        }

        #region Override ListBox
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (!DesignMode && Items.Count > 0 && e.Index != -1)
            {
                var item = new ItemCrateFrame(
                    Items[e.Index] as InstCrateFrame,
                    (e.State & DrawItemState.Selected) == DrawItemState.Selected,
                    new Size(e.Bounds.Width, e.Bounds.Height));
                e.Graphics.DrawImage(item.Image, e.Bounds.Left, e.Bounds.Top);
            }
        }
        #endregion
    }

    public class ItemCrateFrame
    {
        public ItemCrateFrame(InstCrateFrame crate, bool selected, Size imageSize)
        {
            Image = LayeredCrateToImage.Draw(
                GraphicHelpers.CrateToBoxes(crate),
                crate.OuterDimensions,
                selected,
                imageSize);
        }
        public Image Image { get; set; }
        private InstCrateFrame Crate { get; set; }
        public override string ToString() => Crate.ToString();        
    }
}

using Microsoft.Xna.Framework;

namespace Jewel_Jam
{
    internal class RowSelector : SpriteGameObject
    {
        private int selectedRow;
        private JewelGrid grid;

        public RowSelector(JewelGrid grid) : base("spr_selector_frame")
        {
            this.grid = grid;
            selectedRow = 0;
            origin = new Vector2(10, 10);
        }
    }
}
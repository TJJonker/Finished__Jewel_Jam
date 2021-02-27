using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Up))
                selectedRow--;
            else if (inputHelper.KeyPressed(Keys.Down))
                selectedRow++;

            selectedRow = MathHelper.Clamp(selectedRow, 0, grid.Height - 1);
            Position = grid.GetCellPosition(0, selectedRow);

            if (inputHelper.KeyPressed(Keys.Left))
                grid.ShiftRowLeft(selectedRow);
            else if (inputHelper.KeyPressed(Keys.Right))
                grid.ShiftRowRight(selectedRow);
        }
    }
}
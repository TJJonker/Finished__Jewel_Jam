using Microsoft.Xna.Framework;

namespace Jewel_Jam
{
    internal class JewelJam : ExtendedGame
    {
        private const int GridWidth = 5;
        private const int GridHeight = 10;
        private const int CellSize = 85;
        private Vector2 GridOffset = new Vector2(85, 150);

        private JewelGrid jewelGrid;

        public JewelJam()
        {
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            SpriteGameObject background = new SpriteGameObject("spr_background");
            gameWorld.AddChild(background);

            jewelGrid = new JewelGrid(GridWidth, GridHeight, CellSize, GridOffset);
            gameWorld.AddChild(jewelGrid);

            worldSize = new Point(background.Width, background.Height);

            FullScreen = false;
        }
    }
}
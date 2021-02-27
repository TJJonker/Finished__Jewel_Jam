using Microsoft.Xna.Framework;

namespace Jewel_Jam
{
    internal class JewelJam : ExtendedGame
    {
        private const int GridWidth = 5;
        private const int GridHeight = 10;
        private const int CellSize = 85;
        private Vector2 GridOffset = new Vector2(85, 150);

        public JewelJam()
        {
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            SpriteGameObject background = new SpriteGameObject("spr_background");
            gameWorld.AddChild(background);

            // Create PlayingField and add it do gameWorld
            GameObjectList playingField = new GameObjectList();
            playingField.Position = GridOffset;
            gameWorld.AddChild(playingField);

            // Create new grid and add it to playingField
            JewelGrid grid = new JewelGrid(GridWidth, GridHeight, CellSize);
            playingField.AddChild(grid);

            // Create new RowSelector and add it to playingField
            playingField.AddChild(new RowSelector(grid));


            worldSize = new Point(background.Width, background.Height);

            FullScreen = false;
        }
    }
}
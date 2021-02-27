using Microsoft.Xna.Framework;

namespace Jewel_Jam
{
    internal class JewelJamGameWorld : GameObjectList
    {

        const int GridWidth = 5;
        const int GridHeight = 10;
        const int CellSize = 85;

        public Point Size { get; private set; }
        public int Score { get; private set; }

        public JewelJamGameWorld()
        {
            SpriteGameObject background = new SpriteGameObject("spr_background");
            Size = new Point(background.Width, background.Height);
            AddChild(background);

            // Create PlayingField and add it do gameWorld
            GameObjectList playingField = new GameObjectList();
            playingField.Position = new Vector2(85, 150);
            AddChild(playingField);

            // Create new grid and add it to playingField
            JewelGrid grid = new JewelGrid(GridWidth, GridHeight, CellSize);
            playingField.AddChild(grid);

            // Create new RowSelector and add it to playingField
            playingField.AddChild(new RowSelector(grid));

            Reset();
        }

        public void AddScore(int points)
        {
            Score += points;
        }

        public override void Reset()
        {
            base.Reset();
            Score = 0;
        }

    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jewel_Jam
{
    internal class JewelGrid : GameObject
    {
        private Jewel[,] grid;
        private int gridWidth, gridHeight, cellSize;

        public JewelGrid(int width, int height, int cellSize, Vector2 offset)
        {
            gridWidth = width;
            gridHeight = height;
            this.cellSize = cellSize;
            Position = offset;

            Reset();
        }

        public override void Reset()
        {
            grid = new Jewel[gridWidth, gridHeight];

            for (int x = 0; x < gridWidth; x++)
                for (int y = 0; y < gridHeight; y++)
                {
                    grid[x, y] = new Jewel(ExtendedGame.Random.Next(3))
                    {
                        Position = GetCellPosition(x, y),
                        Parent = this
                    };
                }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Jewel jewel in grid)
                jewel.Draw(gameTime, spriteBatch);
        }

        /// <summary>
        /// Deletes the bottom row of the grid and spawns a new row on top
        /// </summary>
        private void MoveRowsDown()
        {
            // Replaces all the Jewels with the Jewel above them
            for (int y = gridHeight - 1; y > 0; y--)
                for (int x = 0; x < gridWidth; x++)
                {
                    grid[x, y] = grid[x, y - 1];
                    grid[x, y].Position = GetCellPosition(x, y);
                }

            // Fills top row with new Jewels
            for (int x = 0; x < gridWidth; x++)
            {
                grid[x, 0] = new Jewel(ExtendedGame.Random.Next(3))
                {
                    Position = GetCellPosition(x, 0),
                    Parent = this
                };
            }
        }

        private Vector2 GetCellPosition(int x, int y)
        {
            return new Vector2(x * cellSize, y * cellSize);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Space))
                MoveRowsDown();
        }
    }
}
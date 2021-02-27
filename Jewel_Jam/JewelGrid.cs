using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Security.Cryptography.X509Certificates;

namespace Jewel_Jam
{
    internal class JewelGrid : GameObject
    {
        private Jewel[,] grid;
        private int cellSize;

        public int Height { get; private set; }
        public int Width { get; private set; }

        public JewelGrid(int width, int height, int cellSize)
        {
            Width = width;
            Height = height;
            this.cellSize = cellSize;

            Reset();
        }

        public override void Reset()
        {
            grid = new Jewel[Width, Height];

            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
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
            for (int y = Height - 1; y > 0; y--)
                for (int x = 0; x < Width; x++)
                {
                    grid[x, y] = grid[x, y - 1];
                    grid[x, y].Position = GetCellPosition(x, y);
                }

            // Fills top row with new Jewels
            for (int x = 0; x < Width; x++)
            {
                grid[x, 0] = new Jewel(ExtendedGame.Random.Next(3))
                {
                    Position = GetCellPosition(x, 0),
                    Parent = this
                };
            }
        }

        /// <summary>
        /// Returns position based on cellsize
        /// </summary>
        /// <param name="x">X position on the grid</param>
        /// <param name="y">Y position on the grid</param>
        /// <returns></returns>
        public Vector2 GetCellPosition(int x, int y)
        {
            return new Vector2(x * cellSize, y * cellSize);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.Space))
                MoveRowsDown();
        }
        

        public void ShiftRowLeft(int selectedRow)
        {
            // Store the left most Jewel for backup
            Jewel first = grid[0, selectedRow];

            // Replace all the Jewels with their right neighbour
            for (int x = 0; x < Width - 1; x++)
            {
                grid[x, selectedRow] = grid[x + 1, selectedRow];
                grid[x, selectedRow].Position = GetCellPosition(x, selectedRow);
            }

            // Re-insert the backup Jewel in the Right most spot
            grid[Width - 1, selectedRow] = first;
            grid[Width - 1, selectedRow].Position = GetCellPosition(Width - 1, selectedRow);
        }

        public void ShiftRowRight(int selectedRow)
        {
            // Store the right most Jewel for backup
            Jewel first = grid[Width - 1, selectedRow];

            // replace all the Jewel with their left neighbour
            for(int x = Width - 1; x > 0; x--)
            {
                grid[x, selectedRow] = grid[x - 1, selectedRow];
                grid[x, selectedRow].Position = GetCellPosition(x, selectedRow);
            }

            // Replace the left most jewel with the backup
            grid[0, selectedRow] = first;
            grid[0, selectedRow].Position = GetCellPosition(0, selectedRow);
        }
    }
}
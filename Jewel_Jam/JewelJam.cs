using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Jewel_Jam
{
    public class JewelJam : Game
    {
        private const int GridWidth = 5;
        private const int GridHeight = 10;
        private const int CellSize = 85;

        // Vector2 is not allowed to be a constant
        private readonly Vector2 GridOffset = new Vector2(85, 150);

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Point worldSize, windowSize;
        private InputHelper inputHelper;
        private Texture2D background;
        private Texture2D[] jewels;
        private Matrix spriteScale;
        private int[,] grid;
        private static Random random;



        public JewelJam()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            inputHelper = new InputHelper();
            grid = new int[GridWidth, GridHeight];
            random = new Random();

            for (int x = 0; x < GridWidth; x++)
                for (int y = 0; y < GridHeight; y++)
                    grid[x, y] = random.Next(3);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("spr_background");

            jewels = new Texture2D[3];
            jewels[0] = Content.Load<Texture2D>("spr_single_jewel1");
            jewels[1] = Content.Load<Texture2D>("spr_single_jewel2");
            jewels[2] = Content.Load<Texture2D>("spr_single_jewel3");

            worldSize = new Point(background.Width, background.Height);
            windowSize = new Point(1024, 768);

            FullScreen = false;
        }

        protected override void Update(GameTime gameTime)
        {
            inputHelper.Update();
            if (inputHelper.KeyPressed(Keys.F5))
                FullScreen = !FullScreen;
            if (inputHelper.KeyPressed(Keys.Escape))
                Exit();
            if (inputHelper.KeyPressed(Keys.Space))
                MoveRowsDown();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            // Drawing the grid
            for (int x = 0; x < GridWidth; x++)
                for (int y = 0; y < GridHeight; y++)
                {
                    Vector2 position = GridOffset + new Vector2(x, y) * CellSize;
                    spriteBatch.Draw(jewels[grid[x, y]], position, Color.White);
                }

            spriteBatch.End();
        }

        

        /// <summary>
        /// Deletes the bottom row of the grid and spawns a new row on top
        /// </summary>
        private void MoveRowsDown()
        {
            // Replaces all the Jewels with the Jewel above them
            for(int y = GridHeight - 1; y > 0; y--)
                for(int x = 0; x < GridWidth; x++)
                    grid[x, y] = grid[x, y - 1];
            
            // Fills top row with new Jewels
            for (int x = 0; x < GridWidth; x++)
                grid[x, 0] = random.Next(3);
        }
    }
}
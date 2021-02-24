using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jewel_Jam
{
    public class JewelJam : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Point worldSize, windowSize;
        private Texture2D background;
        private Matrix spriteScale;

        public JewelJam()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("spr_background");

            worldSize = new Point(background.Width, background.Height);
            windowSize = new Point(1024, 768);

            ApplyResolutionSettings();
        }

        protected override void Update(GameTime gameTime)
        {
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        private void ApplyResolutionSettings()
        {
            graphics.PreferredBackBufferWidth = windowSize.X;
            graphics.PreferredBackBufferHeight = windowSize.Y;
            graphics.ApplyChanges();
            spriteScale = Matrix.CreateScale((float)windowSize.X / worldSize.X, (float)windowSize.Y / worldSize.Y, 1);
        }
    }
}
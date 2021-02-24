using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Jewel_Jam
{
    public class JewelJam : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Point worldSize, windowSize;
        private InputHelper inputHelper;
        private Texture2D background;
        private Matrix spriteScale;

        private bool FullScreen
        {
            get { return graphics.IsFullScreen; }
            set { ApplyResolutionSettings(value); }
        }

        public JewelJam()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            inputHelper = new InputHelper();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("spr_background");

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
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.End();
        }

        private void ApplyResolutionSettings(bool fullScreen)
        {
            graphics.IsFullScreen = fullScreen;

            Point screenSize;
            if (fullScreen)
            {
                screenSize = new Point(
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            }
            else
            {
                screenSize = windowSize;
            }

            graphics.PreferredBackBufferWidth = screenSize.X;
            graphics.PreferredBackBufferHeight = screenSize.Y;
            graphics.ApplyChanges();
            spriteScale = Matrix.CreateScale((float)screenSize.X / worldSize.X, (float)screenSize.Y / worldSize.Y, 1);
        }
    }
}
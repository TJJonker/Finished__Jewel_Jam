using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Jewel_Jam
{
    internal class ExtendedGame : Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected InputHelper inputHelper;
        protected Point worldSize;
        protected Point windowSize;
        protected Matrix spriteScale;
        protected static GameObjectList gameWorld;

        public static Random Random { get; private set; }
        public static ContentManager ContentManager { get; private set; }

        public bool FullScreen
        {
            get { return graphics.IsFullScreen; }
            protected set { ApplyResolutionSettings(value); }
        }

        protected ExtendedGame()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);

            inputHelper = new InputHelper();
            Random = new Random();

            windowSize = new Point(1024, 768);
            worldSize = new Point(1024, 768);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentManager = Content;
            FullScreen = false;
            gameWorld = new GameObjectList();
        }

        protected override void Update(GameTime gameTime)
        {
            HandleInput();
            gameWorld.Update(gameTime);
        }

        protected virtual void HandleInput()
        {
            inputHelper.Update();

            if (inputHelper.KeyPressed(Keys.Escape))
                Exit();
            if (inputHelper.KeyPressed(Keys.F5))
                FullScreen = !FullScreen;

            gameWorld.HandleInput(inputHelper);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, spriteScale);

            gameWorld.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }

        /// <summary>
        /// Changes the resolution to full screen or windowed mode
        /// </summary>
        /// <param name="fullScreen">Full screen or not</param>
        private void ApplyResolutionSettings(bool fullScreen)
        {
            // Sets screen to fullscreen or not
            graphics.IsFullScreen = fullScreen;

            Point screenSize;
            if (fullScreen)
            {
                // sets screen size to fullscreen
                screenSize = new Point(
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            }
            else
            {
                // sets screen size to window size
                screenSize = windowSize;
            }

            // Changes screen size
            graphics.PreferredBackBufferWidth = screenSize.X;
            graphics.PreferredBackBufferHeight = screenSize.Y;
            graphics.ApplyChanges();

            // Calculates Viewport AspectRatio
            GraphicsDevice.Viewport = CalculateViewport(screenSize);

            // Sets scale for the game
            spriteScale = Matrix.CreateScale(
                (float)GraphicsDevice.Viewport.Width / worldSize.X,
                (float)GraphicsDevice.Viewport.Height / worldSize.Y, 1);
        }

        /// <summary>
        /// Calculates and returns viewport with the right aspect-ratio
        /// </summary>
        /// <param name="windowSize"> Window size chosen for the game </param>
        /// <returns></returns>
        private Viewport CalculateViewport(Point windowSize)
        {
            Viewport viewport = new Viewport();
            float gameAspectRatio = (float)worldSize.X / worldSize.Y;
            float windowAspectRatio = (float)windowSize.X / windowSize.Y;
            // Checks aspectRatios of window and GameWorld
            if (windowAspectRatio > gameAspectRatio)
            {
                // Window too wide
                viewport.Width = (int)(windowSize.Y * gameAspectRatio);
                viewport.Height = windowSize.Y;
            }
            else
            {
                // Window too high
                viewport.Width = windowSize.X;
                viewport.Height = (int)(windowSize.X / gameAspectRatio);
            }

            viewport.X = (windowSize.X - viewport.Width) / 2;
            viewport.Y = (windowSize.Y - viewport.Height) / 2;

            return viewport;
        }

        /// <summary>
        /// Convert Screen position to GameWorld position
        /// </summary>
        /// <param name="screenPosition"> Position on screen </param>
        /// <returns></returns>
        private Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            // Takes top left position of the game window
            Vector2 viewportTopLeft = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);

            // Calculates scale
            float screenToWorldScale = worldSize.X / (float)GraphicsDevice.Viewport.Width;

            // Returns position in GameWorld
            return (screenPosition - viewportTopLeft) * screenToWorldScale;
        }
    }
}
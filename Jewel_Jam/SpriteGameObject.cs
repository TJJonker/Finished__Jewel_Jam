using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jewel_Jam
{
    internal class SpriteGameObject : GameObject
    {
        protected Texture2D sprite;
        protected Vector2 origin;

        public int Width { get { return sprite.Width; } }
        public int Height { get { return sprite.Height; } }

        public SpriteGameObject(string spriteName)
        {
            sprite = ExtendedGame.ContentManager.Load<Texture2D>(spriteName);
            origin = Vector2.Zero;
        }

        /// <summary>
        /// Returns a rectangle that describes this game object's bounding box
        /// Usefull for collision detection
        /// </summary>
        public Rectangle BoundingBox
        {
            get
            {
                Rectangle spriteBounds = sprite.Bounds;
                spriteBounds.Offset(Position - origin);
                return spriteBounds;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Visible)
                spriteBatch.Draw(sprite, Position, null, Color.White, 0, origin, 1.0f, SpriteEffects.None, 0);
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jewel_Jam
{
    internal class JewelCart : SpriteGameObject
    {
        private const float speed = 10;
        private const float pushDistance = 100;
        private float startX;
        private GlitterField glitters;

        public JewelCart(Vector2 startPosition) : base("spr_jewelcart")
        {
            Position = startPosition;
            startX = startPosition.X;
            glitters = new GlitterField(sprite, 40, new Rectangle(275, 470, 430, 85));
            glitters.Parent = this;
        }

        public void PushBack()
        {
            Position = new Vector2(MathHelper.Max(Position.X - pushDistance, startX), Position.Y);
        }

        public override void Reset()
        {
            velocity.X = speed;
            Position = new Vector2(startX, Position.Y);
        }

        public override void Update(GameTime gameTime)
        {
            glitters.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            glitters.Draw(gameTime, spriteBatch);
            base.Draw(gameTime, spriteBatch);
        }
    }
}
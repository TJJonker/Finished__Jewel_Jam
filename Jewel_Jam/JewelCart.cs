using Microsoft.Xna.Framework;

namespace Jewel_Jam
{
    internal class JewelCart : SpriteGameObject
    {
        private const float speed = 10;
        private const float pushDistance = 100;
        private float startX;

        public JewelCart(Vector2 startPosition) : base("spr_jewelcart")
        {
            Position = startPosition;
            startX = startPosition.X;
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
    }
}
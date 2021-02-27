using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Net.Security;

namespace Jewel_Jam
{
    internal class Jewel : SpriteGameObject
    {
        public int ColorType { get; private set; }
        public int ShapeType { get; private set; }
        public int NumberType { get; private set; }

        Rectangle spriteRectangle;

        public Jewel() : base("spr_jewels")
        {
            ColorType = ExtendedGame.Random.Next(3);
            ShapeType = ExtendedGame.Random.Next(3);
            NumberType = ExtendedGame.Random.Next(3);

            int index = 9 * ColorType + 3 * ShapeType + NumberType;
            spriteRectangle = new Rectangle(index * sprite.Height, 0, sprite.Height, sprite.Height);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GlobalPosition, spriteRectangle, Color.White);
        }
    }
}
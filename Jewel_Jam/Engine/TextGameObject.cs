using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jewel_Jam
{
    internal class TextGameObject : GameObject
    {
        protected SpriteFont font;
        protected Color color;
        public string Text { get; set; }

        public enum Alignment
        {
            Left, Right, Center
        }

        protected Alignment alignment;

        public TextGameObject(string fontName, Color color, Alignment alignment = Alignment.Left)
        {
            font = ExtendedGame.AssetManager.LoadFont(fontName);
            this.color = color;
            this.alignment = alignment;

            Text = "";
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!Visible) return;

            // Calculate the origin
            Vector2 origin = new Vector2(OriginX, 0);

            // Draw the text
            spriteBatch.DrawString(font, Text, GlobalPosition, color, 0f, origin, 1, SpriteEffects.None, 0);
        }

        private float OriginX
        {
            get
            {
                if (alignment == Alignment.Left) return 0;
                if (alignment == Alignment.Right) return font.MeasureString(Text).X;
                return font.MeasureString(Text).X / 2;
            }
        }
    }
}
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Jewel_Jam
{
    internal class GlitterField : GameObject
    {
        Texture2D glitter;
        Texture2D target;
        Rectangle targetRectangle;

        List<Vector2> positions;
        List<float> scales;

        public GlitterField(Texture2D target, int numberOfGlitters, Rectangle targetRectangle)
        {
            glitter = ExtendedGame.AssetManager.LoadSprite("spr_glitter");
            this.target = target;
            this.targetRectangle = targetRectangle;
            positions = new List<Vector2>();
            scales = new List<float>();

            for(int i = 0; i < numberOfGlitters; i++)
            {
                positions.Add(CreateRandomPositions());
                scales.Add(0f);
            }
        }

        private Vector2 CreateRandomPositions()
        {
            while (true)
            {
                Point randomPos = new Point(
                    ExtendedGame.Random.Next(targetRectangle.Width),
                    ExtendedGame.Random.Next(targetRectangle.Height)) + targetRectangle.Location;

                Rectangle rect = new Rectangle(randomPos, new Point(1, 1));
                Color[] retrievedColor = new Color[1];
                target.GetData(0, rect, retrievedColor, 0, 1);

                if (retrievedColor[0].A == 255)
                    return randomPos.ToVector2();
            }
        }

        public override void Update(GameTime gameTime)
        {
            for(int i = 0; i < positions.Count; i++)
            {
                if(scales[i] > 0 || ExtendedGame.Random.NextDouble() < 0.001)
                {
                    scales[i] += 2 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if(scales[i] >= 2.00f)
                    {
                        scales[i] = 0f;
                        positions[i] = CreateRandomPositions();
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Vector2 glitterCenter = new Vector2(glitter.Width, glitter.Height) / 2;
            for(int i = 0; i < scales.Count; i++)
            {
                float scale = scales[i];
                if (scales[i] > 1)
                    scale = 2 - scales[i];

                spriteBatch.Draw(glitter, GlobalPosition + positions[i], null, Color.White, 0f, glitterCenter, scale, SpriteEffects.None, 0);
            }
        }
    }
}
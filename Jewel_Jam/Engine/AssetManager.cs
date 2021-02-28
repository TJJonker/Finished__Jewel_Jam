using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Jewel_Jam
{
    internal class AssetManager
    {
        ContentManager contentManager;

        public AssetManager(ContentManager Content)
        {
            contentManager = Content;
        }

        public Texture2D LoadSprite(string sprite)
        {
            return contentManager.Load<Texture2D>(sprite);
        }

        public SpriteFont LoadFont(string font)
        {
            return contentManager.Load<SpriteFont>(font);
        }

        public void PlaySoundEffect(string soundEffect)
        {
            SoundEffect snd = contentManager.Load<SoundEffect>(soundEffect);
            snd.Play();
        }

        public void PlaySong(string song, bool loop)
        {
            MediaPlayer.IsRepeating = loop;
            MediaPlayer.Play(contentManager.Load<Song>(song));
        }
    }
}
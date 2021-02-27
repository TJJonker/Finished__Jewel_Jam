using Microsoft.Xna.Framework;

namespace Jewel_Jam
{
    internal class JewelJam : ExtendedGame
    {

        public JewelJam()
        {
            IsMouseVisible = true;
        }

        public static JewelJamGameWorld GameWorld
        {
            get { return (JewelJamGameWorld)gameWorld; }
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            gameWorld = new JewelJamGameWorld();
    
            worldSize = GameWorld.Size;

            FullScreen = false;
        }
    }
}
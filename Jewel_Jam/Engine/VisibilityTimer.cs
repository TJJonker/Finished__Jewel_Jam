using Microsoft.Xna.Framework;

namespace Jewel_Jam
{
    internal class VisibilityTimer : GameObject
    {
        private GameObject target;
        private float timeleft;

        public VisibilityTimer(GameObject target)
        {
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {
            if(timeleft < 0)
                return;

            timeleft -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeleft <= 0)
                target.Visible = false;
        }

        public void StartVisible(float seconds)
        {
            timeleft = seconds;
            target.Visible = true;
        }
    }
}
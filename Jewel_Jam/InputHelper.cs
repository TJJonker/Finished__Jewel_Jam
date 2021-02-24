using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Jewel_Jam
{
    internal class InputHelper
    {
        private MouseState currentMouseState, previousMouseState;
        private KeyboardState currentKeyboardState, previousKeyboardState;

        public void Update()
        {
            // Mouse Input
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            // Keyboard Input
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public bool KeyPressed(Keys k)
        {
            return currentKeyboardState.IsKeyDown(k) && previousKeyboardState.IsKeyUp(k);
        }

        public bool MouseLeftButtonPressed()
        {
            return currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released;
        }

        public Vector2 MousePosition
        {
            get { return new Vector2(currentMouseState.X, currentMouseState.Y); }
        }
    }
}
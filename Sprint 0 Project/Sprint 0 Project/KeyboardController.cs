using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sprint_0_Project
{
    internal class KeyboardController : IController
    {

        private KeyboardState keyboardState;
        private Keys right;
        private Keys left;
        private Keys down;
        private Keys jump;
        public Vector2 movementDirection;

        public KeyboardController()
        {

            right = Keys.D;
            left = Keys.A;
            down = Keys.S;
            jump = Keys.Space;

        }

        public Vector2 UpdateMovement()
        {

            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(right))
            {
                movementDirection.X = 1;
            }
            else if (keyboardState.IsKeyDown(left))
            {
                movementDirection.X = -1;
            }
            else if (keyboardState.IsKeyDown(down))
            {
                movementDirection.Y = 1;
            }
            else if (keyboardState.IsKeyDown(jump))
            {
                movementDirection.Y = -5;
            }
            else
            {
                movementDirection = Vector2.Zero;
            }

            return movementDirection;

        }

        public void Update() { }
        public Vector2 MousePos() { return Vector2.Zero; }

    }
}

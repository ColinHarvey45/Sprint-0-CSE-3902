using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Sprint_0_Project
{
    internal class MouseController : IController
    {
        private MouseState mouseState;
        private Vector2 mousePos;
        private Texture2D spriteTexture;
        ISprite sprite;

        public MouseController(Texture2D texture, SpriteBatch spriteBatch)
        {
            mousePos = new Vector2(mouseState.X, mouseState.Y);
            sprite = new Sprite(texture, spriteBatch, mousePos, new Point(32, 0));
            spriteTexture = texture;


        }

        public Vector2 MousePos()
        {
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                mousePos = new Vector2(mouseState.X, mouseState.Y);

            }

            return mousePos;

        }

        // Mouse not used for movement
        public Vector2 UpdateMovement()
        { return Vector2.Zero; }
        public void Update() { }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint_0_Project
{
    internal class AnimatedSprite : Sprite
    {
        private int currentFrame;
        private int totalFrames;
        private double frameTimer;
        private double frameInterval;

        public AnimatedSprite(Texture2D texture, SpriteBatch passedSpriteBatch, Vector2 position, Point rectLocation, int numFrames) : base(texture, passedSpriteBatch, position, rectLocation)
        {

            // The larger the interval the slower the speed of the animation
            frameInterval = 0.5f;
            frameTimer = 0;
            totalFrames = numFrames;
            currentFrame = 0;

        }

        public void UpdateAnimation(GameTime gameTime, Vector2 movement)
        {

            spritePosition += movement;

            frameTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (movement == Vector2.Zero)
            {
                sourceRect = new Rectangle(1, 207, rectSize.X, rectSize.Y);
                currentFrame = 1;
            }
            else if (frameTimer >= frameInterval)
            {
                currentFrame++;
                if (currentFrame >= totalFrames)
                {
                    currentFrame = 1;
                }

                frameTimer -= frameInterval;

                int column = currentFrame % 4;
                int row = currentFrame / 4;

                int newX = location.X + (column * rectSize.X);
                int newY = location.Y + (row * rectSize.Y);

                sourceRect = new Rectangle(newX, newY, rectSize.X, rectSize.Y);

            }

        }

    }
}

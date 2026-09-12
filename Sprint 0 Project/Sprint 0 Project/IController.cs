using Microsoft.Xna.Framework;
using System;


namespace Sprint_0_Project
{
    internal interface IController
    {

        public void Update();
        public Vector2 MousePos();

        public Vector2 UpdateMovement();

    }
}

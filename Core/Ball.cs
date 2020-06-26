using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Core
{
    /// <summary>
    /// Ball
    /// </summary>
    class Ball : Drawable
    {
        public readonly Color BallColor;
        public uint X;
        public uint Y;
        public readonly RectangleShape BackRect;
        public int deltaX;
        public int deltaY;

        /// <summary>
        /// Create Ball
        /// </summary>
        public Ball()
        {
            X = Dimensions.WindowWidth / 2;
            Y = Dimensions.WindowHeight / 2;

            deltaX = 1;
            deltaY = 1;

            BallColor = Color.White;

            BackRect = new RectangleShape(new Vector2f(10, 10));
            BackRect.FillColor = BallColor;
            BackRect.Position = new Vector2f(X, Y);
        }

        /// <summary>
        /// Call it when you want to draw ball
        /// </summary>
        /// <param name="target"></param>
        /// <param name="states"></param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            BackRect.Draw(target, states);
        }

        /// <summary>
        /// Call when you want to move ball
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Move(object sender, ElapsedEventArgs args)
        {
            if (deltaX > 0) X += (uint)deltaX;
            if (deltaX < 0) X -= (uint)deltaX;
            if (deltaY > 0) Y += (uint)deltaY;
            if (deltaY < 0) Y -= (uint)deltaY;

            BackRect.Position = new Vector2f(X, Y);
        }
    }
}

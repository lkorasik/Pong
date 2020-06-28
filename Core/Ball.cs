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
    class Ball : Drawable, IDebuggable
    {
        public readonly Color BallColor;
        public float X;
        public float Y;
        public readonly CircleShape BackRect;
        public Vector2f moveVector;
        public float speed;
        public float direction;
        public readonly int radius;

        /// <summary>
        /// Create Ball
        /// </summary>
        public Ball()
        {
            radius = 5;

            X = Dimensions.WindowWidth / 2 - radius;
            Y = Dimensions.WindowHeight / 2 - radius;

            speed = 5;
            direction = 0;
            //moveVector = new Vector2f(2, 2);
            moveVector = new Vector2f((float)(speed * Math.Cos(direction)), (float)(speed * Math.Sin(direction)));

            BallColor = Color.White;

            //BackRect = new RectangleShape(new Vector2f(10, 10));
            BackRect = new CircleShape(radius, 100);
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

        public void RecalcDirection()
        {
            moveVector = new Vector2f((float)(speed * Math.Cos(direction)), (float)(speed * Math.Sin(direction)));
        }

        /// <summary>
        /// Call when you want to move ball
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Move(object sender, ElapsedEventArgs args)
        {
            BackRect.Position = new Vector2f(X, Y);
        }

        public void CheckWallCollisions(object sender, ElapsedEventArgs args)
        {
            if (!((BackRect.Position.X < Dimensions.WindowWidth - 10) && (BackRect.Position.X > 0)))
                moveVector.X *= -1;
            X += moveVector.X;

            if (!((BackRect.Position.Y < Dimensions.WindowHeight - 10) && (BackRect.Position.Y > 0)))
                moveVector.Y *= -1;
            Y += moveVector.Y;
        }

        /// <summary>
        /// Display Debug info about ball position
        /// </summary>
        /// <returns>string with info</returns>
        public string GetDebugDisplayInfo()
        {
            return "Ball: \n\tX: " + X + "\n\tY: " + Y + "\n\tdx: " + moveVector.X;
        }

        /// <summary>
        /// Get counts of lines in debug info
        /// </summary>
        /// <returns>Count</returns>
        public int GetDebugDisplayInfoLinesCount()
        {
            return 4;
        }
    }
}

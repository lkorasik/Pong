using Pong.Core;
using SFML.Graphics;
using SFML.System;
using System;
using System.Drawing;
using SFMLColor = SFML.Graphics.Color;

namespace Pong.Models
{
    /// <summary>
    /// Create ball
    /// </summary>
    class Ball : Drawable, IMovable
    {
        private float X;
        private float Y;
        private readonly float StartX;
        private readonly float StartY;
        private int Width;
        private int Height;
        private RectangleShape BallView;
        private float Direction;
        private float Speed;
        private Vector2f MoveVector;

        /// <summary>
        /// Create ball
        /// </summary>
        public Ball()
        {
            Width = 10;
            Height = 10;

            X = Constants.WindowWidth / 2 - Width / 2;
            Y = Constants.WindowHeight / 2 - Height / 2;

            StartX = X;
            StartY = Y;

            BallView = new RectangleShape(new Vector2f(Width, Height));
            BallView.Position = new Vector2f(X, Y);
            BallView.FillColor = SFMLColor.White;

            Speed = 1;
            Direction = (float) Math.PI/4;
            MoveVector = new Vector2f((float)(Speed * Math.Cos(Direction)), (float)(Speed * Math.Sin(Direction)));

            Console.WriteLine("Ball inited");
        }

        /// <summary>
        /// Draw ball
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            BallView.Draw(target, states);
        }

        /// <summary>
        /// Move ball
        /// </summary>
        public void Move()
        {
            X += (float)(Speed * Math.Cos(Direction));
            Y += (float)(Speed * Math.Sin(Direction));
            BallView.Position = new Vector2f(X, Y);
        }

        /// <summary>
        /// Print position
        /// </summary>
        public void DebugPrintPosition()
        {
            Console.WriteLine("Ball X: {0}, Y: {1}", X, Y);
        }

        /// <summary>
        /// Up left corner
        /// </summary>
        /// <returns>PointF</returns>
        public PointF GetUpLeftPoint()
        {
            return new PointF(X, Y);
        }

        /// <summary>
        /// Right Down corner
        /// </summary>
        /// <returns></returns>
        public PointF GetDownRightPoint()
        {
            return new PointF(X + Width, Y + Height);
        }

        /// <summary>
        /// Set Direction
        /// </summary>
        /// <param name="angle">Angle</param>
        public void SetDirection(float angle)
        {
            Direction = angle;
        }

        /// <summary>
        /// Get Direction
        /// </summary>
        /// <returns>Angle</returns>
        public float GetDirection()
        {
            return Direction;
        }

        /// <summary>
        /// Return ball to center
        /// </summary>
        public void ResetPosition()
        {
            X = StartX;
            Y = StartY;
            BallView.Position = new Vector2f(X, Y);
        }
    }
}

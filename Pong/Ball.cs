using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    /// <summary>
    /// Описание шарика
    /// </summary>
    class Ball : Drawable
    {
        private uint X;
        private uint Y;
        private uint radius;
        private CircleShape Shape;
        public uint PositionX => X;
        public uint PositionY => Y;

        /// <summary>
        /// Создать шарик
        /// </summary>
        public Ball()
        {
            radius = 5;

            X = Constants.WindowWidth / 2 - radius;
            Y = Constants.WindowHeight / 2 - radius;

            Shape = new CircleShape(radius);
            Shape.FillColor = Color.Red;
            Shape.Position = new Vector2f(X, Y);
        }

        public void MoveHorizontal(int dx)
        {
            if (dx > 0)
                X += (uint)dx;
            else
                X -= (uint)dx;
            Shape.Position = new Vector2f(X, Y);
        }

        public void MoveVertical(int dy)
        {
            if (dy > 0)
                Y += (uint)dy;
            else
                Y -= (uint)dy;
            Shape.Position = new Vector2f(X, Y);
        }

        /// <summary>
        /// Нарисовать шарик
        /// </summary>
        /// <param name="target">SFML</param>
        /// <param name="states">SFML</param>
        public void Draw(RenderTarget target, RenderStates states)
        {
            Shape.Draw(target, states);
        }
    }
}

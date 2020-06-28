using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Color = SFML.Graphics.Color;

namespace Pong
{
    /// <summary>
    /// Описание шарика
    /// </summary>
    class Ball : Drawable
    {
        private float X;
        private float Y;
        public Vector2f MoveVector;
        private RectangleShape Shape;
        public float PositionX => X;
        public float PositionY => Y;

        /// <summary>
        /// Создать шарик
        /// </summary>
        public Ball()
        {
            X = Constants.WindowWidth / 2 - 5;
            Y = Constants.WindowHeight / 2 - 5;

            MoveVector = new Vector2f(1f, 0f);

            Shape = new RectangleShape(new Vector2f(10, 10));
            Shape.FillColor = Color.Red;
            Shape.Position = new Vector2f(X, Y);
        }

        public void RecalcMoveVector(float angle)
        {
            var speed = Math.Sqrt(MoveVector.X * MoveVector.X + MoveVector.Y * MoveVector.Y);
            MoveVector = new Vector2f((float)(speed * Math.Cos(angle)), (float)(speed * -Math.Sin(angle)));
        }

        /// <summary>
        /// Сдвинуть шарик
        /// </summary>
        public void Move()
        {
            X += MoveVector.X;
            Y += MoveVector.Y;
            Shape.Position = new Vector2f(X, Y);
        }

        public float PredictMoveX()
        {
            return X + MoveVector.X;
        }

        public float PredictMoveY()
        {
            return Y + MoveVector.Y;
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

        public Rectangle GetBorder()
        {
            return new Rectangle((int)X, (int)Y, (int)10, (int)10);
        }
    }
}

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
    /// Описание ракетки
    /// </summary>
    class Racket : Drawable
    {
        public uint X;
        public uint Y;
        public uint Height;
        private uint Width = 10;
        private RectangleShape Shape;
        public float PositionX => X;
        public float PositionY => Y;
        public float Step;
        public bool IsUp;
        public bool IsDown;

        public Racket(uint x, uint height)
        {
            Height = height;

            X = x;
            Y = Constants.WindowHeight / 2 - Height / 2;

            Shape = new RectangleShape(new Vector2f(Width, Height));
            Shape.FillColor = Color.White;
            Shape.Position = new Vector2f(X, Y);

            Step = 45 / (float)Height;
        }

        public void MoveUp()
        {
            if (Y - 1 > 10)
            {
                Y -= 1;
                Shape.Position = new Vector2f(X, Y);
            }
        }

        public void MoveDown()
        {
            if (Y - 1 < Constants.WindowHeight - 10 - Height)
            {
                Y += 1;
                Shape.Position = new Vector2f(X, Y);
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            Shape.Draw(target, states);
        }

        public Rectangle GetBorder()
        {
            return new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
        }

        public float GetAngle(float y)
        {
            var shift = Y + Height / 2 - y;

            return Step * shift;
        }
    }
}

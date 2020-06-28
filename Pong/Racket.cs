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

        public Racket(uint x, uint height)
        {
            Height = height;

            X = x;
            Y = Constants.WindowHeight / 2 - Height / 2 - 20;

            Shape = new RectangleShape(new Vector2f(Width, Height));
            Shape.FillColor = Color.White;
            Shape.Position = new Vector2f(X, Y);

            Step = 45 / (float)Height;
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

            Console.WriteLine(shift);

            return Step * shift;
        }
    }
}

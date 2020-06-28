using System;
using SFML.Graphics;
using SFML.System;

namespace Core
{
    class Racket: Drawable, IDebuggable, IMovable
    {
        public readonly Color RacketColor;
        public float X;
        public float Y;
        public readonly RectangleShape BackRect;
        public Vector2f moveVector;
        public int height = 50;
        public int width = 10;
        public float step;

        public Racket(int position)
        {
            X = position;
            Y = Dimensions.WindowHeight / 2 - height / 2;

            moveVector = new Vector2f(0, 0.25f);

            BackRect = new RectangleShape(new Vector2f(width, height));
            RacketColor = Color.White;
            BackRect.FillColor = RacketColor;
            BackRect.Position = new Vector2f(X, Y);

            step = 45 / (height / 2);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            BackRect.Draw(target, states);
        }

        public void MoveUp()
        {
            if ((BackRect.Position.Y > 10))
                Y -= moveVector.Y;

            BackRect.Position = new Vector2f(X, Y);
        }

        public void MoveDown()
        {
            if (((BackRect.Position.Y < Dimensions.WindowHeight - 10 - height) && (BackRect.Position.Y > 0)))
                Y += moveVector.Y;

            BackRect.Position = new Vector2f(X, Y);
        }

        public string GetDebugDisplayInfo()
        {
            return "Racket \n\tX: " + X + "\n\tY: " + Y;
        }

        public int GetDebugDisplayInfoLinesCount()
        {
            return 3;
        }
    }

    public interface IMovable
    {
        void MoveUp();
        void MoveDown();
    }
}

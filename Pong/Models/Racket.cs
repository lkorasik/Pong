using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Pong.Models
{
    class Racket: Drawable, IMovable
    {
        private float X;
        private float Y;
        private int Width;
        private int Height;
        private RectangleShape RacketView;
        private float dx;
        private float dy;
        private RacketTypes Type;

        /// <summary>
        /// Create racket
        /// </summary>
        public Racket(RacketTypes type)
        {
            Width = 10;
            Height = 50;

            if (type == RacketTypes.LEFT)
                X = Constants.LeftRacketPositionX;
            else
                X = Constants.RighrRacketPositionX;
            Y = Constants.WindowHeight / 2 - Height / 2;

            RacketView = new RectangleShape(new Vector2f(Width, Height));
            RacketView.FillColor = SFML.Graphics.Color.White;
            RacketView.Position = new Vector2f(X, Y);
        }

        /// <summary>
        /// Print position
        /// </summary>
        public void DebugPrintPosition()
        {
            if(Type == RacketTypes.LEFT)
                Console.WriteLine("Left X: {0}, Y: {1}", X, Y);
            else
                Console.WriteLine("Right X: {0}, Y: {1}", X, Y);
        }

        /// <summary>
        /// Call it when you want to update racket
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            RacketView.Draw(target, states);
        }

        /// <summary>
        /// Get ball's border
        /// </summary>
        /// <returns>Rectangle</returns>
        public RectangleF GetBorder()
        {
            return new RectangleF(X, Y, Width, Height);
        }

        /// <summary>
        /// Left Down corner
        /// </summary>
        /// <returns>PointF</returns>
        public PointF GetDownLeftPoint()
        {
            return new PointF(X, Y + Height);
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
        /// Get horizontal shift
        /// </summary>
        /// <returns>Shift</returns>
        public float GetDx()
        {
            return dx;
        }

        /// <summary>
        /// Get vertical shift
        /// </summary>
        /// <returns>Shift</returns>
        public float GetDy()
        {
            return dy;
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
        /// Up Right corner
        /// </summary>
        /// <returns>PointF</returns>
        public PointF GetUpRightPoint()
        {
            return new PointF(X + Width, Y);
        }

        /// <summary>
        /// Move racket
        /// </summary>
        /// <param name="dx">steps on axis x</param>
        /// <param name="dy">steps on axis y</param>
        public void Move(float dx, float dy)
        {
            X += dx;
            Y += dy;
            RacketView.Position = new Vector2f(X, Y);
        }

        /// <summary>
        /// Set horizontal shift
        /// </summary>
        /// <param name="dx">Shift</param>
        public void SetDx(float dx)
        {
            this.dx = dx;
        }

        /// <summary>
        /// Set vertical shift
        /// </summary>
        /// <param name="dy">Shift</param>
        public void SetDy(float dy)
        {
            this.dy = dy;
        }
    }

    enum RacketTypes
    {
        LEFT, 
        RIGHT
    }
}

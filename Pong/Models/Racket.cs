using SFML.Graphics;
using SFML.System;
using System;
using System.Drawing;

namespace Pong.Models
{
    class Racket: Drawable, IMovable, IControlMovable
    {
        private float X;
        private float Y;
        private int Width;
        private int Height;
        private RectangleShape RacketView;
        private PositionTypes Type;
        private RacketMovements Movement;

        /// <summary>
        /// Create racket
        /// </summary>
        public Racket(PositionTypes type)
        {
            Width = 10;
            Height = 50;

            if (type == PositionTypes.LEFT)
                X = Constants.LeftRacketPositionX;
            else
                X = Constants.RightRacketPositionX;
            Y = Constants.WindowHeight / 2 - Height / 2;

            RacketView = new RectangleShape(new Vector2f(Width, Height));
            RacketView.FillColor = SFML.Graphics.Color.White;
            RacketView.Position = new Vector2f(X, Y);

            Type = type;

            Movement = RacketMovements.STOP;
        }

        /// <summary>
        /// Print position
        /// </summary>
        public void DebugPrintPosition()
        {
            if(Type == PositionTypes.LEFT)
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

        public float GetDirection()
        {
            throw new NotImplementedException();
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
        /// Get the state of movement
        /// </summary>
        /// <returns></returns>
        public RacketMovements GetMovement()
        {
            return Movement;
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
        [Obsolete]
        public void Move(float dx, float dy)
        {
            //X += dx;
            if((Y + dy > 10) && (Y + dy < Constants.WindowHeight - 10 - Height))
                Y += dy;
            RacketView.Position = new Vector2f(X, Y);
        }

        /// <summary>
        /// Move racket
        /// </summary>
        public void Move()
        {

        }

        public void SetDirection(float angle)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set move state
        /// </summary>
        /// <param name="movement">Move State</param>
        public void SetMovement(RacketMovements movement)
        {
            Movement = movement;
        }
    }
    
    /// <summary>
    /// Use it when you want to move rackets
    /// </summary>
    enum RacketMovements
    {
        UP,
        STOP,
        DOWN
    }
}

using SFML.Graphics;
using SFML.System;
using System;
using System.Drawing;

namespace Pong.Models
{
    /// <summary>
    /// The Rectangle that beats the ball
    /// </summary>
    class Racket: Drawable, IMovable, IControlMovable
    {
        private float X;
        private float Y;
        private int Width;
        private int Height;
        private RectangleShape RacketView;
        private PositionTypes Type;
        private RacketMovements Movement;
        private float StartX;
        private float StartY;
        private Texture RacketTexture;

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

            StartX = X;
            StartY = Y;

            RacketView = new RectangleShape(new Vector2f(Width, Height));
            RacketView.Position = new Vector2f(X, Y);
            RacketTexture = new Texture(Constants.FullPathToBallBack);
            RacketView.Texture = RacketTexture;

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
        /// Move racket
        /// </summary>
        /// <param name="dx">steps on axis x</param>
        /// <param name="dy">steps on axis y</param>
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

        /// <summary>
        /// Set move state
        /// </summary>
        /// <param name="movement">Move State</param>
        public void SetMovement(RacketMovements movement)
        {
            Movement = movement;
        }

        /// <summary>
        /// Return racket to center
        /// </summary>
        public void ResetPosition()
        {
            X = StartX;
            Y = StartY;
            RacketView.Position = new Vector2f(X, Y);
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

using System;
using System.Security.Principal;
using System.Timers;
using SFML;
using SFML.Graphics;
using SFML.System;

namespace Core
{
    public class Game
    {
        //Main logic
        private readonly Field field;
        private readonly Ball ball;
        private readonly Racket leftRacket;
        private readonly Racket rightRacket;
        private readonly Counter leftCounter;
        private readonly Counter rightCounter;
        private readonly Grid Grid;

        public Drawable Field => field;
        public Drawable Ball => ball;
        public IDebuggable BallDebug => ball;
        public Drawable LeftRacket => leftRacket;
        public IDebuggable LeftRacketDebug => leftRacket;
        public IMovable LeftRacketMove => leftRacket;
        public Drawable RightRacket => rightRacket;
        public IDebuggable RightRacketDebug => rightRacket;
        public IMovable RightRacketMove => rightRacket;
        private int t = 0;

        /// <summary>
        /// Create and start game
        /// </summary>
        public Game()
        {
            field = new Field();
            ball = new Ball();
            leftRacket = new Racket(10);
            rightRacket = new Racket(580);
            leftCounter = new Counter();
            rightCounter = new Counter();
            Grid = new Grid();

            StartGame();
        }

        public void StartGame()
        {
            var ballTimer = new Timer(50);
            ballTimer.Start();
            ballTimer.Elapsed += ball.Move;
            ballTimer.Elapsed += ball.CheckWallCollisions;
            ballTimer.Elapsed += CheckRacketCollisions; 
        }

        public void CheckRacketCollisions(object e, ElapsedEventArgs args)
        {
            //0) вычислить шаг: 45/height
            //1) понять попали мы в плащдку или нет
            //2) если попали понять координату попадания
            //3) на основе координаты понять угол
            //4) пересчитать вектор движения

            //Нужен физический движок

            if(t != 0)
            {
                t = 0;
                return;
            }
            else
            {
                t++;
            }

            var ballCenterY = ball.Y + ball.radius;
            var ballCenterX = ball.X + ball.radius;
            var racketCenterY = rightRacket.Y + rightRacket.height / 2;

            var dy = ballCenterY - racketCenterY;

            ball.direction = dy * rightRacket.step;

            if((rightRacket.X - ballCenterX <= ball.radius) && (ballCenterY >= rightRacket.Y) && (ball.Y <= rightRacket.Y + rightRacket.height))
            {
                ball.RecalcDirection();
                ball.moveVector.X *= -1;
                Console.WriteLine("Connect right");
            }

            racketCenterY = leftRacket.Y + leftRacket.height / 2;

            dy = ballCenterY - racketCenterY;

            ball.direction = dy * rightRacket.step;

            if ((ball.X - leftRacket.X <= ball.radius) && (ball.Y >= leftRacket.Y - ball.radius) && (ball.Y <= leftRacket.Y + leftRacket.height))
            {
                ball.RecalcDirection();
                ball.moveVector.X *= -1;
                Console.WriteLine("Connect left");
            }
        }
    }

    class Counter
    {
        public readonly Color CounterColor;

        public Counter()
        {
            CounterColor = Color.White;
        }
    }

    class Grid
    {
        public readonly Color GridColor;
        public uint X;
        public uint Height;

        public Grid()
        {
            X = Dimensions.WindowWidth / 2;
            Height = Dimensions.WindowHeight;

            GridColor = Color.White;
        }
    }
}

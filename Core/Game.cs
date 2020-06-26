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

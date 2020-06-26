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
        private readonly Racket LeftRacket;
        private readonly Racket RightRacket;
        private readonly Counter LeftCounter;
        private readonly Counter RightCounter;
        private readonly Grid Grid;

        public Drawable Field => field;
        public Drawable Ball => ball;

        /// <summary>
        /// Create and start game
        /// </summary>
        public Game()
        {
            field = new Field();
            ball = new Ball();
            LeftRacket = new Racket();
            RightRacket = new Racket();
            LeftCounter = new Counter();
            RightCounter = new Counter();
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

    class Racket
    {
        public readonly Color RacketColor;

        public Racket()
        {
            RacketColor = Color.White;
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

using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    /// <summary>
    /// Сама игра
    /// </summary>
    class Game
    {
        private readonly Ball Ball;
        private readonly Racket LeftRacket;
        private readonly Racket RightRacket;
        private readonly Counter LeftCounter;
        private readonly Counter RightCounter;
        private readonly PhysicEngine PhysicEngine;

        public Game(Action<Drawable> AddDrawableElement)
        {
            Ball = new Ball();
            LeftRacket = new Racket(10, 50);
            RightRacket = new Racket(580, 50);
            LeftCounter = new Counter();
            RightCounter = new Counter();
            PhysicEngine = new PhysicEngine(Ball);

            AddDrawableElement(Ball);
            AddDrawableElement(LeftRacket);
            AddDrawableElement(RightRacket);

            PhysicEngine.StartCalcs();
        }
    }
}

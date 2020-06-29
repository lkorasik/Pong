using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            PhysicEngine = new PhysicEngine(Ball, RightRacket, LeftRacket);

            AddDrawableElement(Ball);
            AddDrawableElement(LeftRacket);
            AddDrawableElement(RightRacket);

            PhysicEngine.StartCalcs();
        }

        private void KeyPressListner(object sender, KeyEventArgs args)
        {
            if (args.Code == Keyboard.Key.S)
                LeftRacket.MoveDown();
            if (args.Code == Keyboard.Key.W)
                LeftRacket.MoveUp();
            if (args.Code == Keyboard.Key.Down)
                RightRacket.IsDown = true;
            if (args.Code == Keyboard.Key.Up)
                RightRacket.IsUp = true;
        }

        private void KeyReleaseListner(object sender, KeyEventArgs args)
        {
            if (args.Code == Keyboard.Key.S)
                LeftRacket.IsDown = false;
            if (args.Code == Keyboard.Key.W)
                LeftRacket.IsUp = false;
            if (args.Code == Keyboard.Key.Down)
                RightRacket.IsDown = false;
            if (args.Code == Keyboard.Key.Up)
                RightRacket.IsUp = false;
        }
    }
}

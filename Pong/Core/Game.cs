using Pong.Input;
using Pong.Logic;
using Pong.Models;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Core
{
    class Game
    {
        private readonly Ball Ball;
        private readonly Racket LeftRacket;
        private readonly Racket RightRacket;
        private readonly PhysicsEngine PhysicsEngine;
        private readonly KeyboardState KeyboardState;
        private GameStats GameStat;

        public Ball GetBall => Ball;
        public Racket GetLeftRacket => LeftRacket;
        public Racket GetRightRacket => RightRacket;
        public PhysicsEngine GetPhysicsEngine => PhysicsEngine;
        public KeyboardState GetKeyboardState => KeyboardState;
        public GameStats GetGameStat => GameStat;

        /// <summary>
        /// Create game
        /// </summary>
        /// <param name="keyboardState">Keyboard</param>
        public Game(KeyboardState keyboardState)
        {
            Ball = new Ball();
            LeftRacket = new Racket(RacketTypes.LEFT);
            RightRacket = new Racket(RacketTypes.RIGHT);
            KeyboardState = keyboardState;

            GameStat = GameStats.PAUSE;

            PhysicsEngine = new PhysicsEngine(Ball, LeftRacket, RightRacket, KeyboardState);
        }

        /// <summary>
        /// Get list of drawables things
        /// </summary>
        /// <returns>List</returns>
        public List<Drawable> GetDrawables()
        {
            return new List<Drawable>() { Ball, LeftRacket, RightRacket };
        }

        public void TogglePause()
        {
            if (GameStat == GameStats.PLAY)
                GameStat = GameStats.PAUSE;
            else
                GameStat = GameStats.PLAY;
        }
    }

    enum GameStats
    {
        PLAY, 
        PAUSE
    }
}

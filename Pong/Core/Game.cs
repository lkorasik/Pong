using Pong.Input;
using Pong.Logic;
using Pong.Models;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
        private readonly Counter LeftCounter;
        private readonly Counter RightCounter;
        private GameStats GameStat;
        public event Action End;

        public Ball GetBall => Ball;
        public Racket GetLeftRacket => LeftRacket;
        public Racket GetRightRacket => RightRacket;
        public PhysicsEngine GetPhysicsEngine => PhysicsEngine;
        public KeyboardState GetKeyboardState => KeyboardState;
        public Counter GetLeftCounter => LeftCounter;
        public Counter GetRightCounter => RightCounter;
        public GameStats GetGameStat => GameStat;

        /// <summary>
        /// Create game
        /// </summary>
        /// <param name="keyboardState">Keyboard</param>
        public Game(KeyboardState keyboardState)
        {
            Ball = new Ball();
            LeftRacket = new Racket(PositionTypes.LEFT);
            RightRacket = new Racket(PositionTypes.RIGHT);
            KeyboardState = keyboardState;
            LeftCounter = new Counter(PositionTypes.LEFT);
            RightCounter = new Counter(PositionTypes.RIGHT);

            GameStat = GameStats.PAUSE;

            PhysicsEngine = new PhysicsEngine(Ball, LeftRacket, RightRacket, KeyboardState, Goal);
        }

        /// <summary>
        /// Get list of drawables things
        /// </summary>
        /// <returns>List</returns>
        public List<Drawable> GetDrawables()
        {
            return new List<Drawable>() { Ball, LeftRacket, RightRacket, LeftCounter, RightCounter };
        }

        /// <summary>
        /// toggling between game and pause
        /// </summary>
        public void TogglePause()
        {
            if (GameStat == GameStats.PLAY)
                GameStat = GameStats.PAUSE;
            else
                GameStat = GameStats.PLAY;
        }

        /// <summary>
        /// Call this method when someone get a score point
        /// </summary>
        /// <param name="side">Which gates hit</param>
        public void Goal(PositionTypes side)
        {
            if (side == PositionTypes.LEFT)
                RightCounter.Increase();
            else
                LeftCounter.Increase();
            
            Ball.ResetPosition();
            GameStat = GameStats.PAUSE;
        }
    }
}

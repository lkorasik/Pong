using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models
{
    class Bot
    {
        private readonly Racket racket;

        /// <summary>
        /// Create bot
        /// </summary>
        /// <param name="racket">Give AI racket!</param>
        public Bot(Racket racket)
        {
            this.racket = racket;
        }

        /// <summary>
        /// Calc thraectory for racket
        /// </summary>
        /// <param name="ballDirection"></param>
        public void MakeStep(float ballDirection)
        {
            if (Math.Sin(ballDirection) > 0)
                racket.Move(0, 2);
            if (Math.Sin(ballDirection) < 0)
                racket.Move(0, -2);
        }
    }
}

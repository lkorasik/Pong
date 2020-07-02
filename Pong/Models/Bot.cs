using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models
{
    class Bot
    {
        private readonly Racket racket;

        public Bot(Racket racket)
        {
            this.racket = racket;
        }

        public void MakeStep(float ballDirection)
        {
            if (Math.Sin(ballDirection) > 0)
                racket.Move(0, 1);
            if (Math.Sin(ballDirection) < 0)
                racket.Move(0, -1);
        }
    }
}

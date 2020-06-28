using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Pong
{
    /// <summary>
    /// Описание физики игры. Описание движений всех объектов
    /// </summary>
    class PhysicEngine
    {
        private Ball Ball;
        private Racket LeftRacket;
        private Racket RightRacket;

        public PhysicEngine(Ball Ball, Racket RightRacket, Racket LeftRacket)
        {
            this.Ball = Ball;
            this.LeftRacket = LeftRacket;
            this.RightRacket = RightRacket;
        }

        public void StartCalcs()
        {
            while (true)
            {
                Thread.Sleep(5);

                Ball.Move();

                if (IsIntersected(Ball.GetBorder(), RightRacket.GetBorder()))
                {
                    var rad = RightRacket.GetAngle(Ball.PositionY + 5) * Math.PI / 180;

                    Ball.RecalcMoveVector((float)rad);
                    Ball.MoveVector.X *= -1;
                }

                if(IsIntersected(Ball.GetBorder(), LeftRacket.GetBorder()))
                {
                    Ball.MoveVector.X *= -1;
                    var rad = RightRacket.GetAngle(Ball.PositionY + 5) * Math.PI / 180;

                    Ball.RecalcMoveVector((float)rad);
                }

                if (Ball.PositionY < 1)
                    Ball.MoveVector.Y *= -1;
                if (Constants.WindowHeight - Ball.PositionY - 10 < 1)
                    Ball.MoveVector.Y *= -1;
            }
        }

        private bool IsIntersected(Rectangle first, Rectangle second)
        {
            return first.IntersectsWith(second);
        }
    }
}

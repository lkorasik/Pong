using SFML.Window;
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

                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    LeftRacket.MoveDown();
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                    LeftRacket.MoveUp();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    RightRacket.MoveDown();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    RightRacket.MoveUp();

                Ball.Move();

                if (IsIntersected(Ball.GetBorder(), RightRacket.GetBorder()))
                {
                    var rad = RightRacket.GetAngle(Ball.PositionY + 5) * Math.PI / 180;

                    Ball.RecalcMoveVector((float)rad);
                    if(Ball.MoveVector.X > 0)
                        Ball.MoveVector.X *= -1;
                    Ball.Move();
                    //Console.WriteLine("Right\n Rad: " + rad + "\nVector x: " + Ball.MoveVector.X + "\nVector y: " + Ball.MoveVector.Y + "\n");
                }

                if(IsIntersected(Ball.GetBorder(), LeftRacket.GetBorder()))
                {
                    var rad = RightRacket.GetAngle(Ball.PositionY + 5) * Math.PI / 180;

                    Ball.RecalcMoveVector((float)rad);
                    if(Ball.MoveVector.X < 0)
                        Ball.MoveVector.X *= -1;
                    Ball.Move();
                    //Console.WriteLine("Left\n Rad: " + rad  + "\nVector x: " + Ball.MoveVector.X + "\nVector y: " + Ball.MoveVector.Y + "\n");
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

using Pong.Input;
using Pong.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Logic
{
    class PhysicsEngine
    {
        private readonly Ball Ball;
        private readonly Racket LeftRacket;
        private readonly Racket RightRacket;
        
        /// <summary>
        /// Create physic engine
        /// </summary>
        /// <param name="movables">What you will move</param>
        public PhysicsEngine(Ball ball, Racket left, Racket right)
        {
            Ball = ball;
            LeftRacket = left;
            RightRacket = right;
        }

        /// <summary>
        /// Move everything and check collisions
        /// </summary>
        public void MakeStep()
        {
            if (KeyboardStat.LeftUp)
                LeftRacket.Move(0, -2);
            if (KeyboardStat.LeftDown)
                LeftRacket.Move(0, 2);
            if (KeyboardStat.RightUp)
                RightRacket.Move(0, -2);
            if (KeyboardStat.RightDown)
                RightRacket.Move(0, 2);

            LeftRacket.DebugPrintPosition();
            RightRacket.DebugPrintPosition();
            Ball.DebugPrintPosition();

            CheckCollisionsBallWall(Ball);
            CheckCollisionsBallWithRackets(Ball, LeftRacket, RightRacket);

            Ball.Move(Ball.GetDx(), Ball.GetDy());
        }

        /// <summary>
        /// Collisions between wall and ball
        /// </summary>
        /// <param name="ball">Ball</param>
        private void CheckCollisionsBallWall(IMovable ball)
        {
            var UpLeft = ball.GetUpLeftPoint();
            var DownRight = ball.GetDownRightPoint();

            if (UpLeft.Y <= 0)
                ball.SetDy(ball.GetDy() * -1);
            if (DownRight.Y >= Constants.WindowHeight)
                ball.SetDy(ball.GetDy() * -1);

            if (UpLeft.X <= 0)
                ball.SetDx(ball.GetDx() * -1);
            if (DownRight.X >= Constants.WindowWidth)
                ball.SetDx(ball.GetDx() * -1);
        }

        /// <summary>
        /// Collisions between rackets and ball
        /// </summary>
        /// <param name="obj">Ball</param>
        private void CheckCollisionsBallWithRackets(IMovable ball, IMovable leftRacket, IMovable rightRight)
        {
            var ballUpLeft = ball.GetUpLeftPoint();
            var ballDownRight = ball.GetDownRightPoint();

            var leftUpLeft = LeftRacket.GetUpLeftPoint();
            var leftDownRight = LeftRacket.GetDownRightPoint();

            var rightUpLeft = RightRacket.GetUpLeftPoint();
            var rightDownRight = RightRacket.GetDownRightPoint();

            var leftUpConnect = Math.Abs(leftUpLeft.Y - ballDownRight.Y) < 0.5;
            var leftDownConnect = Math.Abs(leftDownRight.Y - ballUpLeft.Y) < 0.5;
            var leftLeftConnect = Math.Abs(ballDownRight.X - leftUpLeft.X) < 0.5;
            var leftRightConnect = Math.Abs(ballUpLeft.X - leftDownRight.X) < 0.5;

            var inVerticalLeftRange = (leftDownRight.Y > ballUpLeft.Y) && (ballDownRight.Y > leftUpLeft.Y);
            var inHorizontalLeftRange = (leftDownRight.X > ballUpLeft.X) && (ballDownRight.X > leftUpLeft.X);
            
            if (inVerticalLeftRange && (leftLeftConnect || leftRightConnect))
                ball.SetDx(ball.GetDx() * -1);
            if (inHorizontalLeftRange && (leftUpConnect || leftDownConnect))
                ball.SetDy(ball.GetDy() * -1);

            var rightUpConnect = Math.Abs(rightUpLeft.Y - ballDownRight.Y) < 0.5;
            var rightDownConnect = Math.Abs(rightDownRight.Y - ballUpLeft.Y) < 0.5;
            var rightLeftConnect = Math.Abs(ballDownRight.X - rightUpLeft.X) < 0.5;
            var rightRightConnect = Math.Abs(ballUpLeft.X - rightDownRight.X) < 0.5;

            var inVerticalRightRange = (rightDownRight.Y > ballUpLeft.Y) && (ballDownRight.Y > rightUpLeft.Y);
            var inHorizontalRightRange = (rightDownRight.X > ballUpLeft.X) && (ballDownRight.X > rightUpLeft.X);

            if (inVerticalRightRange && (rightLeftConnect || rightRightConnect))
                ball.SetDx(ball.GetDx() * -1);
            if (inHorizontalRightRange && (rightUpConnect || rightDownConnect))
                ball.SetDy(ball.GetDy() * -1);
        }
    }

    enum Movements
    {
        UP,
        NONE,
        DOWN
    }
}

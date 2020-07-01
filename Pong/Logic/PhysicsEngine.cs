using Pong.Input;
using Pong.Models;
using System;

namespace Pong.Logic
{
    class PhysicsEngine
    {
        private readonly IMovable Ball;
        private readonly IControlMovable LeftRacket;
        private readonly IControlMovable RightRacket;
        private readonly IReadable Keyboard;
        
        /// <summary>
        /// Create physic engine
        /// </summary>
        /// <param name="movables">What you will move</param>
        public PhysicsEngine(IMovable ball, IControlMovable left, IControlMovable right, IReadable keyboard)
        {
            Ball = ball;
            LeftRacket = left;
            RightRacket = right;
            Keyboard = keyboard;
        }

        /// <summary>
        /// Move everything and check collisions
        /// </summary>
        public void MakeStep()
        {
            if (Keyboard.GetLeftUp())
                LeftRacket.Move(0, -2);
            if (Keyboard.GetLeftDown())
                LeftRacket.Move(0, 2);
            if (Keyboard.GetRightUp())
                RightRacket.Move(0, -2);
            if (Keyboard.GetRightDown())
                RightRacket.Move(0, 2);

            LeftRacket.DebugPrintPosition();
            RightRacket.DebugPrintPosition();
            Ball.DebugPrintPosition();

            CheckCollisionsBallWall(Ball);
            CheckCollisionsBallWithRackets(Ball);

            Ball.Move();
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
                ball.SetDirection((float)(-ball.GetDirection()));
            if (DownRight.Y >= Constants.WindowHeight)
                ball.SetDirection((float)(-ball.GetDirection()));
            if (UpLeft.X <= 0)
                ball.SetDirection((float)(Math.PI - ball.GetDirection()));
            if (DownRight.X >= Constants.WindowWidth)
                ball.SetDirection((float)(Math.PI - ball.GetDirection()));
        }

        /// <summary>
        /// Collisions between rackets and ball
        /// </summary>
        /// <param name="obj">Ball</param>
        private void CheckCollisionsBallWithRackets(IMovable ball)
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
                ball.SetDirection((float)(Math.PI - ball.GetDirection()));
            if (inHorizontalLeftRange && (leftUpConnect || leftDownConnect))
                ball.SetDirection((float)(-ball.GetDirection()));

            var rightUpConnect = Math.Abs(rightUpLeft.Y - ballDownRight.Y) < 0.5;
            var rightDownConnect = Math.Abs(rightDownRight.Y - ballUpLeft.Y) < 0.5;
            var rightLeftConnect = Math.Abs(ballDownRight.X - rightUpLeft.X) < 0.5;
            var rightRightConnect = Math.Abs(ballUpLeft.X - rightDownRight.X) < 0.5;

            var inVerticalRightRange = (rightDownRight.Y > ballUpLeft.Y) && (ballDownRight.Y > rightUpLeft.Y);
            var inHorizontalRightRange = (rightDownRight.X > ballUpLeft.X) && (ballDownRight.X > rightUpLeft.X);

            if (inVerticalRightRange && (rightLeftConnect || rightRightConnect))
                ball.SetDirection((float)(Math.PI - ball.GetDirection()));
            if (inHorizontalRightRange && (rightUpConnect || rightDownConnect))
                ball.SetDirection((float)(-ball.GetDirection()));
        }
    }
}

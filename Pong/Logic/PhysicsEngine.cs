using Pong.Core;
using Pong.Input;
using Pong.Models;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Pong.Logic
{
    class PhysicsEngine
    {
        private readonly IBall Ball;
        private readonly IControlMovable LeftRacket;
        private readonly IControlMovable RightRacket;
        private readonly IKeyboardReadable Keyboard;
        private readonly Action<PositionTypes> Goal;
        private readonly Func<GameStats> GetGameStat;
        private readonly Bot LeftBot;
        private readonly Bot RightBot;
        
        /// <summary>
        /// Create physic engine
        /// </summary>
        /// <param name="movables">What you will move</param>
        public PhysicsEngine(IBall ball, IControlMovable left, IControlMovable right, IKeyboardReadable keyboard, Action<PositionTypes> goal, Func<GameStats> stat, Bot leftBot, Bot rightBot)
        {
            Ball = ball;
            LeftRacket = left;
            RightRacket = right;
            Keyboard = keyboard;

            LeftBot = leftBot;
            RightBot = rightBot;

            Goal = goal;
            GetGameStat = stat;
        }

        /// <summary>
        /// Move everything and check collisions
        /// </summary>
        public void MakeStep()
        {
            if (GetGameStat() == GameStats.PLAY_PLAYER_PLAYER)
            {
                if (Keyboard.GetLeftUp())
                    LeftRacket.Move(0, -2);
                if (Keyboard.GetLeftDown())
                    LeftRacket.Move(0, 2);
                if (Keyboard.GetRightUp())
                    RightRacket.Move(0, -2);
                if (Keyboard.GetRightDown())
                    RightRacket.Move(0, 2);
            }
            if(GetGameStat() == GameStats.PLAY_PLAYER_PC)
            {
                LeftBot.MakeStep(Ball.GetDirection());
                if (Keyboard.GetRightUp())
                    RightRacket.Move(0, -2);
                if (Keyboard.GetRightDown())
                    RightRacket.Move(0, 2);
            }
            if (GetGameStat() == GameStats.MENU)
            {
                LeftBot.MakeStep(Ball.GetDirection());
                RightBot.MakeStep(Ball.GetDirection());
            }

            CheckCollisionsBallWall(Ball);
            CheckCollisionsBallWithRackets(Ball);

            Ball.Move();
        }

        /// <summary>
        /// Collisions between wall and ball
        /// </summary>
        /// <param name="ball">Ball</param>
        private void CheckCollisionsBallWall(IBall ball)
        {
            var UpLeft = ball.GetUpLeftPoint();
            var DownRight = ball.GetDownRightPoint();

            if (UpLeft.Y <= 0)
                ball.SetDirection((float)(-ball.GetDirection()));
            if (DownRight.Y >= Constants.WindowHeight)
                ball.SetDirection((float)(-ball.GetDirection()));
            if (UpLeft.X <= 0 - Constants.HorizontalExpand)
            {
                Goal(PositionTypes.LEFT);
            }
            if (DownRight.X >= Constants.WindowWidth + Constants.HorizontalExpand)
            {
                Goal(PositionTypes.RIGHT);
            }
        }

        /// <summary>
        /// Collisions between rackets and ball
        /// </summary>
        /// <param name="obj">Ball</param>
        private void CheckCollisionsBallWithRackets(IBall ball)
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
            {
                var racketCenter = RightRacket.GetHeight() / 2 + RightRacket.GetUpLeftPoint().Y;
                var ballCenter = 5 + ball.GetUpLeftPoint().Y;
                var dy = ballCenter - racketCenter;

                var angle = dy * RightRacket.GetStep();

                ball.SetDirection(-(float)(angle + Math.PI));
            }

            if (inHorizontalRightRange && (rightUpConnect || rightDownConnect))
            {
                var racketCenter = RightRacket.GetHeight() / 2 + RightRacket.GetUpLeftPoint().Y;
                var ballCenter = 5 + ball.GetUpLeftPoint().Y;
                var dy = ballCenter - racketCenter;

                var angle = dy * RightRacket.GetStep();

                ball.SetDirection(-(float)(angle - Math.PI));
            }

            if (inVerticalLeftRange && (leftLeftConnect || leftRightConnect))
            {
                var racketCenter = LeftRacket.GetHeight() / 2 + LeftRacket.GetUpLeftPoint().Y;
                var ballCenter = 5 + ball.GetUpLeftPoint().Y;
                var dy = ballCenter - racketCenter;

                var angle = dy * LeftRacket.GetStep();

                ball.SetDirection((float)(angle - 2 * Math.PI));
            }

            if (inHorizontalLeftRange && (leftUpConnect || leftDownConnect))
            {
                var racketCenter = LeftRacket.GetHeight() / 2 + LeftRacket.GetUpLeftPoint().Y;
                var ballCenter = 5 + ball.GetUpLeftPoint().Y;
                var dy = ballCenter - racketCenter;

                var angle = dy * LeftRacket.GetStep();

                ball.SetDirection(-(float)(angle - Math.PI));
            }
        }
    }
}

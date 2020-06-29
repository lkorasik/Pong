using Pong.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Logic
{
    class PhysicsEngine
    {
        private readonly List<IMovable> Movable;

        /// <summary>
        /// Create physic engine
        /// </summary>
        /// <param name="movables">What you will move</param>
        public PhysicsEngine(params IMovable[] movables)
        {
            Movable = new List<IMovable>();

            for (int i = 0; i < movables.Length; i++)
                Movable.Add(movables[i]);
        }

        /// <summary>
        /// Move everything and check collisions
        /// </summary>
        public void MakeStep()
        {
            for (int i = 0; i < Movable.Count; i++)
            {
                var obj = Movable[i];

                obj.DebugPrintPosition();

                CheckCollisionsBallWall(obj);

                obj.Move(obj.GetDx(), obj.GetDy());
            }
        }

        /// <summary>
        /// Collisions between wall and ball
        /// </summary>
        /// <param name="obj">Ball</param>
        private void CheckCollisionsBallWall(IMovable obj)
        {
            var UpLeft = obj.GetUpLeftPoint();
            var DownRight = obj.GetDownRightPoint();

            if (UpLeft.Y <= 0)
                obj.SetDy(obj.GetDy() * -1);
            if (DownRight.Y >= Constants.WindowHeight)
                obj.SetDy(obj.GetDy() * -1);

            if (UpLeft.X <= 0)
                obj.SetDx(obj.GetDx() * -1);
            if (DownRight.X >= Constants.WindowWidth)
                obj.SetDx(obj.GetDx() * -1);
        }
    }
}

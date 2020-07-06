using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models
{
    /// <summary>
    /// Interface for Ball
    /// </summary>
    interface IBall : IMovable
    {
        void SetDirection(float angle);
        float GetDirection();
        float GetSpeed();
    }
}

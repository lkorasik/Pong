using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models
{
    /// <summary>
    /// Use this interface if you want to move object by yourself
    /// </summary>
    interface IControlMovable : IMovable
    {
        void SetMovement(RacketMovements movement);
        RacketMovements GetMovement();
    }
}

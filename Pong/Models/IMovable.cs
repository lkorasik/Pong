﻿using SFML.System;
using System.Drawing;

namespace Pong.Models
{
    /// <summary>
    /// Use this interface if you want to move object by comp
    /// </summary>
    interface IMovable
    {
        void Move();
        void DebugPrintPosition();

        PointF GetUpLeftPoint();
        PointF GetDownRightPoint();
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Pong.Models
{
    /// <summary>
    /// Use this interface if you want to move object by comp
    /// </summary>
    interface IMovable
    {
        void Move(float dx, float dy);
        RectangleF GetBorder();
        void DebugPrintPosition();

        PointF GetUpLeftPoint();
        PointF GetUpRightPoint();
        PointF GetDownLeftPoint();
        PointF GetDownRightPoint();

        void SetDx(float dx);
        void SetDy(float dy);
        float GetDx();
        float GetDy();
    }
}

using System.Drawing;

namespace Pong.Models
{
    /// <summary>
    /// Use this interface if you want to move object by comp
    /// </summary>
    interface IMovable
    {
        void Move();
        RectangleF GetBorder();
        void DebugPrintPosition();

        PointF GetUpLeftPoint();
        PointF GetUpRightPoint();
        PointF GetDownLeftPoint();
        PointF GetDownRightPoint();

        void SetDirection(float angle);
        float GetDirection();
    }
}

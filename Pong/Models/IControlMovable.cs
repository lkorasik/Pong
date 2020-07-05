namespace Pong.Models
{
    /// <summary>
    /// Use this interface if you want to move object by yourself
    /// </summary>
    interface IControlMovable : IMovable
    {
        void Move(float dx, float dy);
        float GetHeight();
        float GetStep();
    }
}

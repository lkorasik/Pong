namespace Pong.Models
{
    /// <summary>
    /// Use this interface if you want to move object by yourself
    /// </summary>
    interface IControlMovable : IMovable
    {
        void Move(float dx, float dy);
        void SetMovement(RacketMovements movement);
        RacketMovements GetMovement();
    }
}

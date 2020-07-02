using System.Net;

namespace Pong.Input
{
    /// <summary>
    /// Save key states
    /// </summary>
    sealed class KeyboardState: IKeyboardReadable, IKeyboardSetable
    {
        private static readonly KeyboardState Instance = new KeyboardState();
        public static KeyboardState GetInstance => Instance;

        private bool IsLeftUp;
        private bool IsLeftDown;
        private bool IsRightUp;
        private bool IsRightDown;
        private bool IsSpace;

        /// <summary>
        /// Use for saving keys states
        /// </summary>
        private KeyboardState()
        {
            IsLeftUp = false;
            IsLeftDown = false;
            IsRightUp = false;
            IsRightDown = false;
            IsSpace = false;
        }

        /// <summary>
        /// Call it when you want to know state key W
        /// </summary>
        /// <returns>True if key pressed</returns>
        public bool GetLeftUp()
        {
            return IsLeftUp;
        }

        /// <summary>
        /// Call it when you want to know state key S
        /// </summary>
        /// <returns>True if key pressed</returns>
        public bool GetLeftDown()
        {
            return IsLeftDown;
        }

        /// <summary>
        /// Call it when you want to know state key UP
        /// </summary>
        /// <returns>True if key pressed</returns>
        public bool GetRightUp()
        {
            return IsRightUp;
        }

        /// <summary>
        /// Call it when you want to know state key DOWN
        /// </summary>
        /// <returns>True if key pressed</returns>
        public bool GetRightDown()
        {
            return IsRightDown;
        }

        /// <summary>
        /// Call it when you press key W
        /// </summary>
        public void EnableLeftUp()
        {
            IsLeftUp = true;
        }

        /// <summary>
        /// Call it when you press key S
        /// </summary>
        public void EnableLeftDown()
        {
            IsLeftDown = true;
        }

        /// <summary>
        /// Call it when you press key UP
        /// </summary>
        public void EnableRightUp()
        {
            IsRightUp = true;
        }

        /// <summary>
        /// Call it when you press key DOWN
        /// </summary>
        public void EnableRightDown()
        {
            IsRightDown = true;
        }

        /// <summary>
        /// Call it when you release key W
        /// </summary>
        public void DisableLeftUp()
        {
            IsLeftUp = false;
        }

        /// <summary>
        /// Call it when you release key S
        /// </summary>
        public void DisableLeftDown()
        {
            IsLeftDown = false;
        }

        /// <summary>
        /// Call it when you release key UP
        /// </summary>
        public void DisableRightUp()
        {
            IsRightUp = false;
        }

        /// <summary>
        /// Call it when you release key DOWN
        /// </summary>
        public void DisableRightDown()
        {
            IsRightDown = false;
        }
    }
}

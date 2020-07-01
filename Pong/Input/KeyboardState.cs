using System.Net;

namespace Pong.Input
{
    /// <summary>
    /// Save key states
    /// </summary>
    sealed class KeyboardState: IReadable, ISetable
    {
        private static readonly KeyboardState Instance = new KeyboardState();
        public static KeyboardState GetInstance => Instance;

        private bool IsLeftUp;
        private bool IsLeftDown;
        private bool IsRightUp;
        private bool IsRightDown;
        private bool IsSpace;

        private KeyboardState()
        {
            IsLeftUp = false;
            IsLeftDown = false;
            IsRightUp = false;
            IsRightDown = false;
            IsSpace = false;
        }

        public bool GetLeftUp()
        {
            return IsLeftUp;
        }

        public bool GetLeftDown()
        {
            return IsLeftDown;
        }

        public bool GetRightUp()
        {
            return IsRightUp;
        }

        public bool GetRightDown()
        {
            return IsRightDown;
        }

        public void EnableLeftUp()
        {
            IsLeftUp = true;
        }

        public void EnableLeftDown()
        {
            IsLeftDown = true;
        }

        public void EnableRightUp()
        {
            IsRightUp = true;
        }

        public void EnableRightDown()
        {
            IsRightDown = true;
        }

        public void DisableLeftUp()
        {
            IsLeftUp = false;
        }

        public void DisableLeftDown()
        {
            IsLeftDown = false;
        }

        public void DisableRightUp()
        {
            IsRightUp = false;
        }

        public void DisableRightDown()
        {
            IsRightDown = false;
        }

        public bool GetSpace()
        {
            return IsSpace;
        }

        public void ToggleSpace()
        {
            IsSpace = !IsSpace;
        }
    }
}

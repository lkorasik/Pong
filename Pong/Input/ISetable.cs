using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Input
{
    interface ISetable
    {
        void EnableLeftUp();
        void EnableLeftDown();
        void EnableRightUp();
        void EnableRightDown();

        void DisableLeftUp();
        void DisableLeftDown();
        void DisableRightUp();
        void DisableRightDown();

        void ToggleSpace();

        bool GetSpace();
    }
}

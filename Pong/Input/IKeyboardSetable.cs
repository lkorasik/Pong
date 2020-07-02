using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Input
{
    interface IKeyboardSetable
    {
        void EnableLeftUp();
        void EnableLeftDown();
        void EnableRightUp();
        void EnableRightDown();

        void DisableLeftUp();
        void DisableLeftDown();
        void DisableRightUp();
        void DisableRightDown();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Input
{
    interface IKeyboardReadable
    {
        bool GetLeftUp();
        bool GetLeftDown();
        bool GetRightUp();
        bool GetRightDown();
    }
}

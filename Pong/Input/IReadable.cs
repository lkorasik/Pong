using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Input
{
    interface IReadable
    {
        bool GetLeftUp();
        bool GetLeftDown();
        bool GetRightUp();
        bool GetRightDown();
        bool GetSpace();
    }
}

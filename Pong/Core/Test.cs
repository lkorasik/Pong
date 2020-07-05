using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using SFMLViewItems;

namespace Pong.Core
{
    class Test
    {
        public Test()
        {
            var VideoMode = new VideoMode(Constants.WindowWidth, Constants.WindowHeight);
            var Window = new RenderWindow(VideoMode, Constants.WindowTitle);

            var bvo = new BaseViewObject(10, 10, 100, 100, 5);

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear(Color.White);
                Window.Draw(bvo);
                Window.Display();
            }
        }
    }
}

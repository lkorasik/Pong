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

            var mb = new MessageBox(10, 10, 430, 100);
            mb.SetColorTopLayer(Color.Red);
            mb.SetColorBottomLayer(Color.Black);
            mb.AddRightButton("Yes", new Font(Constants.FullPathToFont));
            mb.AddLeftButton("No", new Font(Constants.FullPathToFont));
            mb.SetText("Test", new Font(Constants.FullPathToFont));
            mb.SetTextPosition(TextAlign.CENTER);

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear(Color.White);
                Window.Draw(mb);
                Window.Display();
            }
        }
    }
}

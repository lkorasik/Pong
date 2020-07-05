using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using SFMLViewItems;
using SFMLViewItems.Core;

namespace Pong.Core
{
    class Test
    {
        Button bvo1;

        public Test()
        {
            var VideoMode = new VideoMode(Constants.WindowWidth, Constants.WindowHeight);
            var Window = new RenderWindow(VideoMode, Constants.WindowTitle);

            bvo1 = new Button(10, 10, 100, 100, 5, 5);
            bvo1.SetText("Hello", new Font(Constants.FullPathToFont));
            bvo1.SetTextColor(Color.White);
            bvo1.SetTextSize(16);
            bvo1.SetOnClick(() =>
            {
                Console.WriteLine("S");
            }); 
                
            Window.MouseButtonPressed += Press;
            Window.MouseButtonReleased += Release;

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear(Color.White);
                Window.Draw(bvo1);
                Window.Display();
            }
        }

        public void Press(object sender, MouseButtonEventArgs args)
        {
            bvo1.AnimatePress();
            bvo1.Press();
        }

        public void Release(object sender, MouseButtonEventArgs args)
        {
            bvo1.AnimationRelease();
        }
    }
}

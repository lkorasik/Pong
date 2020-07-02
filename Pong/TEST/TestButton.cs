using Microsoft.VisualBasic;
using SFML.Graphics;
using SFML.Window;
using SFMLButton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.TEST
{
    class TestButton
    {
        private VideoMode VideoMode;
        private RenderWindow Window;
        private Button Button;

        public TestButton()
        {
            VideoMode = new VideoMode(Constants.WindowWidth, Constants.WindowHeight);
            Window = new RenderWindow(VideoMode, Constants.WindowTitle);

            Window.MouseButtonPressed += IsMousePressed;
            Window.MouseButtonReleased += IsMouseReleased;

            Button = new Button(20, 20, 200, 50);
            Button.SetColorTopLayer(Color.Red);
            Button.SetColorBottomLayer(Color.Blue);
            Button.AddText("New game", new Font(Constants.FullPathToFontFile));
            Button.SetTextSize(17);
            Button.SetPosition(TextAlign.CENTER);
            Button.SetTextColor(Color.Yellow);

            Draw();
        }

        private void Draw()
        {
            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear(Color.Black);
                Window.Draw(Button);
                Window.Display();
            }
        }

        private void IsMousePressed(object sender, MouseButtonEventArgs args)
        {
            if(Button.IsOverButton(args.X, args.Y))
                Button.Press();
        }

        private void IsMouseReleased(object sender, MouseButtonEventArgs args)
        {
            Button.Release();
        }
    }
}

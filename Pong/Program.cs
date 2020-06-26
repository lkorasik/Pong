using System;
using Core;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace Pong
{
    class Program
    {
        private static RenderWindow Window;
        private static Game Game;

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">args</param>
        static void Main(string[] args)
        {
            Game = new Game();
            Window = new RenderWindow(new VideoMode(Dimensions.WindowWidth, Dimensions.WindowHeight), "Pong", Styles.None);
            Window.Closed += new EventHandler(OnClosed);

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear(Color.White);
                Window.Draw(Game.Field);
                Window.Draw(Game.Ball);
                Window.Display();
            }
        }

        /// <summary>
        /// Call it when you want to close this window
        /// </summary>
        /// <param name="s">Object sender</param>
        /// <param name="a">EventArgs eventArgs</param>
        private static void OnClosed(object s, EventArgs a)
        {
            Window.Close();
        }
    }
}

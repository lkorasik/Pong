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
        private static DebuggerView DebuggerView;
        static bool isPressedLeftUp = false;
        static bool isPressedLeftDown = false;
        static bool isPressedRightUp = false;
        static bool isPressedRightDown = false;

        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args">args</param>
        static void Main(string[] args)
        {
            Game = new Game();
            DebuggerView = new DebuggerView(Game.BallDebug, Game.LeftRacketDebug, Game.RightRacketDebug);

            Window = new RenderWindow(new VideoMode(Dimensions.WindowWidth, Dimensions.WindowHeight), "Pong");
            Window.Closed += OnClosed;
            Window.KeyPressed += OnKeyPressed;
            Window.KeyReleased += OnKeyReleased;

            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                Window.Clear(Color.White);
                Window.Draw(Game.Field);
                Window.Draw(Game.Ball);
                Window.Draw(Game.LeftRacket);
                Window.Draw(Game.RightRacket);
                Window.Draw(DebuggerView);
                Window.Display();

                if (isPressedLeftDown) Game.LeftRacketMove.MoveDown();
                if (isPressedLeftUp) Game.LeftRacketMove.MoveUp();
                if (isPressedRightDown) Game.RightRacketMove.MoveDown();
                if (isPressedRightUp) Game.RightRacketMove.MoveUp();

                Console.WriteLine("LD: " + isPressedLeftDown + " LU: " + isPressedLeftUp + " RD: " + isPressedRightDown + " RU: " + isPressedRightUp);
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

        private static void OnKeyPressed(object s, KeyEventArgs a)
        {
            if (a.Code == Keyboard.Key.S)
                isPressedLeftDown = true;
            if (a.Code == Keyboard.Key.W)
                isPressedLeftUp = true;
            if (a.Code == Keyboard.Key.Down)
                isPressedRightDown = true;
            if (a.Code == Keyboard.Key.Up)
                isPressedRightUp = true;
        }

        private static void OnKeyReleased(object s, KeyEventArgs a)
        {
            if (a.Code == Keyboard.Key.S)
                isPressedLeftDown = false;
            if (a.Code == Keyboard.Key.W)
                isPressedLeftUp = false;
            if (a.Code == Keyboard.Key.Down)
                isPressedRightDown = false;
            if (a.Code == Keyboard.Key.Up)
                isPressedRightUp = false;
        }
    }
}

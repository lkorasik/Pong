using Pong.Input;
using Pong.Logic;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Pong.Output
{
    /// <summary>
    /// Система отрисовки всего и вся
    /// </summary>
    class Renderer
    {
        private readonly RenderWindow Window;
        private readonly VideoMode VideoMode;
        private readonly List<Drawable> Drawables;
        private readonly PhysicsEngine PhysicEngine;

        /// <summary>
        /// Create window
        /// </summary>
        public Renderer(PhysicsEngine physicEngine, params Drawable[] drawables)
        {
            VideoMode = new VideoMode(Constants.WindowWidth, Constants.WindowHeight);
            Window = new RenderWindow(VideoMode, Constants.WindowTitle);

            Window.Closed += OnClose;
            Window.KeyPressed += OnKeyPressed;
            Window.KeyReleased += OnKeyReleased;

            Drawables = new List<Drawable>();

            for(int i = 0; i < drawables.Length; i++)
            {
                Drawables.Add(drawables[i]);
            }

            PhysicEngine = physicEngine;
        }

        /// <summary>
        /// Call it when you want to close the game
        /// </summary>
        private void OnClose(object sender, EventArgs e)
        {
            Window.Close();
        }

        /// <summary>
        /// Listen keyboard and change states in special class
        /// </summary>
        private void OnKeyPressed(object obj, KeyEventArgs args)
        {
            if (args.Code == Keyboard.Key.S)
                KeyboardStat.LeftDown = true;
            if (args.Code == Keyboard.Key.W)
                KeyboardStat.LeftUp = true;
            if (args.Code == Keyboard.Key.Up)
                KeyboardStat.RightUp = true;
            if (args.Code == Keyboard.Key.Down)
                KeyboardStat.RightDown = true;
        }

        /// <summary>
        /// Listen keyboard and change states in special class
        /// </summary>
        private void OnKeyReleased(object obj, KeyEventArgs args)
        {
            if (args.Code == Keyboard.Key.S)
                KeyboardStat.LeftDown = false;
            if (args.Code == Keyboard.Key.W)
                KeyboardStat.LeftUp = false;
            if (args.Code == Keyboard.Key.Up)
                KeyboardStat.RightUp = false;
            if (args.Code == Keyboard.Key.Down)
                KeyboardStat.RightDown = false;
        }

        /// <summary>
        /// Drawing loop
        /// </summary>
        public void StartDrawing()
        {
            while (Window.IsOpen)
            {
                Thread.Sleep(15);

                PhysicEngine.MakeStep();

                Window.DispatchEvents();
                Window.Clear(Color.Black);
                for(int i = 0; i < Drawables.Count; i++)
                {
                    Window.Draw(Drawables[i]);
                }
                Window.Display();
            }
        }
    }
}

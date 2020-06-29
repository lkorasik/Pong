using Pong.Logic;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
        /// Drawing loop
        /// </summary>
        public void StartDrawing()
        {
            while (Window.IsOpen)
            {
                Thread.Sleep(100);

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

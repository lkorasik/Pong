using Pong.Core;
using Pong.Input;
using Pong.Logic;
using Pong.Models;
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
        private List<Drawable> Drawables;
        private readonly PhysicsEngine PhysicEngine;
        private readonly IKeyboardSetable KeyboardStat;
        private readonly MouseState MouseState;
        private readonly Game Game;

        /// <summary>
        /// Create window
        /// </summary>
        public Renderer(Game game)
        {
            Game = game;

            KeyboardStat = game.GetKeyboardState;
            MouseState = game.GetMouseState;

            VideoMode = new VideoMode(Constants.WindowWidth, Constants.WindowHeight);
            Window = new RenderWindow(VideoMode, Constants.WindowTitle);

            Window.Closed += OnClose;
            Window.KeyPressed += OnKeyPressed;
            Window.KeyReleased += OnKeyReleased;
            Window.MouseButtonPressed += OnMousePressed;
            Window.MouseButtonReleased += OnMouseReleased;

            Drawables = game.GetDrawables();

            PhysicEngine = game.GetPhysicsEngine;
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
                KeyboardStat.EnableLeftDown();
            if (args.Code == Keyboard.Key.W)
                KeyboardStat.EnableLeftUp();
            if (args.Code == Keyboard.Key.Up)
                KeyboardStat.EnableRightUp();
            if (args.Code == Keyboard.Key.Down)
                KeyboardStat.EnableRightDown();
        }

        /// <summary>
        /// Listen keyboard and change states in special class
        /// </summary>
        private void OnKeyReleased(object obj, KeyEventArgs args)
        {
            if (args.Code == Keyboard.Key.Space)
                Game.TogglePause();
            if (args.Code == Keyboard.Key.S)
                KeyboardStat.DisableLeftDown();
            if (args.Code == Keyboard.Key.W)
                KeyboardStat.DisableLeftUp();
            if (args.Code == Keyboard.Key.Up)
                KeyboardStat.DisableRightUp();
            if (args.Code == Keyboard.Key.Down)
                KeyboardStat.DisableRightDown();
        }

        /// <summary>
        /// Listen mouse
        /// </summary>
        private void OnMousePressed(object sender, MouseButtonEventArgs args)
        {
            if (args.Button == Mouse.Button.Left)
                Game.MousePress(args.X, args.Y);
        }

        /// <summary>
        /// Listen mouse
        /// </summary>
        private void OnMouseReleased(object sender, MouseButtonEventArgs args)
        {
            if (args.Button == Mouse.Button.Left)
                Game.MouseRelease(args.X, args.Y);
        }

        /// <summary>
        /// Drawing loop
        /// </summary>
        public void StartDrawing()
        {
            while (Window.IsOpen)
            {
                Thread.Sleep(15);

                if (Game.GetGameStat == GameStats.PLAY_PLAYER_PLAYER || Game.GetGameStat == GameStats.MENU || Game.GetGameStat == GameStats.PLAY_PLAYER_PC)
                {
                    PhysicEngine.MakeStep();
                }
                
                Drawables = Game.GetDrawables();
                    
                Window.DispatchEvents();
                Window.Clear(Color.Black);
                for(int i = 0; i < Drawables.Count; i++)
                {
                    Window.Draw(Drawables[i]);
                }
                Window.Display();
            }
        }

        /// <summary>
        /// Draw frized screen. Use it when game at pause
        /// </summary>
        public void DrawSingleFrame()
        {
            Window.Clear(Color.Black);
            for (int i = 0; i < Drawables.Count; i++)
            {
                Window.Draw(Drawables[i]);
            }
            Window.Display();
        }
    }
}

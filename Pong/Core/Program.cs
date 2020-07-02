using System;
using Pong.Output;
using Pong.Models;
using Pong.Logic;
using Pong.Input;
using Pong.Core;
using System.IO;
using SFML.Graphics;

namespace Pong
{
    /// <summary>
    /// Core. Управляет всеми модулями, связь между модулями
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        static void Main(string[] args)
        {
            var keyboardState = KeyboardState.GetInstance;
            var mouseState = MouseState.GetInstance;

            var game = new Game(keyboardState, mouseState);

            var renderer = new Renderer(game);
            renderer.StartDrawing();
        }
    }
}

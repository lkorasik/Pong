using System;
using Pong.Output;
using Pong.Models;
using Pong.Logic;
using Pong.Input;
using Pong.Core;
using System.IO;

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

            var game = new Game(keyboardState);

            var renderer = new Renderer(game);
            renderer.StartDrawing();
            //renderer.DrawFirstFrame();
        }
    }
}

using Microsoft.VisualBasic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading;
using Pong.Output;
using Pong.Models;
using Pong.Logic;

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
            var ball = new Ball();
            var leftRacket = new Racket(RacketTypes.LEFT);

            var physicEngine = new PhysicsEngine(ball, leftRacket);

            var renderer = new Renderer(physicEngine, ball, leftRacket);
            renderer.StartDrawing();
        }
    }
}

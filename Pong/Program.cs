using Microsoft.VisualBasic;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Threading;

namespace Pong
{
    /// <summary>
    /// Главная точка входа в программу
    /// </summary>
    class Program
    {
        private static Thread GameThread;
        private static bool initedGameObjects = false;
        private static Racket LeftRacket;
        private static Racket RightRacket;

        static void Main(string[] args)
        {
            var graphicEngine = new GraphicEngine();

            /// Через ref поднять ссылки на блоки вверх

            GameThread = new Thread(() => new Game(graphicEngine.AddDrawingElement, ref initedGameObjects, ref LeftRacket, ref RightRacket));
            GameThread.Start();

            while (!initedGameObjects)
            {
                Console.WriteLine("Wait");
            }

            graphicEngine.StartDrawing(ref LeftRacket, ref RightRacket);
        }
    }

    /// <summary>
    /// Описание счетчика
    /// </summary>
    class Counter
    {

    }
}

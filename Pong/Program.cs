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

        static void Main(string[] args)
        {
            var graphicEngine = new GraphicEngine();

            /// Через ref поднять ссылки на блоки вверх

            GameThread = new Thread(() => new Game(graphicEngine.AddDrawingElement));
            GameThread.Start();

            graphicEngine.StartDrawing();
        }
    }

    /// <summary>
    /// Описание счетчика
    /// </summary>
    class Counter
    {

    }
}

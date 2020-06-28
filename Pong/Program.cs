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

            GameThread = new Thread(() => new Game(graphicEngine.AddDrawingElement));
            GameThread.Start();

            graphicEngine.StartDrawing();
        }
    }

    /// <summary>
    /// Описание ракетки
    /// </summary>
    class Racket: Drawable
    {
        private uint X;
        private uint Y;
        private uint Height;
        private uint Width = 10;
        private RectangleShape Shape;

        public Racket(uint x, uint height)
        {
            Height = height;

            X = x;
            Y = Constants.WindowHeight / 2 - Height / 2;

            Shape = new RectangleShape(new Vector2f(Width, Height));
            Shape.FillColor = Color.White;
            Shape.Position = new Vector2f(X, Y);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            Shape.Draw(target, states);
        }
    }

    /// <summary>
    /// Описание счетчика
    /// </summary>
    class Counter
    {

    }

    /// <summary>
    /// Описание физики игры. Описание движений всех объектов
    /// </summary>
    class PhysicEngine
    {
        private Ball Ball;

        public PhysicEngine(Ball Ball)
        {
            this.Ball = Ball;
        }

        public void StartCalcs()
        {
            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine(Ball.PositionX);
                Ball.MoveHorizontal(1);
            }
        }
    }
}

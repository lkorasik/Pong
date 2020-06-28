using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    /// <summary>
    /// Отрисовка графики. Возможно, часть по работе с клавиатурой
    /// </summary>
    class GraphicEngine
    {
        // Само окно, где все рисуется
        private readonly RenderWindow Window;
        // Видео режим, в котором создаем окно
        private readonly VideoMode VideoMode;
        // Список вещей, которые надо отрисовывать, учитывается их порядок
        private readonly List<Drawable> Conveyor;

        private readonly Racket LeftRacket, RightRacket;

        /// <summary>
        /// Создание окна игры
        /// </summary>
        public GraphicEngine()
        {
            VideoMode = new VideoMode(Constants.WindowWidth, Constants.WindowHeight);
            Window = new RenderWindow(VideoMode, "Pong!");
            Conveyor = new List<Drawable>();
        }

        /// <summary>
        /// Начать отрисовку экранов в цикле
        /// </summary>
        public void StartDrawing(ref Racket LeftRacket, ref Racket RightRacket)
        {
            Window.DispatchEvents();

            Console.WriteLine(LeftRacket == null);
            Console.WriteLine(RightRacket == null);

            while (Window.IsOpen)
            {
                Window.Clear();
                for (int i = 0; i < Conveyor.Count; i++)
                {
                    Window.Draw(Conveyor[i]);
                }
                Window.Display();
            }
        }

        /// <summary>
        /// Добавить элемент для отрисовки
        /// </summary>
        /// <param name="element">Что отрисовывать</param>
        public void AddDrawingElement(Drawable element)
        {
            lock (Conveyor)
                Conveyor.Add(element);
        }
    }
}

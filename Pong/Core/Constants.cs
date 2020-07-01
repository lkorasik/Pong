using System;
using System.IO;

namespace Pong
{
    /// <summary>
    /// Все постоянные значения
    /// </summary>
    static class Constants
    {
        public const int WindowWidth = 600;
        public const int WindowHeight = 300;
        public const string WindowTitle = "Pong!";

        public const int HorizontalExpand = 10;

        public const float LeftRacketPositionX = 10;
        public const float RightRacketPositionX = WindowWidth - 20;

        public static string FullPathToFontFile = Path.Combine(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory))), "Resources"), "arial.ttf");
    }
}

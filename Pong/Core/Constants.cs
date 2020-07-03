using System;
using System.Collections.Generic;
using System.Globalization;
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

        public static string FullPathToResources = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory))), "Resources");
        public static string FullPathToFont = Path.Combine(FullPathToResources, "arial.ttf");
        public static string FullPathToBallBack = Path.Combine(FullPathToResources, "BallBackground.png");
        public static string FullPathToBoardBack = Path.Combine(FullPathToResources, "BoardBackground.png");
        public static string FullPathToDark = Path.Combine(FullPathToResources, "DarkBackground.png");
        public static string FullPathToSettings = Path.Combine(FullPathToResources, "Settings.json");

        public static string CurrentLanguage = "Russian";
        public static List<string> AvailablesLanguages = new List<string>() { "Russian", "English" };
    }
}

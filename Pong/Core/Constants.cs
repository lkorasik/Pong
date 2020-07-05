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
        public static string FullPathToEnglishLang = Path.Combine(FullPathToResources, "English.json");
        public static string FullPathToRussianLang = Path.Combine(FullPathToResources, "Russian.json");

        public static string CurrentLanguage = "Русский";
        public static List<string> AvailablesLanguages = new List<string>() { "Русский", "English" };

        public static string EngPlayerPc = "Player vs Pc";
        public static string EngPlayerPlayer = "Player vs Player";
        public static string EngSettings = "Settings";
        public static string EngExit = "Exit";
        public static string EngBack = "Back";

        public static string RusPlayerPc = "Игрок против ПК";
        public static string RusPlayerPlayer = "Игрок против Игрока";
        public static string RusSettings = "Настройки";
        public static string RusExit = "Выход";
        public static string RusBack = "Назад";
    }
}

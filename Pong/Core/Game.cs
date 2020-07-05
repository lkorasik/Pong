using Pong.Input;
using Pong.Logic;
using Pong.Models;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace Pong.Core
{
    class Game
    {
        private readonly Board Board;
        private readonly Ball Ball;
        private readonly Racket LeftRacket;
        private readonly Racket RightRacket;
        private readonly PhysicsEngine PhysicsEngine;
        private readonly KeyboardState KeyboardState;
        private readonly MouseState MouseState;
        private readonly Counter LeftCounter;
        private readonly Counter RightCounter;
        private readonly Bot LeftBot;
        private readonly Bot RightBot;
        private GameStats GameStat;
        private readonly MainMenu MainMenu;
        private readonly Settings Settings;
        private GameStats GameMode;
        public event Action End;

        public Board GetBoard => Board;
        public Ball GetBall => Ball;
        public Racket GetLeftRacket => LeftRacket;
        public Racket GetRightRacket => RightRacket;
        public PhysicsEngine GetPhysicsEngine => PhysicsEngine;
        public KeyboardState GetKeyboardState => KeyboardState;
        public MouseState GetMouseState => MouseState;
        public Counter GetLeftCounter => LeftCounter;
        public Counter GetRightCounter => RightCounter;
        public Bot GetLeftBot => LeftBot;
        public Bot GetRightBot => RightBot;
        public GameStats GetGameStat => GameStat;
        public GameStats GetGameMode => GameMode;
        public MainMenu GetMainMenu => MainMenu;
        public Settings GetSettings => Settings;

        /// <summary>
        /// Create game
        /// </summary>
        /// <param name="keyboardState">Keyboard</param>
        public Game(KeyboardState keyboardState, MouseState mouseState)
        {
            var lang = SettingsWorker.LoadSelectorLanguageModel();
            Languages language;

            switch (lang.CurrentLanguage)
            {
                case "English":
                    language = Languages.ENGLISH;
                    break;
                case "Русский":
                    language = Languages.RUSSIAN;
                    break;
                default:
                    language = Languages.ENGLISH;
                    break;
            }

            var localization = SettingsWorker.LoadGameLanguageModel(language);

            Board = new Board();
            Ball = new Ball();
            LeftRacket = new Racket(PositionTypes.LEFT);
            RightRacket = new Racket(PositionTypes.RIGHT);
            KeyboardState = keyboardState;
            MouseState = mouseState;
            LeftCounter = new Counter(PositionTypes.LEFT);
            RightCounter = new Counter(PositionTypes.RIGHT);
            MainMenu = new MainMenu(localization);
            LeftBot = new Bot(LeftRacket);
            RightBot = new Bot(RightRacket);
            Settings = new Settings(localization);

            GameStat = GameStats.MENU;
            GameMode = GameStats.MENU;

            PhysicsEngine = new PhysicsEngine(Ball, LeftRacket, RightRacket, KeyboardState, Goal, () => GetGameStat, LeftBot, RightBot);
        }

        /// <summary>
        /// Get list of drawables things
        /// </summary>
        /// <returns>List</returns>
        public List<Drawable> GetDrawables()
        {
            if (GameStat == GameStats.MENU)
                return new List<Drawable>() { Board, Ball, LeftRacket, RightRacket, MainMenu };
            if (GameStat == GameStats.SETTINGS)
                return new List<Drawable>() { Board, Ball, LeftRacket, RightRacket, Settings };
            if(GameStat == GameStats.PLAY_PLAYER_PLAYER || GameStat == GameStats.PLAY_PLAYER_PC)
                return new List<Drawable>() { Board, Ball, LeftRacket, RightRacket, LeftCounter, RightCounter };
            if (GameStat == GameStats.PAUSE)
                return new List<Drawable>() { Board, Ball, LeftRacket, RightRacket, LeftCounter, RightCounter };
            return null;
        }

        /// <summary>
        /// Move ball and rockets to start position
        /// </summary>
        public void ResetAllObjects()
        {
            Ball.ResetPosition();
            LeftRacket.ResetPosition();
            RightRacket.ResetPosition();
        }

        /// <summary>
        /// toggling between game and pause
        /// </summary>
        public void TogglePause()
        {
            if ((GameStat == GameStats.PLAY_PLAYER_PC) || (GameStat == GameStats.PLAY_PLAYER_PLAYER))
            {
                GameMode = GameStat;
                GameStat = GameStats.PAUSE;
            }
            else if(GameStat == GameStats.PAUSE)
                GameStat = GameMode;
        }

        /// <summary>
        /// Call it when someone hit the mouse!
        /// </summary>
        /// <param name="x">Mouse position on X-axis</param>
        /// <param name="y">Mouse position on Y-axis</param>
        public void MousePress(float x, float y)
        {
            if (GameStat == GameStats.MENU)
            {
                var button = MainMenu.GetClickedButton(x, y);

                switch (button)
                {
                    case MainMenuButtons.PLAYER_PC:
                        MainMenu.PlayerPcPress();
                        break;
                    case MainMenuButtons.PLAYER_PLAYER:
                        MainMenu.PlayerPlayerPress();
                        break;
                    case MainMenuButtons.SETTINGS:
                        MainMenu.SettingsPress();
                        break;
                    case MainMenuButtons.EXIT:
                        MainMenu.ExitPress();
                        break;
                }
            }
            else if(GameStat == GameStats.SETTINGS)
            {
                var button = Settings.GetClickedButton(x, y);

                switch (button)
                {
                    case SettingsButtons.LANGUAGES:
                        Settings.LanguagePress(x, y);
                        break;
                    case SettingsButtons.BACK:
                        Settings.BackPress();
                        break;
                }
            }
        }

        /// <summary>
        /// Call it when someone release mouse button
        /// </summary>
        public void MouseRelease(float x, float y)
        {
            if (GameStat == GameStats.MENU)
            {
                MainMenu.PlayerPcRelease();
                MainMenu.PlayerPlayerRelease();
                MainMenu.SettingsRelease();
                MainMenu.ExitRelease();

                var button = MainMenu.GetClickedButton(x, y);

                switch (button)
                {
                    case MainMenuButtons.PLAYER_PC:
                        GameStat = GameStats.PLAY_PLAYER_PC;
                        ResetAllObjects();
                        break;
                    case MainMenuButtons.PLAYER_PLAYER:
                        GameStat = GameStats.PLAY_PLAYER_PLAYER;
                        ResetAllObjects();
                        break;
                    case MainMenuButtons.SETTINGS:
                        GameStat = GameStats.SETTINGS;
                        break;
                    case MainMenuButtons.EXIT:
                        Environment.Exit(0);
                        break;
                }
            }
            if(GameStat == GameStats.SETTINGS)
            {
                Settings.LanguageRelease();

                var button = Settings.GetClickedButton(x, y);

                Console.WriteLine("> " + button);
                switch (button)
                {
                    case SettingsButtons.BACK:
                        Settings.BackRelease();
                        break;
                    case SettingsButtons.NO:
                        GameStat = GameStats.MENU;
                        Settings.CloseMessageBox();
                        break;
                    case SettingsButtons.YES:
                        GameStat = GameStats.MENU;
                        Settings.CloseMessageBox();
                        Settings.SaveSettings();
                        break;
                }
            }
        }

        /// <summary>
        /// Call this method when someone get a score point
        /// </summary>
        /// <param name="side">Which gates hit</param>
        public void Goal(PositionTypes side)
        {
            if (GameStat == GameStats.PLAY_PLAYER_PLAYER || GameStat == GameStats.PLAY_PLAYER_PC)
            {
                if (side == PositionTypes.LEFT)
                    RightCounter.Increase();
                else
                    LeftCounter.Increase();

                GameMode = GameStat;
                GameStat = GameStats.PAUSE;
            }
            
            Ball.ResetPosition();
            LeftRacket.ResetPosition();
            RightRacket.ResetPosition();
        }

        /// <summary>
        /// Call it when user want return to main menu
        /// </summary>
        public void ReturnToMainMenu()
        {
            ResetAllObjects();
            GameStat = GameStats.MENU;
        }
    }
}

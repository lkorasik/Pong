using SFML.Graphics;
using SFMLButton;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models
{
    class MainMenu: Drawable
    {
        private readonly List<Drawable> MenuList;
        private readonly Button PlayerPc;
        private readonly Button PlayerPlayer;
        private readonly Button Settings;
        private readonly Button Exit;
        private readonly float MenuHeight;
        private readonly float ButtonWidth = 200;
        private readonly float ButtonHeight = 50;
        private readonly float ButtonSpace = 10;

        /// <summary>
        /// Create main menu
        /// </summary>
        public MainMenu()
        {
            MenuHeight = 4 * ButtonHeight + 3 * ButtonSpace;

            var x = Constants.WindowWidth / 2 - ButtonWidth / 2;
            var y = Constants.WindowHeight / 2 - MenuHeight / 2;

            PlayerPc = new Button(x, y, ButtonWidth, ButtonHeight);
            PlayerPc.SetColorTopLayer(Color.Red);
            PlayerPc.SetColorBottomLayer(Color.Blue);
            PlayerPc.AddText("Player vs PC", new Font(Constants.FullPathToFontFile));
            PlayerPc.SetTextSize(17);
            PlayerPc.SetTextPosition(TextAlign.CENTER);
            PlayerPc.SetTextColor(Color.Yellow);

            y += ButtonHeight + ButtonSpace;
            PlayerPlayer = new Button(x, y, ButtonWidth, ButtonHeight);
            PlayerPlayer.SetColorTopLayer(Color.Red);
            PlayerPlayer.SetColorBottomLayer(Color.Blue);
            PlayerPlayer.AddText("Player vs Player", new Font(Constants.FullPathToFontFile));
            PlayerPlayer.SetTextSize(17);
            PlayerPlayer.SetTextPosition(TextAlign.CENTER);
            PlayerPlayer.SetTextColor(Color.Yellow);

            y += ButtonHeight + ButtonSpace;
            Settings = new Button(x, y, ButtonWidth, ButtonHeight);
            Settings.SetColorTopLayer(Color.Red);
            Settings.SetColorBottomLayer(Color.Blue);
            Settings.AddText("Settings", new Font(Constants.FullPathToFontFile));
            Settings.SetTextSize(17);
            Settings.SetTextPosition(TextAlign.CENTER);
            Settings.SetTextColor(Color.Yellow);

            y += ButtonHeight + ButtonSpace;
            Exit = new Button(x, y, ButtonWidth, ButtonHeight);
            Exit.SetColorTopLayer(Color.Red);
            Exit.SetColorBottomLayer(Color.Blue);
            Exit.AddText("Exit", new Font(Constants.FullPathToFontFile));
            Exit.SetTextSize(17);
            Exit.SetTextPosition(TextAlign.CENTER);
            Exit.SetTextColor(Color.Yellow);

            MenuList = new List<Drawable>() { PlayerPc, PlayerPlayer, Settings, Exit };
        }

        /// <summary>
        /// Draw it!
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            for(int i = 0; i < MenuList.Count; i++)
            {
                MenuList[i].Draw(target, states);
            }
        }

        /// <summary>
        /// Call it when someone hit the mouse
        /// </summary>
        /// <param name="x">mouse position on X-axis</param>
        /// <param name="y">mouse position on Y-axis</param>
        /// <returns>Null if user missed :)</returns>
        public MainMenuButtons? GetClickedButton(float x, float y)
        {
            if (PlayerPc.IsOverButton(x, y))
                return MainMenuButtons.PLAYER_PC;
            if (PlayerPlayer.IsOverButton(x, y))
                return MainMenuButtons.PLAYER_PLAYER;
            if (Settings.IsOverButton(x, y))
                return MainMenuButtons.SETTINGS;
            if (Exit.IsOverButton(x, y))
                return MainMenuButtons.EXIT;
            return null;
        }

        /// <summary>
        /// Player press on button PlayerPc
        /// </summary>
        public void PlayerPcPress() => PlayerPc.Press();
        /// <summary>
        /// Player press on button PcPc
        /// </summary>
        public void PlayerPlayerPress() => PlayerPlayer.Press();
        /// <summary>
        /// Player press on button Settings
        /// </summary>
        public void SettingsPress() => Settings.Press();
        /// <summary>
        /// Player press on button Exit
        /// </summary>
        public void ExitPress() => Exit.Press();

        /// <summary>
        /// Player release button PlayerPc
        /// </summary>
        public void PlayerPcRelease() => PlayerPc.Release();
        /// <summary>
        /// Player release button PcPc
        /// </summary>
        public void PlayerPlayerRelease() => PlayerPlayer.Release();
        /// <summary>
        /// Player release button Settings
        /// </summary>
        public void SettingsRelease() => Settings.Release();
        /// <summary>
        /// Player release button Exit
        /// </summary>
        public void ExitRelease() => Exit.Release();
    }

    /// <summary>
    /// Buttons in menu
    /// </summary>
    enum MainMenuButtons
    {
        PLAYER_PC,
        PLAYER_PLAYER,
        SETTINGS,
        EXIT
    }
}

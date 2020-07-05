using SFML.Graphics;
using SFMLViewItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models
{
    class MainMenu : Drawable
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
        private readonly float ButtonElevation = 5;

        /// <summary>
        /// Create main menu
        /// </summary>
        public MainMenu()
        {
            MenuHeight = 4 * ButtonHeight + 3 * ButtonSpace;

            var x = Constants.WindowWidth / 2 - ButtonWidth / 2;
            var y = Constants.WindowHeight / 2 - MenuHeight / 2;

            PlayerPc = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            PlayerPc.SetColorTopLayer(Color.Red);
            PlayerPc.SetTextureBottomLayer(Constants.FullPathToDark);
            PlayerPc.SetText("Player vs PC", new Font(Constants.FullPathToFont));
            PlayerPc.SetTextSize(17);
            PlayerPc.SetTextColor(Color.Yellow);

            y += ButtonHeight + ButtonSpace;
            PlayerPlayer = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            PlayerPlayer.SetColorTopLayer(Color.Red);
            PlayerPlayer.SetTextureBottomLayer(Constants.FullPathToDark);
            PlayerPlayer.SetText("Player vs Player", new Font(Constants.FullPathToFont));
            PlayerPlayer.SetTextSize(17);
            PlayerPlayer.SetTextColor(Color.Yellow);

            y += ButtonHeight + ButtonSpace;
            Settings = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            Settings.SetColorTopLayer(Color.Red);
            Settings.SetTextureBottomLayer(Constants.FullPathToDark);
            Settings.SetText("Settings", new Font(Constants.FullPathToFont));
            Settings.SetTextSize(17);
            Settings.SetTextColor(Color.Yellow);

            y += ButtonHeight + ButtonSpace;
            Exit = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            Exit.SetColorTopLayer(Color.Red);
            Exit.SetTextureBottomLayer(Constants.FullPathToDark);
            Exit.SetText("Exit", new Font(Constants.FullPathToFont));
            Exit.SetTextSize(17);
            Exit.SetTextColor(Color.Yellow);

            MenuList = new List<Drawable>() { PlayerPc, PlayerPlayer, Settings, Exit };
        }

        /// <summary>
        /// Draw it!
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < MenuList.Count; i++)
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
            if (PlayerPc.IsOverView(x, y))
                return MainMenuButtons.PLAYER_PC;
            if (PlayerPlayer.IsOverView(x, y))
                return MainMenuButtons.PLAYER_PLAYER;
            if (Settings.IsOverView(x, y))
                return MainMenuButtons.SETTINGS;
            if (Exit.IsOverView(x, y))
                return MainMenuButtons.EXIT;
            return null;
        }

        /// <summary>
        /// Player press on button PlayerPc
        /// </summary>
        public void PlayerPcPress() => PlayerPc.AnimatePress();
        /// <summary>
        /// Player press on button PcPc
        /// </summary>
        public void PlayerPlayerPress() => PlayerPlayer.AnimatePress();
        /// <summary>
        /// Player press on button Settings
        /// </summary>
        public void SettingsPress() => Settings.AnimatePress();
        /// <summary>
        /// Player press on button Exit
        /// </summary>
        public void ExitPress() => Exit.AnimatePress();

        /// <summary>
        /// Player release button PlayerPc
        /// </summary>
        public void PlayerPcRelease() => PlayerPc.AnimationRelease();
        /// <summary>
        /// Player release button PcPc
        /// </summary>
        public void PlayerPlayerRelease() => PlayerPlayer.AnimationRelease();
        /// <summary>
        /// Player release button Settings
        /// </summary>
        public void SettingsRelease() => Settings.AnimationRelease();
        /// <summary>
        /// Player release button Exit
        /// </summary>
        public void ExitRelease() => Exit.AnimationRelease();
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

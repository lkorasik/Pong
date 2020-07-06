using SFML.Graphics;
using SFMLView;
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
        public MainMenu(GameLanguageModel localization)
        {
            MenuHeight = 4 * ButtonHeight + 3 * ButtonSpace;

            var x = Constants.WindowWidth / 2 - ButtonWidth / 2;
            var y = Constants.WindowHeight / 2 - MenuHeight / 2;

            PlayerPc = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            InitButton(PlayerPc, localization.PlayerPc);

            y += ButtonHeight + ButtonSpace;
            PlayerPlayer = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            InitButton(PlayerPlayer, localization.PlayerPlayer);

            y += ButtonHeight + ButtonSpace;
            Settings = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            InitButton(Settings, localization.Settings);

            y += ButtonHeight + ButtonSpace;
            Exit = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            InitButton(Exit, localization.Exit);

            MenuList = new List<Drawable>() { PlayerPc, PlayerPlayer, Settings, Exit };
        }

        private void InitButton(Button btn, string text)
        {
            btn.SetColorTopLayer(Color.Red);
            btn.SetTextureBottomLayer(Constants.FullPathToDark);
            btn.SetText(text, new Font(Constants.FullPathToFont));
            btn.SetTextSize(17);
            btn.SetTextColor(Color.Yellow);
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

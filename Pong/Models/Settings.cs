using SFML.Graphics;
using SFMLViewItems;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models
{
    class Settings: Drawable
    {
        private readonly List<Drawable> SettingItems;
        private readonly ButtonList Languages;
        private readonly float MenuHeight;
        private readonly float ButtonWidth = 200;
        private readonly float ButtonHeight = 50;
        private readonly float ButtonSpace = 10;

        /// <summary>
        /// Create main menu
        /// </summary>
        public Settings()
        {
            MenuHeight = 4 * ButtonHeight + 3 * ButtonSpace;

            var x = Constants.WindowWidth / 2 - ButtonWidth / 2;
            var y = Constants.WindowHeight / 2 - MenuHeight / 2;

            Languages = new ButtonList(x, y, ButtonWidth, ButtonHeight, new Font(Constants.FullPathToFont));
            Languages.SetSelected("Lang");
            Languages.AddItem("English");
            Languages.AddItem("Russian");

            SettingItems = new List<Drawable>() { Languages };
        }

        /// <summary>
        /// Call it when someone hit the mouse
        /// </summary>
        /// <param name="x">mouse position on X-axis</param>
        /// <param name="y">mouse position on Y-axis</param>
        /// <returns>Null if user missed :)</returns>
        public SettingsButtons? GetClickedButton(float x, float y)
        {
            //if (Languages.IsOverHeader(x, y))
            if (Languages.IsOverView(x, y))
                return SettingsButtons.LANGUAGES;
            return null;
        }

        /// <summary>
        /// Draw it!
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < SettingItems.Count; i++)
            {
                SettingItems[i].Draw(target, states);
            }
        }

        /// <summary>
        /// Player press on button PlayerPc
        /// </summary>
        public void LanguagePress(float x, float y)
        {
            if (Languages.IsOverHeader(x, y))
                Languages.Toggle();
            else if (Languages.IsOverView(x, y))
                Languages.Press(x, y);
                //Проврека над какой кнопкой произошел клик
        }

        public void LanguageRelease()
        {
            foreach (var i in Languages.Releases)
                i();
        }
    }

    enum SettingsButtons
    {
        LANGUAGES
    }
}

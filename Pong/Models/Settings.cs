﻿using Microsoft.VisualBasic.CompilerServices;
using SFML.Graphics;
using SFMLView;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Pong.Models
{
    class Settings : Drawable
    {
        private readonly List<Drawable> SettingItems;
        private readonly ButtonList Languages;
        private readonly Button Back;
        private readonly Button Save;
        private readonly float MenuHeight;
        private readonly float ButtonWidth = 200;
        private readonly float ButtonHeight = 50;
        private readonly float ButtonSpace = 10;
        private readonly float ButtonElevation = 5;
        private readonly SelectorLanguageModel Language;
        private SettingsStates SettingStat;
        private readonly MessageBox ExitMessageBox;

        /// <summary>
        /// Create main menu
        /// </summary>
        public Settings(GameLanguageModel localization)
        {
            MenuHeight = 4 * ButtonHeight + 3 * ButtonSpace;

            var x = Constants.WindowWidth / 2 - ButtonWidth / 2;
            var y = Constants.WindowHeight / 2 - MenuHeight / 2;

            Language = SettingsWorker.LoadSelectorLanguageModel();

            Languages = new ButtonList(x, y, ButtonWidth, ButtonHeight, new Font(Constants.FullPathToFont));
            Languages.SetSelected(Language.CurrentLanguage);
            foreach (var item in Language.AvailablesLanguages)
                Languages.AddItem(item);

            y += ButtonHeight * 3 + ButtonSpace * 3;
            Back = new Button(x, y, ButtonWidth, ButtonHeight, ButtonElevation, ButtonElevation);
            Back.SetColorTopLayer(Color.Red);
            Back.SetTextureBottomLayer(Constants.FullPathToDark);
            Back.SetText(localization.Back, new Font(Constants.FullPathToFont));
            Back.SetTextSize(17);
            Back.SetTextPosition(TextAlign.CENTER);
            Back.SetTextColor(Color.Yellow);

            SettingStat = SettingsStates.NONE;

            var mbWidth = 500;
            var mbHeight = 110;

            ExitMessageBox = new MessageBox(Constants.WindowWidth / 2 - mbWidth / 2, Constants.WindowHeight / 2 - mbHeight / 2, mbWidth, mbHeight);
            ExitMessageBox.SetColorTopLayer(Color.Red);
            ExitMessageBox.SetColorBottomLayer(Color.Black);
            ExitMessageBox.AddRightButton(localization.Yes, new Font(Constants.FullPathToFont));
            ExitMessageBox.AddLeftButton(localization.No, new Font(Constants.FullPathToFont));
            ExitMessageBox.SetText(localization.Question, new Font(Constants.FullPathToFont));
            ExitMessageBox.SetTextPosition(TextAlign.CENTER);

            SettingItems = new List<Drawable>() { Languages, Back };
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

            if ((SettingStat == SettingsStates.MESSAGE_BOX) && (ExitMessageBox.IsOverLeft(x, y)))
            {
                return SettingsButtons.NO;
            }
            else if ((SettingStat == SettingsStates.MESSAGE_BOX) && (ExitMessageBox.IsOverRight(x, y)))
            {
                return SettingsButtons.YES;
            }

            if (Languages.IsOverView(x, y))
                return SettingsButtons.LANGUAGES;
            if (Back.IsOverView(x, y))
                return SettingsButtons.BACK;

            return null;
        }

        /// <summary>
        /// Draw it!
        /// </summary>
        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < SettingItems.Count; i++)
            {
                if (SettingItems[i] != null)
                    SettingItems[i].Draw(target, states);
                if (SettingStat == SettingsStates.MESSAGE_BOX)
                    ExitMessageBox.Draw(target, states);
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

        /// <summary>
        /// animate Back button
        /// </summary>
        public void BackPress() => Back.AnimatePress();
        /// <summary>
        /// animate Back button
        /// </summary>
        public void BackRelease()
        {
            Back.AnimationRelease();
            SettingStat = SettingsStates.MESSAGE_BOX;
        }

        /// <summary>
        /// Release all buttons in list
        /// </summary>
        public void LanguageRelease()
        {
            foreach (var i in Languages.AnimationReleases)
                i();
        }

        /// <summary>
        /// Save current settings
        /// </summary>
        public void SaveSettings()
        {
            Language.CurrentLanguage = Languages.GetSelected();

            SettingsWorker.SaveSelectorLanguageModel(Language);
        }

        /// <summary>
        /// Call MessageBox
        /// </summary>
        public void CallExitMessageBox()
        {
            SettingStat = SettingsStates.MESSAGE_BOX;
        }

        public void CloseMessageBox()
        {
            SettingStat = SettingsStates.NONE;
        }
    }

    enum SettingsButtons
    {
        LANGUAGES,
        BACK,
        NO,
        YES
    }

    enum SettingsStates
    {
        MESSAGE_BOX,
        NONE
    }
}

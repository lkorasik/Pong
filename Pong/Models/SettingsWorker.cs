using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace Pong.Models
{
    static class SettingsWorker
    {
        static SettingsWorker()
        {
            if (!File.Exists(Constants.FullPathToSettings))
            {
                var model = new SelectorLanguageModel();
                model.CurrentLanguage = Constants.CurrentLanguage;
                model.AvailablesLanguages = Constants.AvailablesLanguages;

                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(Constants.FullPathToSettings, json);
            }
            if (!File.Exists(Constants.FullPathToEnglishLang))
            {
                var model = new GameLanguageModel();
                model.PlayerPc = Constants.EngPlayerPc;
                model.PlayerPlayer = Constants.EngPlayerPlayer;
                model.Settings = Constants.EngSettings;
                model.Exit = Constants.EngExit;
                model.Back = Constants.EngBack;

                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(Constants.FullPathToSettings, json);
            }
            if (!File.Exists(Constants.FullPathToRussianLang))
            {
                var model = new GameLanguageModel();
                model.PlayerPc = Constants.RusPlayerPc;
                model.PlayerPlayer = Constants.RusPlayerPlayer;
                model.Settings = Constants.RusSettings;
                model.Exit = Constants.RusExit;
                model.Back = Constants.RusBack;

                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(Constants.FullPathToSettings, json);
            }
        }

        public static SelectorLanguageModel LoadSelectorLanguageModel()
        {
            var reader = new StreamReader(Constants.FullPathToSettings);
            var json = reader.ReadToEnd();
            reader.Close();

            SelectorLanguageModel languageModel = JsonConvert.DeserializeObject<SelectorLanguageModel>(json);

            return languageModel;
        }

        public static void SaveSelectorLanguageModel(SelectorLanguageModel languageModel)
        {
            File.WriteAllText(Constants.FullPathToSettings, JsonConvert.SerializeObject(languageModel, Formatting.Indented));
        }

        public static GameLanguageModel LoadGameLanguageModel(Languages language)
        {
            if (language == Languages.RUSSIAN)
            {
                var reader = new StreamReader(Constants.FullPathToRussianLang);
                var json = reader.ReadToEnd();
                reader.Close();

                GameLanguageModel gameLanguageModel = JsonConvert.DeserializeObject<GameLanguageModel>(json);

                return gameLanguageModel;
            }
            if (language == Languages.ENGLISH)
            {
                var reader = new StreamReader(Constants.FullPathToEnglishLang);
                var json = reader.ReadToEnd();
                reader.Close();

                GameLanguageModel gameLanguageModel = JsonConvert.DeserializeObject<GameLanguageModel>(json);

                return gameLanguageModel;
            }
            return null;
        }
    }
}

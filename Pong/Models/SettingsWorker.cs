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
        /// <summary>
        /// Work with JSON-files
        /// </summary>
        static SettingsWorker()
        {
            CheckSettingsFile();
            CheckEnglishLangFile();
            CheckRussianLangFile();
        }

        private static void CheckSettingsFile()
        {
            if (!File.Exists(Constants.FullPathToSettings))
            {
                var model = new SelectorLanguageModel();
                model.CurrentLanguage = Constants.CurrentLanguage;
                model.AvailablesLanguages = Constants.AvailablesLanguages;

                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(Constants.FullPathToSettings, json, Encoding.UTF8);
            }
        }

        private static void CheckEnglishLangFile()
        {
            if (!File.Exists(Constants.FullPathToEnglishLang))
            {
                var model = new GameLanguageModel();
                model.PlayerPc = Constants.EngPlayerPc;
                model.PlayerPlayer = Constants.EngPlayerPlayer;
                model.Settings = Constants.EngSettings;
                model.Exit = Constants.EngExit;
                model.Back = Constants.EngBack;

                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(Constants.FullPathToRussianLang, json, Encoding.UTF8);
            }
        }

        private static void CheckRussianLangFile()
        {
            if (!File.Exists(Constants.FullPathToRussianLang))
            {
                var model = new GameLanguageModel();
                model.PlayerPc = Constants.RusPlayerPc;
                model.PlayerPlayer = Constants.RusPlayerPlayer;
                model.Settings = Constants.RusSettings;
                model.Exit = Constants.RusExit;
                model.Back = Constants.RusBack;

                var json = JsonConvert.SerializeObject(model, Formatting.Indented);

                Console.WriteLine(json);
                File.WriteAllText(Constants.FullPathToRussianLang, json, Encoding.UTF8);
            }
        }

        /// <summary>
        /// Load data for selector
        /// </summary>
        /// <returns>LanguageModel</returns>
        public static SelectorLanguageModel LoadSelectorLanguageModel()
        {
            var reader = new StreamReader(Constants.FullPathToSettings, Encoding.UTF8);
            var json = reader.ReadToEnd();
            reader.Close();

            SelectorLanguageModel languageModel = JsonConvert.DeserializeObject<SelectorLanguageModel>(json);

            return languageModel;
        }

        /// <summary>
        /// Save data from selector
        /// </summary>
        /// <param name="languageModel">LanguageModel</param>
        public static void SaveSelectorLanguageModel(SelectorLanguageModel languageModel)
        {
            File.WriteAllText(Constants.FullPathToSettings, JsonConvert.SerializeObject(languageModel, Formatting.Indented), Encoding.UTF8);
        }

        /// <summary>
        /// Load translations
        /// </summary>
        /// <param name="language">What lang do you need?</param>
        /// <returns>GameLanguageModel</returns>
        public static GameLanguageModel LoadGameLanguageModel(Languages language)
        {
            if (language == Languages.RUSSIAN)
            {
                var reader = new StreamReader(Constants.FullPathToRussianLang, Encoding.UTF8);
                var json = reader.ReadToEnd();
                reader.Close();

                GameLanguageModel gameLanguageModel = JsonConvert.DeserializeObject<GameLanguageModel>(json);

                return gameLanguageModel;
            }
            if (language == Languages.ENGLISH)
            {
                var reader = new StreamReader(Constants.FullPathToEnglishLang, Encoding.UTF8);
                var json = reader.ReadToEnd();
                reader.Close();

                GameLanguageModel gameLanguageModel = JsonConvert.DeserializeObject<GameLanguageModel>(json);

                return gameLanguageModel;
            }
            return null;
        }
    }
}

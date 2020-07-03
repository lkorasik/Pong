using System;
using System.Collections.Generic;
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
                var model = new LanguageModel();
                model.CurrentLanguage = Constants.CurrentLanguage;
                model.AvailablesLanguages = Constants.AvailablesLanguages;

                var json = JsonConvert.SerializeObject(model, Formatting.Indented);
                File.WriteAllText(Constants.FullPathToSettings, json);
            }
        }

        public static LanguageModel Load()
        {
            var reader = new StreamReader(Constants.FullPathToSettings);
            var json = reader.ReadToEnd();

            LanguageModel languageModel = JsonConvert.DeserializeObject<LanguageModel>(json);

            return languageModel;
        }

        public static void Save(LanguageModel languageModel)
        {
            File.WriteAllText(Constants.FullPathToSettings, JsonConvert.SerializeObject(languageModel, Formatting.Indented));
        }
    }

    class LanguageModel
    {
        public string CurrentLanguage { get; set; }
        public List<string> AvailablesLanguages { get; set; }
    }
}

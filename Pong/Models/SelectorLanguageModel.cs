using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Models
{
    /// <summary>
    /// Languages in selector
    /// </summary>
    class SelectorLanguageModel
    {
        public string CurrentLanguage { get; set; }
        public List<string> AvailablesLanguages { get; set; }
    }
}

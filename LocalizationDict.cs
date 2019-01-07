using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Subtegral.Localization.Controller
{
    [Serializable]
    public class LocalizationDict
    {
        public string Key;
        public Dictionary<Language, string> Values = new Dictionary<Language, string>();

        public string GetWord(Language languages)
        {
            if (!Values.ContainsKey(languages))
                throw new WordNotFoundException();
            return Values[languages];
        }

        public bool AddWord(Language language, string value)
        {
            if (Values.ContainsKey(language))
                throw new WordNotFoundException();
            Values.Add(language, value);
            return true;
        }

        public void RemoveLanguage(Language lang)
        {
            Values.Remove(lang);
        }
    }
}
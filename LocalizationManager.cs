using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Subtegral.Localization.Controller
{
    public class LocalizationManager : ScriptableObject
    {
        private List<LocalizationDict> localizationDicts = new List<LocalizationDict>();

        public List<Language> localizationLangs = new List<Language>();

        #region Language Methods
        public bool AddLanguage(string name,Sprite icon)
        {
            if (localizationLangs.Exists((x)=>x.Name==name))
                return false;
            localizationLangs.Add(new Language(name,icon));
            return true;
        }
        #endregion

        #region Key Methods
        public void AddNewData(Language lang, string key, string word)
        {
            localizationDicts.Find((x) => x.Key == key).AddWord(lang, word);
        }

        public string[] FetchKeyList()
        {
            return localizationDicts.Select((x => x.Key)).ToArray();
        }
        public Dictionary<Language,string> FetchFromKey(string key)
        {
           return localizationDicts.Find((x) => x.Key == key).Values;
        }
        #endregion
    }
}

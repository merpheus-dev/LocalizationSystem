using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Subtegral.Localization.Controller
{
    public class LocalizationManager : ScriptableObject
    {
        [SerializeField]
        private List<LocalizationDict> localizationDicts = new List<LocalizationDict>();

        [SerializeField]
        private List<bool> keyFoldOutData = new List<bool>();

        public List<Language> localizationLangs = new List<Language>();

        #region Language Methods
        public bool AddLanguage(string name, Sprite icon)
        {
            if (localizationLangs.Exists((x) => x.Name == name))
                return false;
            localizationLangs.Add(new Language(name, icon));
            return true;
        }

        public void RemoveLanguage(int index)
        {
            Language target = localizationLangs[index];
            localizationDicts.ForEach((x) => x.RemoveLanguage(target));
            localizationLangs.RemoveAt(index);
        }

        public bool AddWord(string keyWord)
        {
            if (localizationDicts.Exists((x) => x.Key == keyWord))
                return false;
            localizationDicts.Add(new LocalizationDict()
            {
                Key = keyWord
            });
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

        public bool[] FetchFoldOutList()
        {
            if (keyFoldOutData.Count != localizationDicts.Count)
            {
                keyFoldOutData = new List<bool>();
                for (int i = 0; i < localizationDicts.Count; i++)
                {
                    keyFoldOutData.Add(false);
                }
            }
            return keyFoldOutData.ToArray();
        }

        public void SerializeFoldOutChanges(int index, bool value)
        {
            if (keyFoldOutData.Count - 1 < index)
                FetchFoldOutList();
            keyFoldOutData[index] = value;
        }

        public Dictionary<Language, string> FetchFromKey(string key)
        {
            LocalizationDict dict = localizationDicts.Find((x) => x.Key == key);
            foreach (var perLang in localizationLangs)
            {
                if (!dict.Values.ContainsKey(perLang))
                    dict.AddWord(perLang, string.Empty);
            }
            return dict.Values;
        }
        #endregion
    }
}

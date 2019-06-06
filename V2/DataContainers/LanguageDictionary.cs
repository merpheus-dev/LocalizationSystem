using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
namespace Ana
{
    [Serializable]
    [CreateAssetMenu]
    public class LanguageDictionary : ScriptableObject
    {
        public List<LanguageDict> languageDict = new List<LanguageDict>();


        public void NewLanguage(SystemLanguage identifier, string name, Sprite flag = null)
        {
            var language = new Language { Identifier = identifier, Name = name, Flag = flag };
            CheckLanguageExistance(identifier);
            languageDict.Add(LanguageDict.GetInstanceFromLanguage(language));
        }

        private void CheckLanguageExistance(SystemLanguage language)
        {
            if (languageDict.Exists(x => x.Language.Identifier == language))
                throw new LanguageExistsException();
        }

        public void NewKeyWord(string keyword, string value = null)
        {
            var word = new Word { Key = keyword, Value = value ?? keyword };
            CheckKeyWordExistance(word);
            CheckLanguageListSize();

            foreach (var perDictionary in languageDict)
            {
                perDictionary.NewWord(word);
            }
        }

        public void ChangeKeyWordValue(SystemLanguage language, string keyword, string value)
        {
            var Word = languageDict.SelectMany(x => x.WordList).ToList().Find(x => x.Key == keyword);
            if (Word.Key!=keyword)
                throw new WordNotFoundException();

            Word.Value = value;
        }
        
        private void CheckKeyWordExistance(Word word)
        {
            if (languageDict.Exists(x => x.WordList.Any(y => y.Key == word.Key)))
                throw new WordExistsException();
        }

        private void CheckLanguageListSize()
        {
            if (languageDict.Count == 0)
                throw new LanguageNotExistsException();
        }

        public Language[] GetLanguages()
        {
            return languageDict.Select(x => x.Language).ToArray();
        }

        public string[] GetKeyWords()
        {
            if (languageDict.Count == 0)
                return new string[0];

            return languageDict[0].WordList.Select(x => x.Key).ToArray();
        }

        public string[] GetAllValuesForLanguage(SystemLanguage language)
        {
            if (languageDict.Count == 0)
                return new string[0];
           return languageDict.Find(x => x.Language.Identifier == language).WordList.Select(x => x.Value).ToArray();
        }

    }

    [CustomEditor(typeof(LanguageDictionary))]
    public class LangManEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Languages");
            var tr = target as LanguageDictionary;

            foreach (var s in tr.GetLanguages())
            {
                EditorGUILayout.LabelField(s.Identifier.ToString());

                EditorGUILayout.LabelField("Keywords");
                for(var i = 0; i < tr.GetKeyWords().Length; i++)
                {
                    EditorGUILayout.LabelField(tr.GetKeyWords()[i] +"-"+tr.GetAllValuesForLanguage(s.Identifier)[i]);
                }
            }


        }
    }
}
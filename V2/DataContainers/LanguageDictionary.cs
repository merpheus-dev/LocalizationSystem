using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using SerializableCollections;
namespace Ana
{
    [Serializable]
    [CreateAssetMenu]
    public class LanguageDictionary : ScriptableObject
    {
        public List<LanguageDict> languageDict = new List<LanguageDict>();

        public void AddLangage(string name, SystemLanguage id, Sprite flag)
        {
            TryToGetLanguagePair(id);
            languageDict.Add(new LanguageDict(new Language() { Name = name, Identifier = id, Flag = flag }));
        }

        public void AddWordToLanguage(SystemLanguage languageId, Word word)
        {
            var langPair = TryToGetLanguagePair(languageId);
            langPair.Word.Add(word);
        }

        public LanguageDict TryToGetLanguagePair(SystemLanguage languageId)
        {
            var langPair = languageDict.Find(x => x.Language.Identifier == languageId);
            if (langPair == null)
                throw new LanguageExistsException(false);
            return langPair;
        }

        public List<Word> GetWordsFromLanguage(SystemLanguage language)
        {
            return TryToGetLanguagePair(language).Word;
        }

        public List<Language> GetLanguages()
        {
            return languageDict.Select(x => x.Language).ToList();
        }
    }

    [CustomEditor(typeof(LanguageDictionary))]
    public class LangManEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("Hello");
            var tr = target as LanguageDictionary;
            foreach (var s in tr.GetLanguages())
            {
                EditorGUILayout.LabelField(s.Identifier.ToString());
            }

            foreach (var s in tr.GetWordsFromLanguage(SystemLanguage.Turkish))
            {
                EditorGUILayout.LabelField(s.Key + "|" + s.Value);
            }
        }
    }
}
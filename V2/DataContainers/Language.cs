using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
namespace Ana
{
    [Serializable]
    public struct Language
    {
        public string Name;
        public Sprite Flag;
        public SystemLanguage Identifier;
    }

    [Serializable]
    public struct Word
    {
        public string Key;
        public string Value;
    }

    [Serializable]
    public class LanguageDict
    {
        public Language Language { get; private set; }
        public List<Word> WordList { get; private set; }

        public static LanguageDict GetInstanceFromLanguage(Language language)
        {
            return new LanguageDict(language);
        }

        public void NewWord(Word word)
        {
            WordList.Add(word);
        }

        private LanguageDict(Language language)
        {
            Language = language;
            WordList = new List<Word>();
        }
    }

}
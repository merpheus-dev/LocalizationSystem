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
        public Language Language;
        public List<Word> Word;
        public LanguageDict(Language language)
        {
            Language = language;
            Word = new List<Word>();
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Subtegral.Localization.Controller
{
    [Serializable]
    public class Language
    {
        public string Name;
        public Sprite Icon;
        public Language(string name,Sprite icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
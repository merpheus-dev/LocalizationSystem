using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Subtegral.Localization.Controller;

namespace Subtegral.Localization.EditorScripts
{
    public class AddWordWindow : IDataWindow
    {
        string word;

        public void Draw(LocalizationManager manager)
        {
            word = EditorGUILayout.TextField("Word:", word);

        }
    }
}

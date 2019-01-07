using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Subtegral.Localization.Controller;
namespace Subtegral.Localization.EditorScripts
{
    public class AddLangWindow : IDataWindow
    {
        string name;
        Sprite icon;
        public void Draw(LocalizationManager manager)
        {
            name = EditorGUILayout.TextField("Language:",name);
            icon = (Sprite)EditorGUILayout.ObjectField("Icon:", icon, typeof(Sprite), false);
            if (GUILayout.Button("SAVE"))
            {
               if(!manager.AddLanguage(name,icon))
                {
                    EditorUtility.DisplayDialog("Language Exists", "This language already exists", "OK");
                }
                else
                {
                    EditorUtility.SetDirty(manager);
                }
            }
        }

    }
}

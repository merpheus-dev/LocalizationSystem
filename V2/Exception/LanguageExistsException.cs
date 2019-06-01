using System;
using UnityEngine;
using UnityEditor;
public class LanguageExistsException : Exception
{
    public override string Message => "Language already exists!";
    public LanguageExistsException(bool showPopup = true)
    {
        if (showPopup)
            EditorUtility.DisplayDialog("Error", Message, "OK");
    }

}

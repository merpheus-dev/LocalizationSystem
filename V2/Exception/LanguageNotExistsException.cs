using System;
using UnityEngine;
using UnityEditor;
public class LanguageNotExistsException : Exception
{
    public override string Message => "Language(s) doesn't exist!";
    public LanguageNotExistsException(bool showPopup = true)
    {
        if (showPopup)
            EditorUtility.DisplayDialog("Error", Message, "OK");
    }

}

using System;
using UnityEngine;
using UnityEditor;
public class WordExistsException : Exception
{
    public override string Message => "This keyword already exists!";
    public WordExistsException(bool showPopup = true)
    {
        if (showPopup)
            EditorUtility.DisplayDialog("Error", Message, "OK");
    }

}

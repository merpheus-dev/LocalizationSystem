using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subtegral.Localization.EditorScripts
{
    public static class WindowFactory
    {
        public static IDataWindow CreateWindow(WindowMode mode)
        {
            switch (mode)
            {
                case WindowMode.AddWord:
                    return new AddWordWindow();
                case WindowMode.AddLang:
                    return new AddLangWindow();
            }
            return null;
        }
    }
}
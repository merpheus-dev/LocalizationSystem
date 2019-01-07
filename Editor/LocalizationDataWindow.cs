using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Subtegral.Localization.Controller;
namespace Subtegral.Localization.EditorScripts
{
    public class LocalizationDataWindow : EditorWindow
    {
        private IDataWindow window;

        private LocalizationManager _manager;

        private void OnEnable()
        {
            _manager = Resources.Load<LocalizationManager>("Localization/Manager");
        }

        public void SetWindowMode(WindowMode windowMode)
        {
            window = WindowFactory.CreateWindow(windowMode);
            Repaint();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            window.Draw(_manager);
            EditorGUILayout.EndVertical();
        }
    }
    public enum WindowMode
    {
        AddWord,
        AddLang
    }
}
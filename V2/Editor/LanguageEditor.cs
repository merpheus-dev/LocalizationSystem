using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditorInternal;
using Ana;
using System.Collections.Generic;
public class LanguageEditor : EditorWindow
{
    private ReorderableList list;
    private int selected;
    [MenuItem("Local/Open")]
    public static void CreateWindow()
    {
        var editor = EditorWindow.GetWindow<LanguageEditor>();
    }

    private void OnEnable()
    {
        rootVisualElement.styleSheets.Add(Resources.Load<StyleSheet>("LanguageEditor"));
        var tabView = ViewFactory.GetInstance(View.TabView) as TabView;
        rootVisualElement.Add(tabView);
        rootVisualElement.Add(ViewFactory.GetInstance(View.LanguagePage));
        RegisterTabClicks(tabView);
    }

    private void RegisterTabClicks(TabView tabView)
    {
        tabView.Container.RegisterCallback<MouseUpEvent>(e =>
        {
            selected = selected == 1 ? 0 : 1;
            if (selected == 1)
            {
                rootVisualElement.Remove(ViewFactory.GetInstance(View.LanguagePage));
                rootVisualElement.Add(ViewFactory.GetInstance(View.AddKeywordPage));
            }
            else
            {
                rootVisualElement.Remove(ViewFactory.GetInstance(View.AddKeywordPage));
                rootVisualElement.Add(ViewFactory.GetInstance(View.LanguagePage));
            }
        });
    }

}

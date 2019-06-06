using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditorInternal;
using Ana;
public class LanguageEditor : EditorWindow
{
    private Label header;
    private TextField keywordField;
    private TextField valueField;
    private ReorderableList list;
    private int selected;
    [MenuItem("Local/Open")]
    public static void CreateWindow()
    {
        var editor = EditorWindow.GetWindow<LanguageEditor>();
    }

    private void OnEnable()
    {


        var imguiContainer = new IMGUIContainer(() =>
        {
            EditorGUILayout.Space();
            selected = GUILayout.Toolbar(selected, new string[] { "Language Controls", "Keywords" });
        });
        rootVisualElement.Add(imguiContainer);

        rootVisualElement.Add(ViewFactory.GetInstance(View.LanguagePage));

        imguiContainer.RegisterCallback<MouseUpEvent>(e =>
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
        AttachButtonAction();
    }

    private void AttachButtonAction()
    {
        rootVisualElement.Q<Button>("zaa").RegisterCallback<MouseUpEvent>(e =>
        {
            var lng = Resources.Load<LanguageDictionary>("Lang");
            lng.NewLanguage(SystemLanguage.Turkish, "zaa");
        });

        rootVisualElement.Q<Button>("hello").RegisterCallback<MouseUpEvent>(e =>
        {
            var lng = Resources.Load<LanguageDictionary>("Lang");
            lng.ChangeKeyWordValue(SystemLanguage.Turkish, keywordField.text, valueField.text);
        });

    }
}

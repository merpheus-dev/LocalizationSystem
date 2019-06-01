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
    private ReorderableList list;
    private int selected;

    [MenuItem("Local/Open")]
    public static void CreateWindow()
    {
        var editor = EditorWindow.GetWindow<LanguageEditor>();
    }

    private void OnEnable()
    {
        var visualTree = Resources.Load("LanguageEditorUXML") as VisualTreeAsset;
        var uxmlVE = visualTree.CloneTree();
        uxmlVE.styleSheets.Add(Resources.Load<StyleSheet>("LanguageEditor"));

        var imguiContainer = new IMGUIContainer(() =>
        {
            EditorGUILayout.Space();
            selected = GUILayout.Toolbar(selected, new string[] { "Language Controls", "Key Words" });
        });
        rootVisualElement.Add(imguiContainer);
        rootVisualElement.Add(uxmlVE);

        var lbl = new Label("zaa");

        imguiContainer.RegisterCallback<MouseUpEvent>(e =>
        {
            selected = selected == 1 ? 0 : 1;
            if (selected == 1)
            {
                rootVisualElement.Remove(uxmlVE);
                rootVisualElement.Add(lbl);
            }
            else
            {
                rootVisualElement.Remove(lbl);
                rootVisualElement.Add(uxmlVE);
            }
        });
        AttachButtonAction();
    }

    private void AttachButtonAction()
    {
        rootVisualElement.Q<Button>("zaa").RegisterCallback<MouseUpEvent>(e =>
        {
            var lng = Resources.Load<LanguageDictionary>("Lang");
            lng.AddLangage("zaa", SystemLanguage.Turkish, null);
        });

        rootVisualElement.Q<Button>("hello").RegisterCallback<MouseUpEvent>(e =>
        {
            var lng = Resources.Load<LanguageDictionary>("Lang");
            lng.AddWordToLanguage(SystemLanguage.Turkish, new Word()
            {
                Key = "Anan",
                Value = "Zaa"
            });
        });
    }
}

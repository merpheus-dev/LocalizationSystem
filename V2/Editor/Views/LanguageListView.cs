using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Ana;
using UnityEditor;
public class LanguageListView : BaseView,IContainer
{
    private LanguageDictionary _languageDictionary;

    public override void Construct()
    {
        var label = new Label("Localization")
        {
            name = "header"
        };
        Add(label);

        var button = new Button(()=>
        {
            //fade view
        });
        button.text = "New Language";
    }

    public void Inject(LanguageDictionary data)
    {
        _languageDictionary = data;
    }

    public override void Update()
    {
        ListUpLanguages();
    }

    private void ListUpLanguages()
    {
        if (_languageDictionary == null)
            return;
        var listView = new VisualElement();
        foreach (var language in _languageDictionary.GetLanguages())
        {
            listView.Add(new Label(language.Name));
        }
        Add(listView);
    }
}

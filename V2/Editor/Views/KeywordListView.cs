using System.Collections;
using System.Collections.Generic;
using Ana;
using UnityEngine;
using UnityEngine.UIElements;
public class KeywordListView : BaseView, IContainer
{
    private LanguageDictionary _languageDictionary;
    private TextField key;
    private TextField value;
    private Button button;
    public override void Construct()
    {
        button = new Button()
        {
            text = "Add"
        };

        key = new TextField();
        value = new TextField();

        Add(button);
        Add(key);
        Add(value);

        HandleActions();
    }

    public void Inject(LanguageDictionary data)
    {
        _languageDictionary = data;
    }

    private void HandleActions()
    {
        button.RegisterCallback<MouseUpEvent>(e =>
        {
            _languageDictionary.NewKeyWord(key.text, value.text);
            key.Clear();
            value.Clear();
        });
    }
}

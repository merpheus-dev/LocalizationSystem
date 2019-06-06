using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Linq;
public class ViewFactory
{
    private static Dictionary<View, BaseView> views = new Dictionary<View, BaseView>();
    public static BaseView GetInstance(View view)
    {
        if (views.TryGetValue(view, out BaseView viewPage))
            return viewPage;

        BaseView instance=null;
        switch (view)
        {
            case View.LanguagePage:
                instance = new LanguageListView();
                break;
            case View.AddKeywordPage:
                instance = new KeywordListView();
                break;
        }
        if (instance == null)
            throw new UnknownViewRequestedException();

        views.Add(view, instance);
        return instance;
    }
}

public enum View
{
    LanguagePage,
    AddKeywordPage
}
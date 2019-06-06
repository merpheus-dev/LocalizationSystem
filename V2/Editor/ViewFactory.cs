using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System.Linq;
using Ana;
public class ViewFactory
{
    private static Dictionary<View, BaseView> views = new Dictionary<View, BaseView>();
    private static LanguageDictionary _container;
    static ViewFactory()
    {
        _container = Resources.Load<LanguageDictionary>("Lang");
    }
    public static BaseView GetInstance(View view)
    {
        if (views.TryGetValue(view, out BaseView viewPage))
            return viewPage;

        BaseView instance=null;
        switch (view)
        {
            case View.LanguagePage:
                instance = new LanguageListView();
                (instance as IContainer).Inject(_container);
                break;
            case View.AddKeywordPage:
                instance = new KeywordListView();
                break;
            case View.TabView:
                instance = new TabView();
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
    AddKeywordPage,
    TabView
}
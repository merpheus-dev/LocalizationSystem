using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class LanguageListView : BaseView
{
    public override void Construct()
    {
        var visualTree = Resources.Load("LanguageEditorUXML") as VisualTreeAsset;
        var uxmlVE = visualTree.CloneTree();
        uxmlVE.styleSheets.Add(Resources.Load<StyleSheet>("LanguageEditor"));
        Add(uxmlVE);
    }
}

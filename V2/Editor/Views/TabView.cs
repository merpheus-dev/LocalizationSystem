using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;
using System.Linq;
public class TabView : BaseView
{
    public int ActiveTab { get; private set; } = 0;
    public IMGUIContainer Container { get; private set; }
    public override void Construct()
    {
        Container = new IMGUIContainer(() =>
         {
             EditorGUILayout.Space();
             ActiveTab = GUILayout.Toolbar(ActiveTab, new string[] { "Language Controls", "Keywords" });
         });
        Add(Container);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public abstract class BaseView : VisualElement
{
    protected BaseView()
    {
        Construct();
    }
    public abstract void Construct();
}

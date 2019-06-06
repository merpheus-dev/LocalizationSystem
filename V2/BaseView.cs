using System.Collections;
using System.Collections.Generic;
using Ana;
using UnityEngine;
using UnityEngine.UIElements;
public abstract class BaseView : VisualElement
{
    protected BaseView()
    {
        Construct();
    }
    public abstract void Construct();

    public virtual void Update() { }
}

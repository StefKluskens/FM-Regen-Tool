using UnityEngine;
using UnityEngine.UIElements;

public abstract class UIScreen
{
    public VisualElement Root;

    public UIScreen(VisualElement rootElement)
    {
        Root = rootElement;
    }

    public abstract void Initialize();
}

using UnityEngine;
using UnityEngine.EventSystems;

public static class Extansion
{
    public static void AddUIEvent(this GameObject go, System.Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click)
    {
        UI_Base.AddUIEvent(go, action, type);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 0; // 가장 최근에 사용한 소트오더를 저장할 예정
    Stack<UI_Popup> _popupStack;
    
    public void Init()
    {
        _popupStack = new Stack<UI_Popup>();
    }
    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Util.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;
        if (sort)
            canvas.sortingOrder = _order++;
        else
            canvas.sortingOrder = 0;
        
    }
    public T ShowPopupUI<T>(string name = null) where T : UI_Popup
    {
        if (name == null)
            name = typeof(T).Name;
        GameObject go = Managers.Resource.Instantiate($"UI/Popup/{name}");
        T popup = Util.GetOrAddComponent<T>(go);
        _order++;
        _popupStack.Push(popup);
        return popup;
    }
    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        UI_Popup popup = _popupStack.Pop();
        Managers.Resource.Destroy(popup.gameObject);
        _order--;
    }
}
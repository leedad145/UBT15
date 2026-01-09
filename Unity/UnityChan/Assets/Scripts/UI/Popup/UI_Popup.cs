using UnityEngine;

public class UI_Popup : UI_Base
{
    public override void Init()
    {
        Managers.UI.SetCanvas(gameObject, true);
    }
    public virtual void ClosePopupUI()
    {
        Managers.UI.ClosePopupUI();
    }    
    public void SetSortingOrder(int order)
    {
        Canvas canvas = GetComponent<Canvas>();
        canvas.overrideSorting = true;
        canvas.sortingOrder = order;
    }
}

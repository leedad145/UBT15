using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
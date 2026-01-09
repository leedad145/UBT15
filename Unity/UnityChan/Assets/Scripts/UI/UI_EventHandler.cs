using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_EventHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerClickHandler
{
    public event Action<PointerEventData> OnDragHandler = null;
    public event Action<PointerEventData> OnBeginDragHandler = null;
    public event Action<PointerEventData> OnClickHandler = null;

    public void OnDrag(PointerEventData eventData)
    {
        OnDragHandler?.Invoke(eventData);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragHandler?.Invoke(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickHandler?.Invoke(eventData);
    }
}

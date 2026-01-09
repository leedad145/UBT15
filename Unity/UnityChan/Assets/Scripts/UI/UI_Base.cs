using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class UI_Base : MonoBehaviour
{
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();
    void Awake()
    {
        Init();
    }
    public abstract void Init();
    protected void Bind<T>(Type type) where T : UnityEngine.Object // 컴포넌트를 물고있으려고 만드는거임
    {
        string[] names = Enum.GetNames(type); // enum 이 들고있는 모든 엘리먼트에 대한 이름을 배열로 가져오기

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length]; // 컴퍼넌트들을 저장하기 위한 배열공간 할당
        _objects.Add(typeof(T), objects); // 키 = 타입, 벨류 = 컴퍼넌트가 담겨있는 배열,  현재는 빈공간

        for (int i = 0; i < names.Length; i++)
        {
            if (typeof(T) == typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true); // 어떻게? // 여기에다가 사용할 함수를 Util 이라는 클래스를 만들어서 넣을 예정
        }
    }

    protected T Get<T>(int index) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if (_objects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[index] as T;
    }
    public static void AddUIEvent(GameObject go, Action<PointerEventData> action, Define.UIEvent type = Define.UIEvent.Click )
    {
        UI_EventHandler eventHandler = Util.GetOrAddComponent<UI_EventHandler>(go);

        switch (type)
        {
            case Define.UIEvent.Click:
                eventHandler.OnClickHandler += action;
                break;
            case Define.UIEvent.Drag:
                eventHandler.OnDragHandler += action;
                break;
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    void Awake()
    {
        Init();
    }
    public Define.Scene SceneType
    {
        get;
        protected set;
    } = Define.Scene.UnKnown;
    public virtual void Init()
    {
        Object obj = GameObject.FindFirstObjectByType(typeof(EventSystem));
        if(obj == null)
            Managers.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";

    }
    public virtual void Clear()
    {
        
    }
}

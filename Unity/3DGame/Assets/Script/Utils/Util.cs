using UnityEngine;

public class Util
{
    public static GameObject FindChild(GameObject go, string name = null, bool reculsive = false)
    {
        Transform transform = FindChild<Transform>(go, name, reculsive);
        if(transform != null)
            return transform.gameObject;
        return null;
    }
    public static T FindChild<T>(GameObject go, string name = null, bool reculsive = false) where T : UnityEngine.Object
    {
        if(go == null)
            return null;
        if (reculsive)
        {
            for(int i = 0; i < go.transform.childCount; i++)
            {
                Transform transform = go.transform.GetChild(i);
                if(string.IsNullOrEmpty(name) || transform.name == name)
                {
                    T component = transform.GetComponent<T>();
                    if(component != null)
                        return component;
                }
            }
        }
        else
        {
            foreach(T component in go.GetComponentsInChildren<T>())
            {
                if(string.IsNullOrEmpty(name) || component.name == name)
                {
                    return component;
                }
            }
        }
        return null;
    }
}

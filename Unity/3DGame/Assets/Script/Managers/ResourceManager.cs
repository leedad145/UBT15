using UnityEngine;

public class ResourceManager
{
    public void Init()
    {
        // 초기화 작업이 필요하면 여기에 작성
    }
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");
        if (prefab != null)
        {
            return Object.Instantiate(prefab, parent);
        }
        Debug.LogError($"프리펩({path})이 없습니다.");
        return null;
    }
    public void Destroy(GameObject go, float delay = 0f)
    {
        if(go != null)
            Object.Destroy(go, delay);
    }
}

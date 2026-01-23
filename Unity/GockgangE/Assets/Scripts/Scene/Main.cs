using UnityEngine;
public class Main : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.InitAfterLoad();
    }
}
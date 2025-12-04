using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{
    private void Start()
    { 
        CreatePlayer();
    }

    float sumTime = 0f; // 시간을 누적 시킬 변수
    private void Update()
    {
        sumTime += Time.deltaTime;
        GameObject go = GameObject.Find("Player");
        if(sumTime >= 3.0f)
        {
            go.SetActive(false);
            GameObject.Destroy(go, 2);
        }
    }
    private void CreatePlayer()
    {
        GameObject go = new GameObject();
        Player player =  go.AddComponent<Player>();
    }
}
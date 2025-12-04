using Unity.VisualScripting;
using UnityEngine;

public class Main : MonoBehaviour
{//7개 생성 이름변경 스프라이트렌더러 스프라트드 스퀘어
    public Sprite sprite;
    Color[] colors = {Color.red, Color.orange, Color.yellow,  Color.green, Color.blue, Color.navyBlue, Color.purple};
    private void Start()
    { 
        for (int i = 1;  i <= 7; i++)
        {
            CreateSquare("Square" + i, new Vector3(i - 4, 0, 0), colors[i-1]);

        }
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
    private void CreateSquare(string name, Vector3 pos, Color color)
    { 
        GameObject go = new GameObject();
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.sprite = sprite;
        sr.color = color;
        go.name = name;
        go.transform.position = pos;

    }
}
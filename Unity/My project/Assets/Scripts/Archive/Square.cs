using UnityEngine;

public class Square : MonoBehaviour
{
    public Sprite sprite;
    Color[] colors = { Color.red, Color.orange, Color.yellow, Color.green, Color.blue, Color.navyBlue, Color.purple };

    void Start()
    {
        for (int i = 1; i <= 7; i++)
        {
            CreateSquare("Square" + i, new Vector3(i - 4, 0, 0), colors[i - 1]);
        }
    }

    void Update()
    {
        
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

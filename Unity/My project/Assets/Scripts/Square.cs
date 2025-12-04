using UnityEngine;

public class Square : MonoBehaviour
{   
    void Start()
    {
        GameObject go = gameObject;
        gameObject.name = "";
        gameObject.tag = "Player";
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.color = Color.blue;

        transform.position = new Vector3(2, 0, 0);
    }

    void Update()
    {
        
    }
}

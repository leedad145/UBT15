using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    private int hp  = 100;
    private int damage = 10;
    void Start()
    {
        GameObject go = gameObject;
        gameObject.name = "Player";
        gameObject.tag = "Player";
        SpriteRenderer sr = go.AddComponent<SpriteRenderer>();
        sr.color = Color.blue;

        transform.position = new Vector3(2, 0, 0);
    }

    void Update()
    {
        
    }
}

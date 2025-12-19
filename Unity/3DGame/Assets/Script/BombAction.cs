using UnityEngine;

public class BombAction : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter()
    {
        GameObject bombEffect = Resources.Load<GameObject>("Prefabs/BigExplosionEffect");
        GameObject eff = Instantiate(bombEffect);
        eff.transform.position = transform.position;
        Destroy(gameObject);
    }
    
}

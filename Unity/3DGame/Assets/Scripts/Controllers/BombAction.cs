using UnityEngine;

public class BombAction : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject go = col.gameObject;
        if(go.layer == LayerMask.NameToLayer("Player"))
            return;
        GameObject bombEffect = Resources.Load<GameObject>("Prefabs/BigExplosionEffect");
        GameObject eff = Instantiate(bombEffect);
        eff.transform.position = transform.position;

        if(go.layer == LayerMask.NameToLayer("Monster"))
        {
            Destroy(go);
            Logger.Log("파괴");
        }

        Destroy(gameObject);
    }
    
}

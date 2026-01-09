using TMPro;
using UnityEngine;
public class MonsterController : MonoBehaviour
{
    Stat _stat = new Stat(1, 50, 5, 2, 3f);

    void Start()
    {
        _stat.OnDead += () =>
        {
            Logger.Log($"{gameObject.name} 사망");
            Destroy(gameObject);
        };
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject go = col.gameObject;
        if(go.layer == LayerMask.NameToLayer("Weapon"))
        {
            GameObject player = GameObject.Find("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            _stat.TakeDamage(pc.GetAtkDmg());
        }
    }
}

using TMPro;
using UnityEngine;
public class MonsterController : MonoBehaviour
{
    Stat _stat = new Stat();

    void Start()
    {
        _stat.MaxHp = 30;
        _stat.Hp = 30;
        _stat.Defense = 5;
    }

    void Update()
    {

        if (_stat.IsDead)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        GameObject go = col.gameObject;
        if(go.layer == LayerMask.NameToLayer("Weapon"))
        {
            GameObject player = GameObject.Find("Player");
            PlayerController pc = player.GetComponent<PlayerController>();
            _stat.OnAttacked(pc.Stat);
            Logger.Log($"{gameObject.name}Hp: {_stat.Hp} / {_stat.MaxHp}");
        }
    }
}

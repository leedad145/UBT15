using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    Stat _stat;
    public void Awake()
    {
        _stat = new Stat();
        _stat.OnDead += Dead;
    }
    public void Attack(float power)
    {
        GameObject snowPrefab = Resources.Load<GameObject>("Snow");
        if (snowPrefab != null)
        {
            GameObject snow = Instantiate(snowPrefab);
            Snow snowComponent = snow.GetComponent<Snow>();
            if (snowComponent != null)
            {
                snowComponent.Init(gameObject.layer, power, transform.position);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.layer != other.gameObject.layer)
        {
            gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.1f);
            _stat.Attacked();
        }
    }
    public virtual void Dead()
    {
        Destroy(gameObject);
    }
}

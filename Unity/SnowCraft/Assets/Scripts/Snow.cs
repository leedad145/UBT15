using UnityEngine;

public class Snow : MonoBehaviour
{
    float spd;
    float lifeTime = 2;
    float curTime;
    bool _isAttack = false;
    public void Init(LayerMask layer, float power, Vector3 pos)
    {
        gameObject.layer = layer;
        if(gameObject.layer == LayerMask.NameToLayer("Player"))
            spd = power;
        else if(gameObject.layer == LayerMask.NameToLayer("Enemy"))
            spd = -power;

        curTime = 0;
        transform.position = pos;
    }

    void Update()
    {
        if(!_isAttack)
            MoveSnow();
    }
    void MoveSnow()
    {
        curTime += Time.deltaTime;
        transform.position += Vector3.left * spd * Time.deltaTime * 40f / (1 + curTime * 20);
        if(curTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer != gameObject.layer && other.gameObject.layer != LayerMask.NameToLayer("Default"))
        {
            Debug.Log(other.transform.name);
            _isAttack = true;
            Destroy(gameObject, 0.2f);
            gameObject.layer = LayerMask.NameToLayer("Default");
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}

using UnityEngine;

public class EnemyController : Controller
{
    float _moveSpd = 3f;
    float _atkSpd;
    float _curTime;
    Vector3 _moveDir;
    Vector3 _destPos;
    void Start()
    {
        _destPos = GameObject.Find("Destination").transform.position;
        name = "Enemy";
    }

    void Update()
    {
        _curTime += Time.deltaTime;
        //// 움직임
        transform.position += _moveDir * _moveSpd * Time.deltaTime;
        //// 공격 및 방향 설정
        if(_curTime > _atkSpd)
        {
            Attack(_atkSpd * 0.75f);
            _moveDir = SetDirection();
            _atkSpd = Random.Range(1f,3f);
            _curTime = 0;
        }
    }
    Vector3 SetDirection()
    {
        Vector3 destVector = _destPos - transform.position;
        float x = Random.Range(-1f,1f);
        float y = Random.Range(-1f,1f);
        Vector3 randomVector = new Vector3(x, y, 0);
        return destVector.normalized*0.6f + randomVector.normalized*0.4f; // 가중치
    }
}

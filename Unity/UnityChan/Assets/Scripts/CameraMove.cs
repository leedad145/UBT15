using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    Transform target;
    Vector3 _targetDir;
    float _soomthTime = 0.2f;
    Vector3 _velocity;
    void Start()
    {
        //캐릭터에서 카메라 위치로 향하는 방향 벡터 구하기
        _targetDir = transform.position - target.transform.position;
    }

    void Update()
    {
        Vector3 newPosition = target.transform.position + _targetDir;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref _velocity, _soomthTime);
;
    }
}

using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 _delta;
    GameObject _player;
    void Start()
    {
        _delta = transform.position;
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        //transform.position = _player.transform.position + _delta;
        transform.LookAt(_player.transform);

        if(Physics.Raycast(_player.transform.position, _delta, out RaycastHit hitInfo, _delta.magnitude, LayerMask.GetMask("Wall")))
        {
            float dist = (hitInfo.point - _player.transform.position).magnitude * 0.8f;
            transform.position = _player.transform.position + _delta.normalized * dist;
        }
        else
        {
            transform.position = _player.transform.position + _delta;
        }
    }
}

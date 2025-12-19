using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float _moveSpeed;
    public float _turnSpeed; 
    CharacterController _characterController;
    public float _rayLength = 100f;
    Vector3 direction;
    Vector3 targetPoint;
    [SerializeField]
    GameObject markerPrefab;
    int _layerMask = (1<<8);
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {   

        if (Input.GetMouseButtonDown(0))
        {
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(r, out RaycastHit hitInfo, _rayLength, _layerMask))
            {
                targetPoint = hitInfo.point;

                #region 마커 생성
                GameObject marker = GameObject.Find("@Marker");
                if(marker == null)
                {
                    marker = Instantiate(markerPrefab);
                    marker.name = "@Marker";
                }
                marker.transform.position = targetPoint;
                #endregion 마커 생성

                direction = targetPoint - transform.position;
            }
        }
        if((targetPoint - transform.position).magnitude > 0.1f)
        {
            _characterController.Move(direction.normalized * _moveSpeed * Time.deltaTime);
        }

    }
}

using UnityEngine;

public class CamController : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        follow();
        rotate();
    }

    #region rotate
    public float rotSpeed = 720f;

    float mx = 0;
    float my = 0;
    void rotate()
    {
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90f, 90f);

        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
    #endregion rotate
    #region follow
    public Transform target;

    void follow()
    {
        transform.position = target.position;
    }
    #endregion follow
}

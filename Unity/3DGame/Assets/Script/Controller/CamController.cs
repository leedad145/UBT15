using UnityEngine;

public class CamController : MonoBehaviour
{
    void Start()
    {
        Managers.Input.OnInputKey += zoomIn;
        Managers.Input.OnInputKey += zoomOut;
        Managers.Input.OnInputKey += rotate;
    }
    #region zoom
    void zoomIn(Define.InputEvent input)
    {
        if(input == Define.InputEvent.RPress)
        {
            transform.position = target.position + Vector3.up;
            Camera.main.fieldOfView = 30;
        }
    }
    void zoomOut(Define.InputEvent input)
    {
        if(input == Define.InputEvent.RUp)
            Camera.main.fieldOfView = 60;
    }
    #endregion zoom
    #region rotate
    public float rotSpeed = 720f;
    public Transform target;
    Vector3 _delta = new Vector3(1, 1, -3);
    float mx = 0;
    float my = 0;
    void rotate(Define.InputEvent input)
    {
        if(input == Define.InputEvent.MouseMove)
        {
            float mouse_X = Input.GetAxis("Mouse X");
            float mouse_Y = Input.GetAxis("Mouse Y");

            mx += mouse_X * rotSpeed * Time.deltaTime;
            my += mouse_Y * rotSpeed * Time.deltaTime;

            my = Mathf.Clamp(my, -45f, 45f);
            transform.eulerAngles = new Vector3(-my, mx, 0);

            transform.position = target.position + transform.TransformDirection(_delta);
        }
    }
    #endregion rotate
}
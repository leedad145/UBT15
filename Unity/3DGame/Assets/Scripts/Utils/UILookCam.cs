using UnityEngine;

public class UILookCam : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.LookAt(Camera.main.transform.eulerAngles);
        transform.Rotate(0, 180, 0);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //GameObject prefab;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            Debug.Log("Down");
        }
        if (Input.GetAxis("vertical") != 0)
        {
            Debug.Log("--");
        }
    }
}
using UnityEngine;

public class WeaponAction : MonoBehaviour
{
    public float destroyTime = 0.25f;

    float currentTime = 0f;
    Quaternion targetRotation;
    void Start()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        targetRotation = Quaternion.LookRotation(cameraForward) * Quaternion.Euler(new Vector3(120,0,0));
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 20 * Time.deltaTime);
        if(currentTime > destroyTime)
        {
            Destroy(gameObject);
        }
        currentTime += Time.deltaTime;
    }
}

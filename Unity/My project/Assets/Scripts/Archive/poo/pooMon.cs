using UnityEngine;

public class pooMon : MonoBehaviour
{
    float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(Random.Range(-10, 10), 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        transform.position += new Vector3(0, -moveDistance, 0);
    }
    public bool IsMapOut()
    {
        if (transform.position.y < -10)
        {
            return true;
        }
        return false;
    }
}

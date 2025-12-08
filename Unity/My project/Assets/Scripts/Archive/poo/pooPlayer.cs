using UnityEngine;
public class pooPlayer : MonoBehaviour
{
    public float speed = 15.0f;
    public bool invu;
    float invuTime;
    void Start()
    {
        invu = false;
        invuTime = 0;
        transform.position = new Vector3(0, -10, 0);
    }


    void Update()
    {   
        float moveDistance = speed * Time.deltaTime;
        invuTime += Time.deltaTime;
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            invu = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            invuTime = 0;
        }
        if (invuTime > 1)
        {
            invu = false;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            invuTime = 0;
        }
        transform.position += moveDirection.normalized * moveDistance;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, - 10, 10), transform.position.y, transform.position.z);
    }
}

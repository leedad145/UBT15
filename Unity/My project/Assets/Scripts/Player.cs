using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15.0f;

    void Start()
    {

    }


    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
        }

        transform.position += moveDirection.normalized * moveDistance;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -10, 10), transform.position.y, transform.position.z);
    }
    //collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("[Player] OnCollisionEnter2D");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("[Player] OnCollisionStay2D");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("[Player] OnCollisionExit2D");
    }
    //trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[Player] OnTriggerEnter2D");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("[Player] OnTriggerStay2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("[Player] OnTriggerExit2D");
    }
}

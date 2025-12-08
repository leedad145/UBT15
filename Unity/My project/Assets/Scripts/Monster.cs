using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("[Monster] OnCollisionEnter2D");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("[Monster] OnCollisionStay2D");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("[Monster] OnCollisionExit2D");
    }
    //trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("[Monster] OnTriggerEnter2D");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("[Monster] OnTriggerStay2D");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("[Monster] OnTriggerExit2D");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    GameObject Player;
    Transform canvas;
    void Start()
    {
        canvas = transform.Find("PortalCanvas");
        canvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player = GameObject.Find("Player");
        
        if(other.gameObject == Player)
        {
            canvas.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == Player)
        {
            canvas.gameObject.SetActive(false);
        }
    }
    public void OnBtnClick(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}

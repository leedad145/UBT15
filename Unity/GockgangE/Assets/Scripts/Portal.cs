using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    GameObject Player;
    Transform canvas;
    void Start()
    {
        canvas = transform.Find("PortalCanvas");
        if(canvas == null)
        {
            Debug.LogError("Portal: PortalCanvas를 찾을 수 없습니다.");
            return;
        }
        canvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Player를 매번 찾기 (씬 로드 후 생성될 수 있음)
        if(Player == null)
        {
            Player = GameObject.Find("Player");
        }
        
        if(Player == null)
        {
            Debug.LogWarning("Portal: Player를 찾을 수 없습니다.");
            return;
        }
        
        if(canvas == null)
        {
            canvas = transform.Find("PortalCanvas");
            if(canvas == null)
            {
                Debug.LogError("Portal: PortalCanvas를 찾을 수 없습니다.");
                return;
            }
        }
        
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

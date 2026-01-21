using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void GameSceneLoad()
    {
        SceneManager.LoadScene("Game");
    }
}

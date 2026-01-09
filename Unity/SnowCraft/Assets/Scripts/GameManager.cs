using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject _playerPrefab;
    GameObject _enemyPrefab;
    bool isRun = false;
    int round = 1;

    void Awake()
    {
        _playerPrefab = Resources.Load<GameObject>("Player");
        _enemyPrefab = Resources.Load<GameObject>("Enemy");

        GameStart(round);
    }      
    void GameStart(int r)
    {
        isRun = true;
        GameObject player = GameObject.Find("Player");
        if(player != null)
            player.GetComponent<PlayerController>().OnDead();

        player = Instantiate(_playerPrefab);
        player.name = "Player";

        for(int i = 0; i < r + 2; i++)
        {
            Instantiate(_enemyPrefab);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject _playerPrefab;
    GameObject _enemyPrefab;
    int round = 1;
    Vector3 SpawnPoint = new Vector3(-10,0,0);
    
    void Awake()
    {
        _playerPrefab = Resources.Load<GameObject>("Player");
        _enemyPrefab = Resources.Load<GameObject>("Enemy");
    }
    void Start()
    {
        GameStart(1);
    }
    void Update()
    {
        if (IsClear())
        {
            GameStart(++round);
        }
    }

    void GameStart(int r)
    {
        GameObject player = GameObject.Find("Player");
        if(player != null)
        {
            player.GetComponent<PlayerController>().OnGameEnd -= GameEnd;
            player.GetComponent<PlayerController>().Dead();
        }

        player = Instantiate(_playerPrefab);
        player.name = _playerPrefab.name;
        player.GetComponent<PlayerController>().OnGameEnd += GameEnd;
        for(int i = 0; i < r + 1; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab);
            enemy.transform.position = SpawnPoint;
        }
    }
    bool IsClear()
    {
        if(GameObject.Find("Enemy") == null)
            return true;
        return false;
    }
    void GameEnd()
    {
        SceneManager.LoadScene("Title");
    }
}

using TMPro;
using UnityEngine;

public class pooManager : MonoBehaviour
{
    pooMon ddongPrefab;
    pooPlayer player;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI roundTMP;

    public int round = 1;
    float roundTime = 10;
    float time;
    int score;
    bool isDead;

    private void Start()
    {
        ddongPrefab = Resources.Load<pooMon>("Prefabs/Ddong");
        player = GameObject.FindAnyObjectByType<pooPlayer>();
        roundTime = 0;
        time = 0;
        score = 0;
        isDead = false;
        scoreTMP.text = "SCORE: ";
        roundTMP.text = "ROUND " + round;
    }
    private void Update()
    {
        if (isDead == false)
        {
            time += Time.deltaTime;
            roundTime += Time.deltaTime;
            if (time > 0.5f * (1.0f/round))
            {
                Instantiate<pooMon>(ddongPrefab);
                time = 0;
            }
            if (roundTime > 1)
            {
                roundTMP.text = "";
            }
            if (roundTime > 10)
            {
                round++;
                roundTMP.text = "ROUND " + round;
                roundTime = 0;
            }
            pooMon[] ddongs = GameObject.FindObjectsByType<pooMon>(FindObjectsSortMode.None);
            for (int i = 0; i < ddongs.Length; i++)
            {
                pooMon m = ddongs[i];
                if (m.IsMapOut()) // ¸Ê ¹ÛÀ¸·Î ³ª°¬´ÂÁö
                {
                    GameObject.Destroy(m.gameObject);
                    score++;
                    scoreTMP.text = "SCORE: " + score;
                }
                if ((m.transform.position - player.transform.position).magnitude < 0.8 && !player.invu)
                {
                    scoreTMP.text = "SCORE: " + score;
                    GameObject.Destroy(player.gameObject);
                    roundTMP.text = "GAME OVER";
                    isDead = true;
                }
            }
        }
    }
}
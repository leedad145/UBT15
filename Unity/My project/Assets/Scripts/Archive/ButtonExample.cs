using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonExample : MonoBehaviour
{
    public Button testButton;
    public TextMeshProUGUI scoreText;
    public RectTransform canvasRect;
    public int GamePoint;
    float sumTime = 0; // 0.5초 뒤에 사라짐

    void Start()
    {
        GamePoint = 0;
        testButton.onClick.AddListener(OnClickBtn);
    }
    private void Update()
    {
        sumTime += Time.deltaTime;
        if (sumTime >= 1)
        {
            RandomMove();
        }
    }
    void OnClickBtn()
    {
        GamePoint++;
        scoreText.text = "Score: " + GamePoint.ToString();
        testButton.image.color = Color.red;
    }
    void RandomMove()
    {
        testButton.image.color = Color.white;
        Debug.Log("btn 눌림");
        RectTransform rt = testButton.GetComponent<RectTransform>();
        float x = Random.Range(-canvasRect.rect.width / 2, canvasRect.rect.width / 2);
        float y = Random.Range(-canvasRect.rect.height / 2, canvasRect.rect.height / 2 - 100);
        rt.anchoredPosition = new Vector2(x, y);
        sumTime = 0;
    }
}

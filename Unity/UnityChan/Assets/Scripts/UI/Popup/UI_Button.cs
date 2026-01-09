using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Button : UI_Popup
{
    enum Images
    {
        MoveImage,
    }
    enum Buttons
    {
        PointButton,
    }

    enum Texts
    {
        ScoreText,
    }

    enum GameObjects
    {
        Test,
    }
    void Start()
    {
        Bind<Button>(typeof(Buttons)); // 어딘가에 타입을가져온뒤 그 안에 속한 이름으로 객체를 찾아서 저장해두겠다.
        Bind<Text>(typeof(Texts));
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(GameObjects));
        
        Get<Image>((int)Images.MoveImage).GetComponent<UI_EventHandler>().OnDragHandler += MoveImage;
    }
    int _score = 0;

    // public void OnButtonClicked() 
    // {
    //     _score++;
    //     _text.text = $"점수 : {_score}";
    // }
    void MoveImage(PointerEventData eventData)
    {
        Get<Image>((int)Images.MoveImage).transform.position = eventData.position;
    }
}
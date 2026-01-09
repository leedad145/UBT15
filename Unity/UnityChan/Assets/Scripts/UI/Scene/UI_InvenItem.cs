using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_InvenItem : UI_Base
{
    Sprite _texture;
    string _name;
    public string Name
    {
        get{return _name;}
    }
    enum GameObjects
    {
        ItemIcon,
        ItemNameText,
    }
    public override void Init()
    {
        Bind<GameObject>(typeof(GameObjects));
        RefeshUI();
    }

    public void SetInfo(Sprite texture, string name)
    {
        _texture = texture;
        _name = name;
        RefeshUI();
    }
    public void RefeshUI()
    {
        Image icon = Get<GameObject>((int)GameObjects.ItemIcon).GetOrAddComponent<Image>();
        icon.sprite = _texture;
        Text text = Get<GameObject>((int)GameObjects.ItemNameText).GetOrAddComponent<Text>();
        text.text = _name;
    }
}

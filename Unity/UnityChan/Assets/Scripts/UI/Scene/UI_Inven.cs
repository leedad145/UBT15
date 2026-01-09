using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Inven : UI_Scene
{
    enum GameObjects
    {
        GridPanel,
    }
    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        GameObject gridPanel = Get<GameObject>((int)GameObjects.GridPanel);
        foreach(Transform child in gridPanel.transform)
        {
            Managers.Resource.Destroy(child.gameObject);
        }
        //TODO : 실제 데이터 참고해서 인벤토리 채우기
        for(int i = 0; i < 10; i++)
        {
            GameObject item = Managers.Resource.Instantiate("UI/Scene/UI_InvenItem");
            item.transform.SetParent(gridPanel.transform);

            UI_EventHandler eh = item.GetOrAddComponent<UI_EventHandler>();
            eh.OnClickHandler += ClickItem;

            Texture2D texture = Managers.Resource.Load<Texture2D>("Textures/Icon1");
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            item.GetOrAddComponent<UI_InvenItem>().SetInfo(sprite,$"집행검_{i}");
        }
    }
    public void ClickItem(PointerEventData eventData)
    {
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        UI_InvenItem item = clickedObject.transform.parent.GetComponent<UI_InvenItem>();
        Logger.Log($"아이템 클릭: {item.Name}");
    }
}

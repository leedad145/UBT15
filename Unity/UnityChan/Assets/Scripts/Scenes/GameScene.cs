using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
{


    public override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>("Inven");
    }
    public override void Clear()
    {
        base.Clear();
    }
}

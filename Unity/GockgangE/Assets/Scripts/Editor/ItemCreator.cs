using UnityEngine;
using UnityEditor;

public class ItemCreator
{
    [MenuItem("Tools/Create Sample Items")]
    public static void CreateSampleItems()
    {
        // Assets/Resources 폴더 확인
        string folderPath = "Assets/Resources/Items";
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            AssetDatabase.CreateFolder("Assets/Resources", "Items");
        }
        // 1. 헬스 증강 아이템
        CreateItem(folderPath, "HealthBoost", "체력 강화", 50, 
            hpIncrease: 20, atkDmgIncrease: 0, moveSpdIncrease: 0, jumpPowerIncrease: 0);

        // 2. 공격력 증강 아이템
        CreateItem(folderPath, "AttackBoost", "공격력 강화", 75, 
            hpIncrease: 0, atkDmgIncrease: 5, moveSpdIncrease: 0, jumpPowerIncrease: 0);

        // 3. 속도 증강 아이템
        CreateItem(folderPath, "SpeedBoost", "이동 속도 증강", 60, 
            hpIncrease: 0, atkDmgIncrease: 0, moveSpdIncrease: 2f, jumpPowerIncrease: 0);

        // 4. 점프력 증강 아이템
        CreateItem(folderPath, "JumpBoost", "점프력 강화", 50, 
            hpIncrease: 0, atkDmgIncrease: 0, moveSpdIncrease: 0, jumpPowerIncrease: 3f);

        // 5. 전체 능력치 증강
        CreateItem(folderPath, "FullBoost", "전체 능력치 강화", 150, 
            hpIncrease: 10, atkDmgIncrease: 3, moveSpdIncrease: 1f, jumpPowerIncrease: 2f);

        Debug.Log("샘플 아이템 5개 생성 완료!");
        AssetDatabase.Refresh();
    }

    private static void CreateItem(string folderPath, string itemName, string displayName, int price, 
        int hpIncrease, int atkDmgIncrease, float moveSpdIncrease, float jumpPowerIncrease)
    {
        Item item = ScriptableObject.CreateInstance<Item>();
        item._itemName = displayName;
        item._price = price;
        item._description = $"{displayName} 아이템입니다.";
        item._hpIncrease = hpIncrease;
        item._atkDmgIncrease = atkDmgIncrease;
        item._moveSpdIncrease = moveSpdIncrease;
        item._jumpPowerIncrease = jumpPowerIncrease;

        string path = $"{folderPath}/{itemName}.asset";
        AssetDatabase.CreateAsset(item, path);
        Debug.Log($"아이템 생성: {itemName}");
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _inventoryPanel;
    void Start()
    {
        Managers.Input.OnInputKey += InvenOnOff;
    }

    void Update()
    {
        
    }
    bool isInvenActive = false;
    void InvenOnOff(Define.InputEvent input)
    {
        if(input == Define.InputEvent.KeyPress)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isInvenActive)
                {
                    _inventoryPanel.SetActive(false);
                    isInvenActive = false;
                }
                else
                {
                    _inventoryPanel.SetActive(true);
                    isInvenActive = true;
                }
            }
        }
    }
}

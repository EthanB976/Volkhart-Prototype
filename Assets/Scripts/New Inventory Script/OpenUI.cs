using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject hotbarPanel;
    public GameObject craftingPanel;
    public GameObject playerInfoPanel;
    public GameObject cursor;
    public TypeWriteEffect typeWriteEffect;

    [SerializeField] private SoundManager soundManager;

    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Tab) && typeWriteEffect.dialogueUI.activeSelf == false)
        {
            ToggleInventory();
            soundManager.OpenInventory();
        }

        if(typeWriteEffect.dialogueUI.activeSelf == true)
        {
            inventoryPanel.SetActive(false);
            hotbarPanel.SetActive(true);
            cursor.SetActive(false);
            craftingPanel.SetActive(false);
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            hotbarPanel.SetActive(false);
            playerInfoPanel.SetActive(false);
            cursor.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
            hotbarPanel.SetActive(true);
            playerInfoPanel.SetActive(true);
            cursor.SetActive(false);
            craftingPanel.SetActive(false);
        }
    }

    public void ToggleCraftingOn()
    {
       craftingPanel.SetActive(true);
    }
    public void ToggleCraftingOff()
    {
        inventoryPanel.SetActive(false);
        hotbarPanel.SetActive(true);
        playerInfoPanel.SetActive(true);
        cursor.SetActive(false);
        craftingPanel.SetActive(false);

    }
}

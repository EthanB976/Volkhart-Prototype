using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject hotbarPanel;
    public GameObject craftingPanel;
    public GameObject cursor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            hotbarPanel.SetActive(false);
            cursor.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
            hotbarPanel.SetActive(true);
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
        cursor.SetActive(false);
        craftingPanel.SetActive(false);

    }
}

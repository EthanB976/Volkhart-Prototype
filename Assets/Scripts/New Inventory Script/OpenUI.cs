using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public GameObject inventoryPanel;
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
            cursor.SetActive(true);
        }
        else
        {
            inventoryPanel.SetActive(false);
            cursor.SetActive(false);
        }
    }
}

using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class DoorScript : MonoBehaviour
{
    public ItemClass item;
    public SlotClass[] keyItem;
    public InventoryManager inventoryManager;
    public GameObject door;
  


    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (CanUseKey())
                {
                    UseKey(inventoryManager);
                }
                else
                {
                    Debug.Log("Do not have the Key");
                }
            }
        }
    }

    public void UseKey(InventoryManager inventory)
    {
        inventory.RemoveItem(item);

        door.SetActive(false);


    }

    public bool CanUseKey()
    {
        //Checks all items in inventory, If inventory doesn't contain required amount of items it doesn't allow the user to craft the item
        for (int i = 0; i < keyItem.Length; i++)
        {
            if (!inventoryManager.ContainsItem(keyItem[i].item))
            {
                return false;
            }
        }

        return true;
    }






}

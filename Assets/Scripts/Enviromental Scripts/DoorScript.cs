using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    public ItemClass item;
    public SlotClass[] keyItem;
    public InventoryManager inventoryManager;
    public GameObject door;
    private bool inDoorArea;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private float soundThreshold = 0.1f;

    private void Update()
    {
        if (inDoorArea == true)
        {
            OpenDoor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           inDoorArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inDoorArea = false;
        }
    }

    public void UseKey(InventoryManager inventory)
    {
        inventory.RemoveItemRecipe(item, 1);

        door.SetActive(false);

        soundManager.DoorOpening();

    }

    private void OpenDoor()
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

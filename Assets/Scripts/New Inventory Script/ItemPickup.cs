using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ItemClass item;
    [SerializeField] private int amount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inventoryManager.AddItem(item, amount);
        Destroy(gameObject);
    }



}

using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float playerHealth = 5f;
    public float maxPlayerHealth = 10f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;

    public InventoryManager inventory;

    private void Update()
    {
        //For Testing Purposes will change later
        if (Input.GetKeyDown(KeyCode.E))
        {
            //use this item
            if (inventory.selectedItem != null && inventory.inventoryUI.activeSelf == false)
            {
                inventory.selectedItem.Use(this);
            }
            
        }

        PlayerHealthManager();
    }

    private void PlayerHealthManager()
    {
        if (playerHealth >= maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        if (playerHealth < 0)
        {
            //Insert Game Over Code
        }
    }

    public void TakeDamage()
    {
        //take damage
    }
}

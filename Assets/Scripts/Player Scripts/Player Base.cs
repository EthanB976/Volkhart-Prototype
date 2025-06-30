using System.Collections;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public float playerHealth = 100f;
    public float maxPlayerHealth = 100f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private bool stunned = false;

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] LefttoRightMovement lefttoRightMovement;


    public InventoryManager inventory;

    public Attack attack;
    public GunData gunData;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        lefttoRightMovement = GetComponent<LefttoRightMovement>();
    }

    private void Update()
    {
        //For Testing Purposes will change later
        if (Input.GetMouseButtonDown(0))
        {
            //use this item
            if (inventory.selectedItem != null && inventory.inventoryUI.activeSelf == false)
            {
                inventory.selectedItem.Use(this);
            }

        }

        PlayerHealthManager();
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        
        StartCoroutine(PlayerDamage(2f));
        if (playerHealth <= 0)
        {
            
            //StartCoroutine(PlayerDeath());
        }

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


    private IEnumerator PlayerDamage(float duration)
    {
        stunned = true;
        playerMovement.Stunned();
        lefttoRightMovement.Stunned();
        yield return new WaitForSeconds(0.25f);
        playerMovement.NotStunned();
        lefttoRightMovement.NotStunned();
        stunned = false;

    }
}

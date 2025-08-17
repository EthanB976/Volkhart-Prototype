
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PlayerBase : MonoBehaviour
{
    public float playerHealth = 100f;
    public float maxPlayerHealth = 100f;
    [SerializeField] public bool stunned = false;

    [SerializeField] private Rigidbody2D rb2d;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] LefttoRightMovement lefttoRightMovement;

    [SerializeField] private Slider playerHealthBar;
    [SerializeField] private Slider potentialPlayerHealthBar;

    public InventoryManager inventory;
    public TypeWriteEffect typeWriteEffect;

    public Attack attack;
    public GunData gunData;

    [SerializeField] private Quaternion originalRotation;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private ItemClass potion;
    [SerializeField] private ItemClass bigPotion;
    [SerializeField] private GameObject potentialPlayerHealthBarHolder;




    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        lefttoRightMovement = GetComponent<LefttoRightMovement>();
        playerHealth = maxPlayerHealth;
        playerHealthBar.maxValue = maxPlayerHealth;
        playerHealthBar.value = playerHealth;
    }

    private void Update()
    {
        //For Testing Purposes will change later
        if (Input.GetMouseButtonDown(0))
        {
            //use this item
            if (inventory.selectedItem != null && inventory.inventoryUI.activeSelf == false && typeWriteEffect.dialogueUI.activeSelf == false)
            {
                inventory.selectedItem.Use(this);

                playerHealthBar.value = playerHealth;
                potentialPlayerHealthBarHolder.SetActive(false);
            }

        }

        CheckingForPotion();

        PlayerHealthManager();
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        playerHealthBar.value = playerHealth;

        soundManager.DamagePlayer();

        originalRotation = transform.rotation;

        StartCoroutine(PlayerDamage(2f));
        if (playerHealth <= 0)
        {

            SceneManager.LoadScene(1);
        }

    }

    private void PlayerHealthManager()
    {
        if (playerHealth >= maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
            playerHealthBar.value = playerHealth;
        }

    }


    private IEnumerator PlayerDamage(float duration)
    {
        stunned = true;
        yield return new WaitForSeconds(0.25f);
        transform.rotation = originalRotation;
        stunned = false;

    }

    private void CheckingForPotion()
    {
        if (inventory.selectedItem == potion)
        {
            potentialPlayerHealthBarHolder.SetActive(true);
            potentialPlayerHealthBar.value = playerHealth + 20;
        }
        if (inventory.selectedItem == bigPotion)
        {
            potentialPlayerHealthBarHolder.SetActive(true);
            potentialPlayerHealthBar.value = playerHealth + 50;
        }
        if (inventory.selectedItem != potion && inventory.selectedItem != bigPotion)
        {
            potentialPlayerHealthBarHolder.SetActive(false);
        }

    }


}

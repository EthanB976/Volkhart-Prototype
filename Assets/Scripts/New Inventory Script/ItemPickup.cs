using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private ItemClass item;
    [SerializeField] private int amount;
    [SerializeField] private Image itemPickedUp;
    [SerializeField] private TextMeshProUGUI itemText;
    [SerializeField] GameObject itemPickedUpUI;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(DisplayInfo());
        inventoryManager.AddItem(item, amount);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    IEnumerator DisplayInfo()
    {
        itemPickedUpUI.SetActive(true);
        itemPickedUp.sprite = gameObject.GetComponent<SpriteRenderer>().sprite; 
        itemText.text = item.name + " Added";
        yield return new WaitForSeconds(0.5f);
        itemPickedUpUI.SetActive(false);
        Destroy(gameObject);
        StopCoroutine(DisplayInfo());
    }


}

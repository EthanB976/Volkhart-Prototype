using System.Collections;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyTasks : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private bool hasGun;
    private bool hasShipPart;
    public bool hasTurnedOffDefences;
    private bool readyToEscape;
    private bool inEscapeArea;
    public SlotClass[] keyItems;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inEscapeArea == true)
        {
            WinGame();
            CheckForWin();
        }
    }

    private void WinGame()
    {

        if (readyToEscape == true && Input.GetKeyDown(KeyCode.E))
        {

            SceneManager.LoadScene(1);
        }

    }

    public bool CheckForItems()
    {
        //Checks all items in inventory, If inventory doesn't contain required amount of items it doesn't allow the user to craft the item
        for (int i = 0; i < keyItems.Length; i++)
        {
            if (!inventoryManager.ContainsItem(keyItems[i].item))
            {
                return false;
            }
        }

        return true;
    }

    public void TurnOffShipDefences()
    {
        hasTurnedOffDefences = true;
    }

    private void CheckForWin()
    {
        if (CheckForItems() && hasTurnedOffDefences == true)
        {
            readyToEscape = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inEscapeArea = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inEscapeArea = false;
        }
    }
}

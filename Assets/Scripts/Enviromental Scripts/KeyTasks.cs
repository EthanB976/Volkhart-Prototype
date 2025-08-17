using System.Collections;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyTasks : MonoBehaviour
{
    public InventoryManager inventoryManager;
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
        }
    }

    private void WinGame()
    {
            SceneManager.LoadScene(1);
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

using TMPro;
using UnityEngine;

public class PlayerTasks : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerTasksText;
    public InventoryManager inventoryManager;
    public SlotClass[] taskItems;
    public SlotClass[] item;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTasksText.text = "Tasks: <br>- Explore further into the Volkart";
    }

    // Update is called once per frame
    void Update()
    {
        if (TasksFinished())
        {
            CollectedItems();
        }

    }

    public void FinishedTutorial()
    {
        playerTasksText.text = "Tasks: <br>- Find The Gun <br>- Craft Door Repair Component";
    }

    public void CollectedItems()
    {
        playerTasksText.text = "Tasks: <br>- Open the broken door";
    }

    public void FixedFinalDoor()
    {
        playerTasksText.text = "Tasks: <br>- Escape the Volkart";
    }

    public bool TasksFinished()
    {
        //Checks all items in inventory, If inventory doesn't contain required amount of items it doesn't allow the user to craft the item
        for (int i = 0; i < taskItems.Length; i++)
        {
            if (!inventoryManager.ContainsItem(taskItems[i].item))
            {
                return false;
            }
        }

        return true;
    }

}

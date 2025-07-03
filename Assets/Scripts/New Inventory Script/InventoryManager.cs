using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class InventoryManager : MonoBehaviour
{

    [SerializeField] private GameObject slotHolder;
    [SerializeField] private GameObject hotbarSlotHolder;
    [SerializeField] private ItemClass itemToAdd;
    [SerializeField] private ItemClass itemToRemove;

    [SerializeField] private SlotClass[] startingItems;
    private SlotClass[] items;
    private SlotClass[] hotbarItems;

    private GameObject[] slots;
    private GameObject[] hotbarSlots;

    private SlotClass movingSlot;
    private SlotClass tempSlot;
    private SlotClass originalSlot;
    bool isMovingItem;

    [SerializeField] private GameObject itemCursor;

    [SerializeField] private GameObject hotbarSelector;
    [SerializeField] private int selectedSlotIndex = 0;
    public ItemClass selectedItem;

   // [SerializeField] private List<CraftingRecipeClass> craftingRecipes = new List<CraftingRecipeClass>();
    public GameObject inventoryUI;


    private void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        items = new SlotClass[slots.Length];

        hotbarSlots = new GameObject[hotbarSlotHolder.transform.childCount];
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i] = hotbarSlotHolder.transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < items.Length; i++)
        {
            items[i] = new SlotClass();
        }

        //sets all the slots
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }

        //Add items
        for (int i = 0; i < startingItems.Length; i++)
        {
            AddItem(startingItems[i].item, startingItems[i].quantity);
        }

        RefreshUI();
        // AddItem(itemToAdd, 1); - Used for testing
        // RemoveItem(itemToRemove); - Used for testing
    }

    private void Update()
    {
        if (inventoryUI.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(0))// We Left Click
            {
                //Find closest slot (Slot that is clicked)
                if (isMovingItem)
                {
                    EndItemMove();
                }
                else
                {
                    BeginItemMove();
                }

            }
            else if (Input.GetMouseButtonDown(1))//We Right Click
            {
                //Find closest slot (Slot that is clicked)
                if (isMovingItem)
                {
                    EndItemMove_Single();
                }
                else
                {
                    BeginItemMove_Half();

                }
            }
        }
        if (inventoryUI.activeSelf == false)
        {
            if (isMovingItem == true)
            {
                EndItemMove();
                EndItemMove_Single();
            }
        }

        itemCursor.SetActive(isMovingItem);
        itemCursor.transform.position = Input.mousePosition;
        if (isMovingItem)
        {
            itemCursor.GetComponent<Image>().sprite = movingSlot.item.itemIcon;
        }


        if (Input.GetAxis("Mouse ScrollWheel") > 0) //Scrolling up
        {
            selectedSlotIndex = Mathf.Clamp(selectedSlotIndex + 1, 0, 5);
            
            if (selectedSlotIndex > 4)
            {
                selectedSlotIndex = 0;
            }
            
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) //Scrolling down
        {
            selectedSlotIndex = Mathf.Clamp(selectedSlotIndex - 1, -1, hotbarSlots.Length - 1);
            if (selectedSlotIndex < 0)
            {
                selectedSlotIndex = 4;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSlotIndex = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSlotIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSlotIndex = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedSlotIndex = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedSlotIndex = 4;
        }


        hotbarSelector.transform.position = hotbarSlots[selectedSlotIndex].transform.position;
        selectedItem = items[selectedSlotIndex + (hotbarSlots.Length * 3)].item;

       /* Used for Testing
        if (Input.GetKeyDown(KeyCode.C)) //Handles Crafting atm
        {
            Craft(craftingRecipes[0]);
        }
       */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    #region Inventory Untils
    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].item.itemIcon;
                if (items[i].item.isStackable)
                {
                    slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i].quantity.ToString();
                }
                else
                {
                    slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                }
                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = items[i].item.itemName;

            }
            catch
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                slots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                slots[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "";
            }

        }

        RefreshHotbar();
    }

    public void RefreshHotbar()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            try
            {
                hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i + (hotbarSlots.Length * 3)].item.itemIcon;

                if (items[i + (hotbarSlots.Length * 3)].item.isStackable)
                {
                    hotbarSlots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[i + (hotbarSlots.Length * 3)].quantity.ToString();
                }
                else
                {
                    hotbarSlots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
                }

            }
            catch
            {
                hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                hotbarSlots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                hotbarSlots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
            }

        }
    }

    public bool AddItem(ItemClass item, int quantity)
    {
        //Check if inventory contains item being added already
        SlotClass slot = Contains(item);

        if (slot != null && slot.item.isStackable && slot.quantity < item.stackSize)
        {
            //Make sure items are split upon being added to inventory depending on stack size max
            var quantityCanAdd = slot.item.stackSize - slot.quantity;
            var quantityToAdd = Mathf.Clamp(quantity, 0, quantityCanAdd);

            var remainder = quantity - quantityCanAdd;

            slot.AddQuantity(quantityToAdd);
            if (remainder > 0)
            {
                AddItem(item, remainder);
            }
        }
        else
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].item == null)
                {
                    var quantityCanAdd = item.stackSize - items[i].quantity;
                    var quantityToAdd = Mathf.Clamp(quantity, 0, quantityCanAdd);

                    var remainder = quantity - quantityCanAdd;

                    items[i].AddItem(item, quantityToAdd);
                    if (remainder > 0)
                    {
                        AddItem(item, remainder);
                    }
                    break;
                }
            }

        }


        RefreshUI();
        return true;
    }

    public bool RemoveItem(ItemClass item)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.quantity > 1)
            {
                temp.SubQuantity(1);
            }
            else
            {
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].item == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }

                items[slotToRemoveIndex].Clear();
            }

        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

    public bool RemoveItemRecipe(ItemClass item, int quantity)
    {
        SlotClass temp = Contains(item);
        if (temp != null)
        {
            if (temp.quantity > 1)
            {
                temp.SubQuantity(quantity);
            }
            else
            {
                int slotToRemoveIndex = 0;

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].item == item)
                    {
                        slotToRemoveIndex = i;
                        break;
                    }
                }

                items[slotToRemoveIndex].Clear();
            }

        }
        else
        {
            return false;
        }

        RefreshUI();
        return true;
    }

    public void UseSelected()
    {
        items[selectedSlotIndex + (hotbarSlots.Length * 3)].SubQuantity(1);
        RefreshUI();
    }

    public SlotClass Contains(ItemClass item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item == item /*&& items[i].item.isStackable && */)
                return items[i];
        }

        return null;
    }

    public bool ContainsRecipe(ItemClass item, int quantity)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item == item && items[i].quantity >= quantity)

                return true;

        }

        return false;
    }

    public bool isFull()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item == null)
            {
                return false;
            }
        }
        return true;
    }
    #endregion Inventory Utils


    #region Movement Stuff
    private bool BeginItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null || originalSlot.item == null)
        {
            return false; //There is no item to move
        }

        movingSlot = new SlotClass(originalSlot);
        originalSlot.Clear();
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool BeginItemMove_Half()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null || originalSlot.item == null)
        {
            return false; //There is item to move
        }

        movingSlot = new SlotClass(originalSlot.item, Mathf.CeilToInt(originalSlot.quantity / 2f));
        originalSlot.SubQuantity(Mathf.CeilToInt(originalSlot.quantity / 2f));
        if (originalSlot.quantity == 0)
        {
            originalSlot.Clear();
            //RefreshUI();
        }
        isMovingItem = true;
        RefreshUI();
        return true;
    }

    private bool EndItemMove()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null)
        {
            AddItem(movingSlot.item, movingSlot.quantity);
            movingSlot.Clear();
        }
        else
        {

            if (originalSlot.item != null)
            {
                if (originalSlot.item == movingSlot.item && originalSlot.item.isStackable && originalSlot.quantity < originalSlot.item.stackSize) //They're the same item so should stack
                {
                    var quantityCanAdd = originalSlot.item.stackSize - originalSlot.quantity;
                    var quantityToAdd = Mathf.Clamp(movingSlot.quantity, 0, quantityCanAdd);
                    var remainder = movingSlot.quantity - quantityToAdd;
                    originalSlot.AddQuantity(quantityToAdd);
                    if (remainder == 0)
                    {
                        movingSlot.Clear();
                    }
                    else
                    {
                        movingSlot.SubQuantity(quantityCanAdd);
                        RefreshUI();
                        return false;

                    }
                }
                else
                {
                    tempSlot = new SlotClass(originalSlot); // a = b
                    originalSlot.AddItem(movingSlot.item, movingSlot.quantity); // b = c
                    movingSlot.AddItem(tempSlot.item, tempSlot.quantity); // a = c

                    RefreshUI();
                    return true;
                }

            }
            else //Place item as usual
            {
                originalSlot.AddItem(movingSlot.item, movingSlot.quantity);
                movingSlot.Clear();
            }
        }

        isMovingItem = false;
        RefreshUI();
        return true;

    }

    private bool EndItemMove_Single()
    {
        originalSlot = GetClosestSlot();
        if (originalSlot == null)
        {
            return false; //There is no item to move
        }
        if (originalSlot.item != null && (originalSlot.item != movingSlot.item || originalSlot.quantity >= originalSlot.item.stackSize))
        {
            return false;
        }

        if (isMovingItem == false)
        {
            movingSlot.SubQuantity(1);
        }
        else
        {
            movingSlot.SubQuantityMoving(1);
        }

        if (originalSlot.item != null && originalSlot.item == movingSlot.item)
        {
            originalSlot.AddQuantity(1);
        }
        else
        {
            originalSlot.AddItem(movingSlot.item, 1);
        }


        if (movingSlot.quantity < 1)
        {
            isMovingItem = false;
            movingSlot.Clear();

            RefreshUI();
        }
        else
        {
            isMovingItem = true;
        }

        RefreshUI();
        return true;


    }

    private SlotClass GetClosestSlot()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (Vector2.Distance(slots[i].transform.position, Input.mousePosition) <= 32)
            {
                return items[i];
            }
        }

        return null;
    }

    #endregion Movement Stuff

    public void Craft(CraftingRecipeClass recipe)
    {
        if (recipe.CanCraft(this))
            recipe.Craft(this);
        else
        {
            Debug.Log("Cannout Craft Item");
        }

    }
}

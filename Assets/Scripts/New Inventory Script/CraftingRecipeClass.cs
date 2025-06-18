using UnityEngine;

[CreateAssetMenu(fileName = "NewCraftingRecipe", menuName = "Crafting/Recipe")]
public class CraftingRecipeClass : ScriptableObject
{
    public SlotClass[] inputItems;
    public SlotClass outputItem;
    public SlotClass inputItems1;
    public SlotClass inputItems2;
    public SlotClass inputItems3;

    public bool CanCraft(InventoryManager inventory)
    {
        //Check if Inventory has space to craft item
        if (inventory.isFull())
        
            return false;      

        //Checks all items in inventory, If inventory doesn't contain required amount of items it doesn't allow the user to craft the item
        for (int i = 0; i < inputItems.Length; i++)
        {
            if (!inventory.ContainsRecipe(inputItems[i].item, inputItems[i].quantity))
            {
                return false;
            }
        }

        //return if inventory has input items
        return true;
    }

    public void Craft(InventoryManager inventory)
    {
        //Remove input items from inventory 
        for (int i = 0; i < inputItems.Length; i++)
        {
            inventory.RemoveItemRecipe(inputItems[i].item, inputItems[i].quantity);
        }

        //Create output item in the inventory
        inventory.AddItem(outputItem.item, outputItem.quantity);
    }
}

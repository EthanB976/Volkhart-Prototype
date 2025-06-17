using UnityEngine;
using System.Collections;

public class ItemClass : ScriptableObject
{
    //All Classes are derived from these classes.
    //Data shared across every item;
    [Header("Item")]
    public string itemName;
    public float ItemID;
    public Sprite itemIcon;
    public bool isStackable = true;
    public int stackSize = 99;


    public virtual void Use(PlayerBase caller)
    {
        Debug.Log("Used: Item");
    }
    public virtual ItemClass GetItem() { return this; }
    public virtual ToolClass GetTool() { return null; }
    public virtual MiscClass GetMisc() { return null; }
    public virtual ConsumableClass GetConsumable() { return null; }




}

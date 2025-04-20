using UnityEngine;
using System.Collections;

public abstract class ItemClass : ScriptableObject
{
    //All Classes are derived from these classes.
    //Data shared across every item;
    [Header("Item")]
    public string itemName;
    public float ItemID;
    public Sprite itemIcon;
    public bool isStackable = true;
    public abstract ItemClass GetItem();
    public abstract ToolClass GetTool();
    public abstract MiscClass GetMisc();
    public abstract ConsumableClass GetConsumable();




}

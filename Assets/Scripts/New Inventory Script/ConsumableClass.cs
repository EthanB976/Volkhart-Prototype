using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Class", menuName = "Item/Consumable")]
public class ConsumableClass : ItemClass
{
    //Data specific to conumsable class items

    [Header("Consumable")]
    public float healthAdded;
    public override ItemClass GetItem()
    {
        return this;
    }
    public override ToolClass GetTool()
    {
        return null;
    }
    public override MiscClass GetMisc()
    {
        return null;
    }
    public override ConsumableClass GetConsumable()
    {
        return this;
    }
}

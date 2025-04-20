using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class", menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    //Data specific to tool class items

    [Header("Tool")]
    public ToolType toolType;
    public enum ToolType
    {
        Weapon,
        Pickaxe,
        Gun
    }
    public override ItemClass GetItem()
    {
        return this;
    }
    public override ToolClass GetTool()
    {
        return this;
    }
    public override MiscClass GetMisc()
    {
        return null;
    }
    public override ConsumableClass GetConsumable()
    {
        return null;
    }
}

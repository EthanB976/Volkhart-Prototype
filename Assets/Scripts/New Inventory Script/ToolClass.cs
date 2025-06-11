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

    public override void Use(PlayerBase caller)
    {
        //Uses the tool 
        base.Use(caller);
        if (toolType == ToolType.Weapon)
        { 
            Debug.Log("Swing Weapon");
            //Insert Weapon logic here
        }
        else if (toolType == ToolType.Pickaxe)
        {
            Debug.Log("Swing Pickaxe");
            //Insert Pickaxe logic here
        }
        else if (toolType == ToolType.Gun)
        {
            Debug.Log("Shoot Gun");
            //Inset Gun logic here
        }
        
    }

    public override ToolClass GetTool()
    {
        return this;
    }
  
}

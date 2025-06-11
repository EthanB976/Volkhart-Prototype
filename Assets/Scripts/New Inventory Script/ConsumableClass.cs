using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Class", menuName = "Item/Consumable")]
public class ConsumableClass : ItemClass
{
    //Data specific to conumsable class items

    [Header("Consumable")]
    public float healthAddedAmount;

    public override void Use(PlayerBase caller)
    {
        //Use the Consumable
        base.Use(caller);        
        if (caller.playerHealth < caller.maxPlayerHealth)
        {
            caller.playerHealth = caller.playerHealth + healthAddedAmount;
            caller.inventory.UseSelected();
            Debug.Log("Eat Consumable");
        }
        else
        {
            Debug.Log("Cannot use health at max");
        }

    }

    public override ConsumableClass GetConsumable()
    {
        return this;
    }
}

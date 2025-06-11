using UnityEngine;

[CreateAssetMenu(fileName = "New Misc Class", menuName = "Item/Misc")]
public class MiscClass : ItemClass
{
    //Data specific to misc class

    public override void Use(PlayerBase caller)
    {
        //Cause it is misc item it shouldn't do anything.
        //base.Use(caller);
    }
    public override MiscClass GetMisc()
    {
        return this;
    }

}

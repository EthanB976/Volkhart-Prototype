using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FarmPlayer : MonoBehaviour
{
   public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(21);
    }

    public void DropItem(Collectable item)
    {
        Vector2 spawnLocation = transform.position;

        Vector2 spawnOffset = Random.insideUnitCircle * 3.5f;

        Collectable droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        droppedItem.rb.AddForce(spawnOffset * 1f, ForceMode2D.Impulse);
    }
}

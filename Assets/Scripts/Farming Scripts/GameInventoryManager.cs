using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInventoryManager : MonoBehaviour
{
    public static GameInventoryManager instance;

    public ItemManager itemManager;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        itemManager = GetComponent<ItemManager>();
    }
}

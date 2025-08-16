using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class GunData : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float reloadDelay;
    [SerializeField] private bool canShoot = true;
    [SerializeField] private float currentDelay = 0f;
    [SerializeField] private int bulletPoolCount = 10;
    [SerializeField] private ObjectPoolBullet bulletPool;
    [SerializeField] BulletData bulletData;

    public InventoryManager inventoryManager;
    public ScriptableObject scriptableObject;
    [SerializeField] private GameObject GunSights;
    public SlotClass[] ammoItem;
    public ItemClass ammoAmount;

    [SerializeField] private SoundManager soundManager;
    [SerializeField] private float soundThreshold = 0.1f;

    private void Start()
    {
        bulletPool.Initialize(bulletPrefab, bulletPoolCount);

    }

    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                if (HasAmmo())
                {
                    canShoot = true;
                }
            }
        }

        DisplaySightLines();
    }

    public void Shoot()
    {
        if (canShoot && HasAmmo())
        {
            canShoot = false;
            currentDelay = reloadDelay;

            soundManager.Gun();

            GameObject bullet = bulletPool.CreateObject();
            float spawnOffSet = 0.2f;
            bullet.transform.position = transform.position + transform.forward * spawnOffSet;
            bullet.transform.rotation = transform.rotation;

            bulletData = bullet.GetComponent<BulletData>();

            if (bulletData != null)
            {
                bulletData.Initialize();
            }


            inventoryManager.RemoveItem(ammoAmount);
        }
        else
        {
            Debug.Log("No ammo");
        }
    }

    public bool HasAmmo()
    {
        //Checks all items in inventory, If inventory doesn't contain required amount of items it doesn't allow the user to craft the item
        for (int i = 0; i < ammoItem.Length; i++)
        {
            if (!inventoryManager.ContainsItem(ammoItem[i].item))
            {
                return false;
            }
        }

        return true;
    }


    public void DisplaySightLines()
    {
        if (inventoryManager.selectedItem == scriptableObject)
        {
            GunSights.SetActive(true);
        }
        else
        {
            GunSights.SetActive(false);
        }
    }

}

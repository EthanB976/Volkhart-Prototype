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
                canShoot = true;
            }
        }

        DisplaySightLines();
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            GameObject bullet = bulletPool.CreateObject();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            bulletData = bullet.GetComponent<BulletData>();
            if (bulletData != null)
            {
                bulletData.Initialize();
            }
        }
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

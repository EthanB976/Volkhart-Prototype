using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPoolBullet : MonoBehaviour
{
    [SerializeField] protected GameObject objectPool;
    [SerializeField] protected int poolSize = 10;

    protected Queue<GameObject> objectPools;
    public Transform spawnedObjectParent;

    private void Awake()
    {
        objectPools = new Queue<GameObject>();
    }

    public void Initialize(GameObject objectPool, int poolSize = 10)
    {
        this.objectPool = objectPool;
        this.poolSize = poolSize;
    }

    public GameObject CreateObject()
    {
        GameObject spawnedObject = null;

        if (objectPools.Count < poolSize)
        {
            spawnedObject = Instantiate(objectPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + objectPool.name + "_" + objectPools.Count;
            spawnedObject.transform.SetParent(spawnedObjectParent);
            spawnedObject.AddComponent<DestroyIfDisabled>();
        }
        else
        {
            spawnedObject = objectPools.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }

        objectPools.Enqueue(spawnedObject);
        return spawnedObject;
    }

    private void CreateObjectParentIfNeeded()
    {
        if (spawnedObjectParent == null)
        {
            string name = "ObjectPool_" + objectPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
            {
                spawnedObjectParent = parentObject.transform;
            }
            else
            {
                spawnedObjectParent = new GameObject(name).transform;
            }
        }
    }

    private void OnDestroy()
    {
        foreach (var item in objectPools)
        {
            if (item == null)
                continue;
            else if (item.activeSelf == false)
                Destroy(item);
            else
                item.GetComponent<DestroyIfDisabled>().SelfDestructionEnabled = true;
        }
    }

}

using UnityEngine;

public class AlienSpawnTesting : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnObject;

    public int MaxEnemyCount = 3;

    private int enemyCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount <= 3 && Input.GetKeyDown(KeyCode.E))
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnObject.transform);
    }
}

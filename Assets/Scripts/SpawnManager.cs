using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnRangeX = 10f;

    [SerializeField] private float spawnPosZ = 10f;

    [SerializeField] private float spawnPosY = -1.5f;
    
    [SerializeField] private float respawnTime = 2f;

    [SerializeField] private bool spawnEnemies;

    [SerializeField] private bool canSpawnEnemy;
    
    [SerializeField] private GameObject[] enemyPrefabs;
    

    void Start()
    {
        canSpawnEnemy = true;
        spawnEnemies = true;
        SpawnRandomEnemy();
    }
    private void SpawnRandomEnemy()
    {
        if (spawnEnemies && GameManager.instance.gameIsProccessing && canSpawnEnemy)
        {
            int index = Random.Range(0, enemyPrefabs.Length);
            
            Instantiate(enemyPrefabs[index], GenerateRandomPos(), enemyPrefabs[index].transform.rotation);

            StartCoroutine(EnemiesIntervalRoutine());
        }
    }

    private Vector3 GenerateRandomPos()
    {
        return new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnPosY, spawnPosZ);
    }

    IEnumerator<WaitForSeconds> EnemiesIntervalRoutine()
    {
        canSpawnEnemy = false;
        yield return new WaitForSeconds(respawnTime);
        canSpawnEnemy = true;
        SpawnRandomEnemy();
    }
}

using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private readonly float spawnRange = 9;

    public GameObject enemyPrefab;

    void Start()
    {
        SpawnEnemyWave(3);
    }

    void Update()
    {
        RespawnEnemies();
    }

    private void SpawnEnemyWave(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }
    }

    private void RespawnEnemies()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SpawnEnemyWave(1);
        }
    }

    private Vector3 GenerateSpawnPoint()
    {
        var spawnPosX = Random.Range(-spawnRange, spawnRange);
        var spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}

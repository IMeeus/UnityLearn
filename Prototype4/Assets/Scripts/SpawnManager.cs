using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private readonly float spawnRange = 9;

    public int waveNumber = 1;

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    void Start()
    {
        SpawnPowerUp();
        SpawnEnemyWave(3);
    }

    void Update()
    {
        SpawnNextWave();
    }

    private void SpawnEnemyWave(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
    }

    private void SpawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPoint(), powerUpPrefab.transform.rotation);
    }

    private void SpawnNextWave()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SpawnPowerUp();
            SpawnEnemyWave(waveNumber++);
        }
    }

    private Vector3 GenerateSpawnPoint()
    {
        var spawnPosX = Random.Range(-spawnRange, spawnRange);
        var spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}

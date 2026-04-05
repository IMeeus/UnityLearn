using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private readonly float spawnRange = 9;

    public GameObject enemyPrefab;

    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPoint()
    {
        var spawnPosX = Random.Range(-spawnRange, spawnRange);
        var spawnPosZ = Random.Range(-spawnRange, spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}

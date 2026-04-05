using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnPositionX = 25;
    public float spawnDelay = 2f;
    public float spawnRate = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), spawnDelay, spawnRate);
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, new Vector3(spawnPositionX, 0, 0), obstaclePrefab.transform.rotation);
    }
}

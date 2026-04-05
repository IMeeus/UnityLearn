using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerController _playerControllerScript;

    public GameObject obstaclePrefab;
    public float spawnPositionX = 25;
    public float spawnDelay = 2f;
    public float spawnRate = 2f;

    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating(nameof(SpawnObstacle), spawnDelay, spawnRate);
    }

    void SpawnObstacle()
    {
        if (_playerControllerScript.isGameOver)
            return;

        Instantiate(obstaclePrefab, new Vector3(spawnPositionX, 0, 0), obstaclePrefab.transform.rotation);
    }
}

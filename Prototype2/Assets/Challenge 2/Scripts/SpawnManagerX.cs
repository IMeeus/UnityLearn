using System.Collections;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private readonly float _spawnLimitXLeft = -22;
    private readonly float _spawnLimitXRight = 7;
    private readonly float _spawnPosY = 30;
    private readonly float _startDelay = 1.0f;
    private readonly float _minSpawnInterval = 3;
    private readonly float _maxSpawnInterval = 5;

    void Start()
    {
        StartCoroutine(nameof(SpawnRandomBallRoutine));
    }

    IEnumerator SpawnRandomBallRoutine()
    {
        yield return new WaitForSeconds(_startDelay);

        while (true)
        {
            SpawnRandomBall();
            float randomInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    void SpawnRandomBall()
    {
        var spawnPos = new Vector3(Random.Range(_spawnLimitXLeft, _spawnLimitXRight), _spawnPosY, 0);
        var ballIndex = Random.Range(0, ballPrefabs.Length);
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[0].transform.rotation);
    }
}

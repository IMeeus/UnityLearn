using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private readonly float _startDelay = 2;
    private readonly float _spawnInterval = 2;

    private readonly float _horizontalSpawnRangeX = 20;
    private readonly float _horizontalSpawnPositionZ = 20;

    private readonly float _verticalSpawnRangeZ = 15;
    private readonly float _verticalSpawnPositionX = 30;

    private Quaternion _lookLeftQuaternion = Quaternion.Euler(0, -90, 0);
    private Quaternion _lookRightQuaternion = Quaternion.Euler(0, 90, 0);

    public GameObject[] animalPrefab;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAnimalTop), _startDelay, _spawnInterval);
        InvokeRepeating(nameof(SpawnAnimalLeft), _startDelay, _spawnInterval);
        InvokeRepeating(nameof(SpawnAnimalRight), _startDelay, _spawnInterval);
    }

    private void SpawnAnimalTop()
    {
        var animalIndex = Random.Range(0, animalPrefab.Length);
        var animalToSpawn = animalPrefab[animalIndex];
        var spawnPos = new Vector3(Random.Range(-_horizontalSpawnRangeX, _horizontalSpawnRangeX), 0, _horizontalSpawnPositionZ);

        Instantiate(animalToSpawn, spawnPos, animalToSpawn.transform.rotation);
    }

    private void SpawnAnimalLeft()
    {
        var animalIndex = Random.Range(0, animalPrefab.Length);
        var animalToSpawn = animalPrefab[animalIndex];
        var spawnPos = new Vector3(-_verticalSpawnPositionX, 0, Random.Range(0, _verticalSpawnRangeZ));

        Instantiate(animalToSpawn, spawnPos, _lookRightQuaternion);
    }

    private void SpawnAnimalRight()
    {
        var animalIndex = Random.Range(0, animalPrefab.Length);
        var animalToSpawn = animalPrefab[animalIndex];
        var spawnPos = new Vector3(_verticalSpawnPositionX, 0, Random.Range(0, _verticalSpawnRangeZ));

        Instantiate(animalToSpawn, spawnPos, _lookLeftQuaternion);
    }
}

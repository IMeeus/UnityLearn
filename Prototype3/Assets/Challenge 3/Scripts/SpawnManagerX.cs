using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    private float spawnDelay = 2;
    private float spawnInterval = 1.5f;
    private PlayerControllerX playerControllerScript;

    public GameObject[] objectPrefabs;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObjects), spawnDelay, spawnInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    void SpawnObjects()
    {
        Vector3 spawnLocation = new(30, Random.Range(5, 15), 0);
        int index = Random.Range(0, objectPrefabs.Length);

        if (!playerControllerScript.gameOver)
        {
            Instantiate(objectPrefabs[index], spawnLocation, objectPrefabs[index].transform.rotation);
        }
    }
}

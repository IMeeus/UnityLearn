using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController _playerControllerScript;

    public float speed = 30;
    public float leftBound = -15;

    void Start()
    {
        _playerControllerScript = GameObject
            .Find("Player")
            .GetComponent<PlayerController>();
    }

    void Update()
    {
        if (_playerControllerScript.isGameOver)
            return;

        MoveObjectLeft();
        DestroyOutOfBounds();
    }

    private void MoveObjectLeft()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }

    private void DestroyOutOfBounds()
    {
        if (transform.position.x <= leftBound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}

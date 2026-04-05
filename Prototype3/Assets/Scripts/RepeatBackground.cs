using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;

    public float resetPositionX = -50;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (transform.position.x <= startPosition.x - resetPositionX)
        {
            transform.position = startPosition;
        }
    }
}

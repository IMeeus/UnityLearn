using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private readonly float topBound = 30;
    private readonly float lowerBound = -10;
    private readonly float leftBound = -30;
    private readonly float rightBound = 30;

    void Update()
    {
        if (transform.position.z > topBound ||
            transform.position.z < lowerBound ||
            transform.position.x < leftBound ||
            transform.position.x > rightBound)
        {
            Destroy(gameObject);
            return;
        }
    }
}

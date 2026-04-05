using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}

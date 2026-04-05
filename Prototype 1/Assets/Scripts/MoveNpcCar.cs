using UnityEngine;

public class MoveNpcCar : MonoBehaviour
{
    public int speed = 10;

    private void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector3.forward);
    }
}
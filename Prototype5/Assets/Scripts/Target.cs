using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    private readonly float minSpeed = 12;
    private readonly float maxSpeed = 16;
    private readonly float maxTorque = 3;
    private readonly float xRange = 4;
    private readonly float ySpawnPos = -6;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);

        var torque = new Vector3(RandomTorque(), RandomTorque(), RandomTorque());
        Debug.Log($"Torque: {torque}");
        rb.AddTorque(torque, ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}

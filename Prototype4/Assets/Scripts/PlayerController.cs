using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject _focalPoint;

    public float moveSpeed = 5;
    public bool hasPowerUp = false;
    public float powerUpStrength = 15;

    public InputActionReference moveAction;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        var verticalInput = moveAction.action.ReadValue<Vector2>().y;
        var moveDirection = _focalPoint.transform.forward;

        _rb.AddForce(verticalInput * moveSpeed * moveDirection);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            var awayDirection = (collision.gameObject.transform.position - transform.position).normalized;

            var enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            enemyRb.AddForce(awayDirection * powerUpStrength, ForceMode.Impulse);
        }
    }
}

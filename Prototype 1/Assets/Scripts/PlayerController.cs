using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference input;
    public float vehicleSpeed = 5.0f;
    public float turnSpeed = 1.0f;

    private void Update()
    {
        var moveDirection = input.action.ReadValue<Vector2>();

        transform.Translate(vehicleSpeed * Time.deltaTime * moveDirection.y * Vector3.forward);
        transform.Rotate(turnSpeed * Time.deltaTime * moveDirection.x * Vector3.up);
    }
}
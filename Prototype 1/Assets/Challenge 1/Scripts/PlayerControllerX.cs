using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public InputActionReference input;
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    // Update is called once per frame
    private void FixedUpdate()
    {
        var moveDirection = input.action.ReadValue<Vector2>();

        // move the plane forward at a constant rate
        transform.Translate(Time.deltaTime * speed * Vector3.forward);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Time.deltaTime * moveDirection.y * rotationSpeed * Vector3.left);
    }
}
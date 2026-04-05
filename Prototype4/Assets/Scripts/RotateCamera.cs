using UnityEngine;
using UnityEngine.InputSystem;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 100;
    public InputActionReference moveAction;

    void Update()
    {
        var moveInput = moveAction.action.ReadValue<Vector2>();
        transform.Rotate(Vector3.down, moveInput.x * rotationSpeed * Time.deltaTime);
    }
}

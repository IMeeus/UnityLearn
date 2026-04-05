using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10;
    public float horizontalBoundary = 10;
    public float verticalBoundary = 10;

    public GameObject projectilePrefab;
    public InputActionReference moveAction;
    public InputActionReference projectileAction;

    void Update()
    {
        UpdateMove();
        UpdateShoot();
    }

    private void UpdateMove()
    {
        var moveInput = moveAction.action.ReadValue<Vector2>();

        if (moveInput.x == 0 && moveInput.y == 0)
            return;

        float newX = transform.position.x + moveInput.x * movementSpeed * Time.deltaTime;
        float clampedX = Mathf.Clamp(newX, -horizontalBoundary, horizontalBoundary);

        float newZ = transform.position.z + moveInput.y * movementSpeed * Time.deltaTime;
        float clampedZ = Mathf.Clamp(newZ, 0, verticalBoundary);

        transform.position = new Vector3(clampedX, 0, clampedZ);
    }

    private void UpdateShoot()
    {
        if (projectileAction.action.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}

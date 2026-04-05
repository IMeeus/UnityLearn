using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    private readonly float _inputDelay = 1;

    private float _lastActionTime = 0;

    public GameObject dogPrefab;
    public InputActionReference sendDogAction;

    void Update()
    {
        if (sendDogAction.action.WasPressedThisFrame())
        {
            if (Time.time - _lastActionTime < _inputDelay)
                return;

            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            _lastActionTime = Time.time;
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class FollowPlayer : MonoBehaviour
{
    private CameraSettings _cameraSettings;

    public InputActionReference switchCameraAction;
    public GameObject player;

    public FollowPlayer()
    {
        _cameraSettings = CameraSettings.ThirdPerson();
    }

    private void Start()
    {
        _cameraSettings.ApplyTo(transform);
    }

    private void Update()
    {
        if (switchCameraAction.action.triggered)
        {
            if (_cameraSettings.Kind == CameraSettingsKind.FirstPerson)
            {
                _cameraSettings = CameraSettings.ThirdPerson();
            }
            else
            {
                _cameraSettings = CameraSettings.FirstPerson();
            }

            _cameraSettings.ApplyTo(transform);
        }
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + _cameraSettings.Position;

        if (_cameraSettings.Kind == CameraSettingsKind.FirstPerson)
        {
            transform.rotation = player.transform.rotation;
        }
    }
}

public class CameraSettings
{
    private static readonly CameraSettings _firstPerson = new(CameraSettingsKind.FirstPerson, new(0, 2, .5f));
    private static readonly CameraSettings _thirdPerson = new(CameraSettingsKind.ThirdPerson, new(0, 6, -10), new(10, 0, 0));

    public CameraSettingsKind Kind { get; }
    public Vector3 Position { get; }
    public Vector3 Rotation { get; }

    private CameraSettings(
        CameraSettingsKind kind,
        Vector3? position = null,
        Vector3? rotation = null)
    {
        Kind = kind;
        Position = position ?? Vector3.zero;
        Rotation = rotation ?? Vector3.zero;
    }

    public static CameraSettings FirstPerson()
    {
        return _firstPerson;
    }

    public static CameraSettings ThirdPerson()
    {
        return _thirdPerson;
    }

    public void ApplyTo(Transform transform)
    {
        transform.SetPositionAndRotation(Position, Quaternion.Euler(Rotation));
    }
}

public enum CameraSettingsKind
{
    FirstPerson,
    ThirdPerson,
}
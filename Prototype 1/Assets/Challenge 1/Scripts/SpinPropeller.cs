using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.forward);
    }
}
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Vector3 offset;

    // Update is called once per frame
    private void Update()
    {
        transform.position = plane.transform.position + offset;
    }
}
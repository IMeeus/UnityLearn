using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject _player;

    public float moveSpeed = 3;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        var moveDirection = (_player.transform.position - transform.position).normalized;

        _rb.AddForce(moveDirection * moveSpeed);
    }
}

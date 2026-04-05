using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private const float _lowerBound = -10;

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
        ChasePlayer();
        DetroyOutOfBounds();
    }

    private void ChasePlayer()
    {
        var moveDirection = (_player.transform.position - transform.position).normalized;
        _rb.AddForce(moveDirection * moveSpeed);
    }

    private void DetroyOutOfBounds()
    {
        if (transform.position.y < _lowerBound)
        {
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;

    public InputActionReference jumpAction;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public bool isOnGround = true;
    public bool isGameOver = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if (isGameOver)
            return;

        if (isOnGround && jumpAction.action.WasPressedThisFrame())
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            _animator.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            _animator.SetBool("Death_b", true);
            _animator.SetInteger("DeathType_int", 1);
        }
    }
}

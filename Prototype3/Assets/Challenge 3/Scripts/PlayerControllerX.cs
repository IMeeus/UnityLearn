using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerX : MonoBehaviour
{
    private AudioSource playerAudio;
    private float gravityModifier = 1.5f;

    public bool gameOver;
    public float floatForce;

    private Rigidbody playerRb;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public ParticleSystem fireworksParticle;
    public ParticleSystem explosionParticle;
    public InputActionReference jumpAction;

    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    void Update()
    {
        if (jumpAction.action.WasPressedThisFrame() && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
    }
}

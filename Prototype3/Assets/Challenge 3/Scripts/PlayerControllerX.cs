using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerX : MonoBehaviour
{
    private AudioSource playerAudio;

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
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        //Physics.gravity *= 2;
    }

    void Update()
    {
        if (jumpAction.action.WasPressedThisFrame() && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
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

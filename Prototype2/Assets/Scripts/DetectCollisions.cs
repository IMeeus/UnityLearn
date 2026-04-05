using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public Slider healthBar;
    public int damageOnHit = 50;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }

        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);

            healthBar.value += damageOnHit;
            if (healthBar.value >= healthBar.maxValue)
            {
                GameManager.Instance.AddScore(1);
                Destroy(gameObject);
            }
        }
    }
}

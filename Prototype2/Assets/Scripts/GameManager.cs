using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private int lives = 3;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Lives: " + lives);
    }
}

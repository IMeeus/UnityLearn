using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;

    public int difficulty = 1;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }
}

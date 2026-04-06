using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score = 0;
    private float spawnRate = 1.0f;
    private bool isGameActive = false;

    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverOverlay;
    public GameObject titleOverlay;

    void Update()
    {
        DestroyTargetOnClick();
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        titleOverlay.SetActive(false);
        StartCoroutine(SpawnTarget());
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverOverlay.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    private void DestroyTargetOnClick()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<Target>(out var target))
                {
                    AddScore(target.pointValue);
                    target.Destroy();
                }
            }
        }
    }

    private void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.SetText("Score: " + score);
    }
}
